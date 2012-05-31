/*
 * Created by SharpDevelop.
 * User: Korkonius
 * Date: 20.09.2011
 * Time: 14:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RFID2PNG
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        public int[] byteFrequencies = new int[256];
        public int byteCount = 0;
        public int topFreqIndex = 0;
        public int vizScale = 1;
        public bool imageHasChanged = true;
        public RFID2PNG.RFIDDataGenerator gen;

        public MainForm()
        {

            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            gen = new RFIDDataGenerator(160, 13, this.toolStripStatusLabel1, this.toolStripProgressBar1);
        }

        void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            fileNameBox.Clear();
            fileNameBox.AppendText(System.IO.Path.GetFileName(openFileDialog.FileName));

            // Open and parse stream data
            try
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);

                int numRows = 0;
                string line;
                consoleBox.AppendText("Parsing file... \r\n");

                gen.generatedData = new List<byte[]>();
                for (int i = 0; i < byteFrequencies.Length; i++)
                {
                    byteFrequencies[i] = 0;
                }
                this.topFreqIndex = 0;
                this.byteCount = 0;

                while ((line = sr.ReadLine()) != null)
                {

                    // Parse data
                    int separatorIndex = line.IndexOf('|');
                    string id = line.Substring(21, 17);
                    line = line.Substring(separatorIndex+1);
                    line = line.Replace(" ", "");
                    byte[] bytes = this.StringToBytes(line);

                    // Insert into gen.generatedData
                    gen.generatedData.Add(bytes);

                    // Count byte frequencies
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        byteFrequencies[bytes[i]]++;
                        byteCount++;
                        if (byteFrequencies[bytes[i]] > this.byteFrequencies[topFreqIndex]) topFreqIndex = bytes[i];
                    }

                    numRows++;
                }
                consoleBox.AppendText(numRows + " records found...\r\n");
                consoleBox.AppendText(byteCount + " bytes of data found...");
                sr.Close();
                gen.externalDataComplete();
            }
            catch (Exception er)
            {
                consoleBox.AppendText(er.Message);
            }

            pictureBox.Image = redrawImage();
        }

        void OpenButtonClick(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }


        private byte[] StringToBytes(string strInput)
        {

            int i = 0;
            int x = 0;
            byte[] bytes = new byte[(strInput.Length) / 2];
            while (strInput.Length > i + 1)
            {
                long lngDecimal = Convert.ToInt32(strInput.Substring(i, 2), 16);
                bytes[x] = Convert.ToByte(lngDecimal);
                i = i + 2;
                x++;

            }

            return bytes;
        }

        void SaveButtonClick(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        Bitmap redrawImage()
		{
			int row = 0;
			if(gen.generatedData.Count > 0) {
				int width = gen.generatedData[0].Length*vizScale;
				int height = gen.generatedData.Count*vizScale;
				
				// Create object and image
				Bitmap image = new Bitmap(width, height);
				Graphics canvas = Graphics.FromImage(image);
				Pen pen = new Pen(Color.Green);
                int overrideXScale = 1;
                
                // Create additional options
                int endTime = RFIDDataGenerator.DateTimeToUnix(timeWindowTarget.Value.AddHours((double)timeWindowSize.Value));
                int startTime = RFIDDataGenerator.DateTimeToUnix(timeWindowTarget.Value.AddHours(((double)timeWindowSize.Value) * -1.0d));
				
				// Draw each byte as square
				foreach(byte[] entry in gen.generatedData) {
                    
					byte[] bytes = entry;
					
					// Draw on graphics context
					byte val = 0;
				
					for(int u = 0; u < bytes.Length; u += overrideXScale) {
                        overrideXScale = 1;	
						if(normalMode.Checked) {
							val = bytes[u];
							pen.Color = Color.FromArgb(val, val, val);
						}
						else if(xorSelect.Checked) {
							val = (byte)(gen.generatedData[0][u] ^ bytes[u]);
							pen.Color = Color.FromArgb(val, val, val);
						}
						else if (asciiBlueBtn.Checked) {
							val = bytes[u];
							if( val >= 32 && val <= 127 ) {
								pen.Color = Color.Blue;
							}
							else {
								pen.Color = Color.FromArgb(val,val,val);
							}
						}
						else if (freqBtn.Checked) {
							val = (byte) (((float) this.byteFrequencies[bytes[u]] / (float) this.byteFrequencies[this.topFreqIndex]) * 255.0f);
							pen.Color = Color.FromArgb(val,val,val);
						}
                        else if (timestampBtn.Checked)
                        {
                            byte[] binaryNumber = new byte[4];
                            if (u < bytes.Length - 3)
                            {
                                try
                                {
                                    // Copy values into new array
                                    Array.Copy(bytes, u, binaryNumber, 0, 4);
                                    binaryNumber = RFIDDataGenerator.MakeEndianSafe(binaryNumber);
                                    int ticks = BitConverter.ToInt32(binaryNumber, 0);


                                        if (startTime < ticks && ticks < endTime)
                                        {
                                            pen.Color = Color.FromArgb(0xD4, 0x55, 0);
                                            overrideXScale = 4;
                                        }
                                        else
                                        {
                                            val = bytes[u];
                                            pen.Color = Color.FromArgb(val, val, val);
                                        }
                                }
                                catch (ArgumentException e)
                                {
                                    pen.Color = Color.FromArgb(val, 0, 0);
                                }
                            }
                            else
                            {
                                val = bytes[u];
                                pen.Color = Color.FromArgb(val, val, val);
                            }
                        }
						
						int srow = row*vizScale;
						for(int sx = 0; sx < vizScale; sx++) {
							canvas.FillRectangle(pen.Brush, u*vizScale, row*vizScale, vizScale*overrideXScale, vizScale);
						}
					}					
					row++;
				}
				return image;
			}
			else {
				return new Bitmap(1,1);
			}
		}

        void ModeCheckedChanged(object sender, EventArgs e)
        {
            pictureBox.Image = redrawImage();
        }

        void saveFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            pictureBox.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }



        void imageScaleChanged(object sender, EventArgs e)
        {
            this.vizScale = (int)imageScaleBox.Value;
            this.pictureBox.Image = redrawImage();

        }

        private void NewDatasetEvent(object sender, EventArgs e)
        {
            gen.start();

            gen.worker.RunWorkerCompleted += DatasetCompletedHandeler;
        }

        private void DatasetCompletedHandeler(object sender, EventArgs e)
        {
            this.gen.generatedData = new List<byte[]>(gen.generatedData);
            this.pictureBox.Image = redrawImage();
        }

        private void SaveDatasetEvent(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Dataset";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                gen.writeToFile(dialog.FileName);
            }
        }

        private void NewStfFileEvent(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save as Simple Table File";
            dialog.DefaultExt = "stf";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                gen.writeToStfFile(dialog.FileName);
            }
        }

        private void NewBinaryDumpClick(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save as binary dump";
            dialog.DefaultExt = "bin";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                gen.writeBinaryDump(dialog.FileName);
            }
        }

        private void ShiftCipherEncEvent(object sender, EventArgs e)
        {
            gen.encryptShiftCipher(10);
        }

        private void ShiftCipherDecEvent(object sender, EventArgs e)
        {
            gen.decryptShiftCipher(10);
        }

        private void DoPadCrypt(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open key file...";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {

                // Open and read keys from file
                List<byte[]> keystore = new List<byte[]>();
                using (StreamReader sr = new StreamReader(dialog.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        keystore.Add(this.StringToBytes(line));
                    }
                }

                // All keys loaded pass on to encryption function to encode/decode datastore
                gen.encryptPad(keystore);
            }
        }
    }
}
