using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace RFID2PNG
{
    public class RFIDDataGenerator
    {

        // Set up the background worker used by this class
        public volatile BackgroundWorker worker = new BackgroundWorker();
        volatile Random rng;
        public volatile List<byte[]> generatedData;
        volatile int numRecords;
        volatile int seed;

        // Static flag fields used in page 2 and 3 of dataset. NOTE! First index is not fixed!
        byte[] flag = { 0x00, 0x48, 0x08, 0x00, 0x0D, 0x04, 0xE0, 0x94 };
        const long ticks1970 = 621355968000000000;

        // Store references to UI components to update UI
        ToolStripStatusLabel statusLabel;
        ToolStripProgressBar progressBar;

        // Bool data generated?
        bool completed = false;
        private int p;
        private int p_2;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripProgressBar toolStripProgressBar;

        public static int DateTimeToUnix(DateTime t) {
            return (int)((t.Ticks - ticks1970) / 10000000L);
        }

        public static DateTime UnixToDateTime(int u)
        {
            return new DateTime(ticks1970 + u * 10000000L);
        }

        public static byte[] MakeEndianSafe(byte[] b)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }

            return b;

        }

        public RFIDDataGenerator(int numRecords, int seed, ToolStripStatusLabel statusLabel, ToolStripProgressBar progressBar)
        {
            // Set up all values passed to constructor
            this.numRecords = numRecords;
            this.seed = seed;
            this.statusLabel = statusLabel;
            this.progressBar = progressBar;
            rng = new Random(seed);
            generatedData = new List<byte[]>(numRecords);


            // Create worker and register events
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(this.DoWorkEventHandeler);
            worker.ProgressChanged += new ProgressChangedEventHandler(this.ProgressChangedEventHandeler);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerThreadCompleted);
        }

        public void cancel()
        {
            worker.CancelAsync();
        }

        public void start()
        {
            if (worker.IsBusy != true)
            {
                worker.RunWorkerAsync();
            }
        }

        public void externalDataComplete()
        {
            this.completed = true;
        }

        public void writeToFile(String filename)
        {
            if (this.completed == true)
            {
                try
                {
                    // Makes sure stream is closed when completed
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (byte[] entry in this.generatedData)
                        {

                            // Prepare entry
                            String line = BitConverter.ToString(entry).Replace("-", string.Empty);
                            for (int i = line.Length; i > 0; i -= 8)
                            {
                                line = line.Insert(i, " ");
                            }
                            line = line.Insert(0, "Dummy entry | ");

                            // Write line
                            sw.WriteLine(line);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Could not write to file: ");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void writeToStfFile(String filename)
        {
            if (this.completed == true)
            {
                try
                {

                    // Make sure resources are released
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        // Write header fields
                        int numFields = this.generatedData[0].Length/4;
                        sw.WriteLine(numFields.ToString());
                        for (int i = 1; i <= numFields; i++)
                        {
                            sw.WriteLine("Dim" + i.ToString() + " integer");
                        }

                        // Write all data
                        foreach (byte[] entry in this.generatedData)
                        {

                            // Prepare entry
                            String line = "";
                            for (int i = 0; i < (entry.Length/4); i++)
                            {
                                int num = BitConverter.ToInt32(entry, i * 4);
                                line += num.ToString() + " ";
                            }

                            // Write line
                            sw.WriteLine(line);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Could not write to stf file: ");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void writeBinaryDump(string filename)
        {

            if (this.completed)
            {

                try
                {
                    // Open file stream
                    using (FileStream stream = new FileStream(filename, FileMode.Create))
                    {

                        // Wrap stream in binary writer
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                            foreach (byte[] line in this.generatedData)
                            {
                                writer.Write(line);
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Failed to output binary dump: " + e.Message);
                }
            }
        }

        public void encryptShiftCipher(byte k)
        {

            // Shift all bits k
            foreach(byte[] line in this.generatedData){
            for (byte i = 2; i < line.Length; i++ )
            {
                line[i] = (byte) ((line[i] + k) % byte.MaxValue);
            }
            }
        }

        public void decryptShiftCipher(byte k)
        {

            // Unshift all bits k
            foreach (byte[] line in this.generatedData)
            {
                for (byte i = 2; i < line.Length; i++)
                {
                    int val = line[i] - k;
                    if (val == 0)
                    {
                        line[i] = 0;
                    }
                    else if (val > 0)
                    {
                        line[i] = (byte)((line[i] - k) % byte.MaxValue);
                    }
                    else
                    {
                        line[i] = (byte)(byte.MaxValue + (line[i] - k));
                    }
                }
            }
        }

        public void encryptPad(List<byte[]> keystore)
        {

            // Process all records and update apply selected key
            for (int i = 0; i < this.numRecords; i++)
            {

                // Determine the index of the key we have to use
                UInt64 tagId = BitConverter.ToUInt64(this.generatedData[i], 0);
                UInt64 bigIndex = (tagId % Convert.ToUInt64(keystore.Count));
                int keyIndex = Convert.ToInt32(bigIndex);

                for (int u = 8; u < generatedData[i].Length; u++)
                {

                    // XOR byte in generated data with the data from the key
                    generatedData[i][u] = (byte) (generatedData[i][u] ^ keystore[keyIndex][u]);
                }
             }
        }

        protected void DoWorkEventHandeler(object sender, DoWorkEventArgs args)
        {

            // Process enough rounds to fill the list with entries
            for (int i = 0; i < this.numRecords; i++)
            {

                // Check to see if work was canceled
                BackgroundWorker bw = sender as BackgroundWorker;
                if(bw.CancellationPending == true){
                    args.Cancel = true;
                    break;
                }

                // Initialize variables
                byte[] cardId = new byte[8];
                // Flags provide extra 8
                byte[] stationId = new byte[4]; // 20
                byte[] userId = new byte[4]; // 24
                byte[] issuerNode = new byte[4]; // 28
                byte[] ticketFor = {0, 0, 0};
                byte[] productType = new byte[1]; // 48
                byte[] md5 = new byte[16]; // 64

                // Create a base time and add some randomization
                DateTime issued = DateTime.Now.AddSeconds(rng.Next(-86400, 86400)); // +- 1 day
                DateTime registered = issued.AddSeconds(rng.Next(0, 3600)); // Registered within an hour

                byte[] issuedTime = MakeEndianSafe(BitConverter.GetBytes(DateTimeToUnix(issued))); // 36
                byte[] registeredTime = MakeEndianSafe(BitConverter.GetBytes(DateTimeToUnix(registered))); // 44

                // Generate random values
                rng.NextBytes(cardId);
                rng.NextBytes(userId);
                stationId = BitConverter.GetBytes(rng.Next(0,9999));
                userId = BitConverter.GetBytes(rng.Next());
                issuerNode = BitConverter.GetBytes(rng.Next(0,9999));
                
                // Simulate group and discount tickets, 90% single use
                if(rng.Next(0, 100) > 90) {
                    byte discount = BitConverter.GetBytes(rng.Next(0,2))[0];
                    byte normal = BitConverter.GetBytes(rng.Next(0,4))[0];
                    byte child = BitConverter.GetBytes(rng.Next(0,3))[0];
                    ticketFor[0] = discount;
                    ticketFor[1] = normal;
                    ticketFor[2] = child;

                    productType[0] = 0x2;
                }
                else {
                    int type = rng.Next(0, 2);
                    ticketFor[type] = 1;
                    productType[0] = 0x1;
                }

                // Place values in final array
                byte[] entry = new byte[64];
                int offset = 0;

                // Card ID
                cardId.CopyTo(entry, offset);
                offset += sizeof(byte) * 8;

                // Copy flag
                this.flag.CopyTo(entry, offset);
                offset += sizeof(byte) * 8;

                // Copy station ID
                stationId.CopyTo(entry, offset);
                offset += sizeof(byte) * 4;

                // Copy user id
                userId.CopyTo(entry,offset);
                offset += sizeof(byte) * 4;

                // Copy issuer node
                issuerNode.CopyTo(entry,offset);
                offset += sizeof(byte) * 4;

                // Copy issues time
                issuedTime.CopyTo(entry, offset);
                offset += sizeof(byte) * issuedTime.Length; // Fixed according to MSDN

                // Copy product type
                productType.CopyTo(entry,offset);
                offset += sizeof(byte) * 1;

                // Copy ticket numbers
                ticketFor.CopyTo(entry,offset); // Fields to 38
                offset += sizeof(byte) * 3;

                // Create hash
                MD5 md5Hasher = new MD5CryptoServiceProvider();
                md5 = md5Hasher.ComputeHash(entry, 0, offset);
                md5.CopyTo(entry, offset);
                offset += sizeof(byte) * 16;

                registeredTime.CopyTo(entry, offset);

                generatedData.Add(entry);

                // Report progress
                bw.ReportProgress(i / numRecords);
            }
        }

        protected void ProgressChangedEventHandeler(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        protected void RunWorkerThreadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.statusLabel.Text = "Ticket generation canceled!";
            }
            else if (!(e.Error == null))
            {
                this.statusLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                this.completed = true;
                this.statusLabel.Text = "Successfully generated dataset!";
            }
        }
    }
}
