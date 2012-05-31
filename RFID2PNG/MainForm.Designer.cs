/*
 * Created by SharpDevelop.
 * User: Korkonius
 * Date: 20.09.2011
 * Time: 14:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RFID2PNG
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.controlPane = new System.Windows.Forms.GroupBox();
            this.timeWindowSize = new System.Windows.Forms.NumericUpDown();
            this.timeWindowTarget = new System.Windows.Forms.DateTimePicker();
            this.timestampBtn = new System.Windows.Forms.RadioButton();
            this.freqBtn = new System.Windows.Forms.RadioButton();
            this.asciiBlueBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.imageScaleBox = new System.Windows.Forms.NumericUpDown();
            this.xorSelect = new System.Windows.Forms.RadioButton();
            this.normalMode = new System.Windows.Forms.RadioButton();
            this.saveButton = new System.Windows.Forms.Button();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBinaryDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsstfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encDecryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftCipherEncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftCipherDecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.padEncDecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.controlPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageScaleBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(253, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(632, 439);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // controlPane
            // 
            this.controlPane.Controls.Add(this.timeWindowSize);
            this.controlPane.Controls.Add(this.timeWindowTarget);
            this.controlPane.Controls.Add(this.timestampBtn);
            this.controlPane.Controls.Add(this.freqBtn);
            this.controlPane.Controls.Add(this.asciiBlueBtn);
            this.controlPane.Controls.Add(this.label1);
            this.controlPane.Controls.Add(this.imageScaleBox);
            this.controlPane.Controls.Add(this.xorSelect);
            this.controlPane.Controls.Add(this.normalMode);
            this.controlPane.Controls.Add(this.saveButton);
            this.controlPane.Controls.Add(this.fileNameBox);
            this.controlPane.Controls.Add(this.openButton);
            this.controlPane.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPane.Location = new System.Drawing.Point(3, 3);
            this.controlPane.Name = "controlPane";
            this.tableLayoutPanel1.SetRowSpan(this.controlPane, 2);
            this.controlPane.Size = new System.Drawing.Size(239, 489);
            this.controlPane.TabIndex = 1;
            this.controlPane.TabStop = false;
            this.controlPane.Text = "Controls";
            // 
            // timeWindowSize
            // 
            this.timeWindowSize.Location = new System.Drawing.Point(0, 422);
            this.timeWindowSize.Name = "timeWindowSize";
            this.timeWindowSize.Size = new System.Drawing.Size(120, 20);
            this.timeWindowSize.TabIndex = 13;
            // 
            // timeWindowTarget
            // 
            this.timeWindowTarget.Location = new System.Drawing.Point(0, 448);
            this.timeWindowTarget.Name = "timeWindowTarget";
            this.timeWindowTarget.Size = new System.Drawing.Size(239, 20);
            this.timeWindowTarget.TabIndex = 12;
            // 
            // timestampBtn
            // 
            this.timestampBtn.AutoSize = true;
            this.timestampBtn.Location = new System.Drawing.Point(8, 186);
            this.timestampBtn.Name = "timestampBtn";
            this.timestampBtn.Size = new System.Drawing.Size(113, 17);
            this.timestampBtn.TabIndex = 11;
            this.timestampBtn.TabStop = true;
            this.timestampBtn.Text = "Color Time Stamps";
            this.timestampBtn.UseVisualStyleBackColor = true;
            // 
            // freqBtn
            // 
            this.freqBtn.Location = new System.Drawing.Point(8, 155);
            this.freqBtn.Name = "freqBtn";
            this.freqBtn.Size = new System.Drawing.Size(223, 24);
            this.freqBtn.TabIndex = 10;
            this.freqBtn.TabStop = true;
            this.freqBtn.Text = "Byte Frequency";
            this.freqBtn.UseVisualStyleBackColor = true;
            // 
            // asciiBlueBtn
            // 
            this.asciiBlueBtn.Location = new System.Drawing.Point(8, 128);
            this.asciiBlueBtn.Name = "asciiBlueBtn";
            this.asciiBlueBtn.Size = new System.Drawing.Size(223, 24);
            this.asciiBlueBtn.TabIndex = 9;
            this.asciiBlueBtn.TabStop = true;
            this.asciiBlueBtn.Text = "ASCII Blue";
            this.asciiBlueBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(38, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Image Scale";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageScaleBox
            // 
            this.imageScaleBox.Location = new System.Drawing.Point(6, 302);
            this.imageScaleBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.imageScaleBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageScaleBox.Name = "imageScaleBox";
            this.imageScaleBox.Size = new System.Drawing.Size(34, 20);
            this.imageScaleBox.TabIndex = 7;
            this.imageScaleBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageScaleBox.ValueChanged += new System.EventHandler(this.imageScaleChanged);
            // 
            // xorSelect
            // 
            this.xorSelect.Location = new System.Drawing.Point(8, 101);
            this.xorSelect.Name = "xorSelect";
            this.xorSelect.Size = new System.Drawing.Size(223, 24);
            this.xorSelect.TabIndex = 6;
            this.xorSelect.Text = "XOR first row";
            this.xorSelect.UseVisualStyleBackColor = true;
            this.xorSelect.CheckedChanged += new System.EventHandler(this.ModeCheckedChanged);
            // 
            // normalMode
            // 
            this.normalMode.Checked = true;
            this.normalMode.Location = new System.Drawing.Point(8, 74);
            this.normalMode.Name = "normalMode";
            this.normalMode.Size = new System.Drawing.Size(223, 24);
            this.normalMode.TabIndex = 5;
            this.normalMode.TabStop = true;
            this.normalMode.Text = "Normal";
            this.normalMode.UseVisualStyleBackColor = true;
            this.normalMode.CheckedChanged += new System.EventHandler(this.ModeCheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(143, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Image...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // fileNameBox
            // 
            this.fileNameBox.Cursor = System.Windows.Forms.Cursors.No;
            this.fileNameBox.Enabled = false;
            this.fileNameBox.Location = new System.Drawing.Point(6, 48);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(223, 20);
            this.fileNameBox.TabIndex = 3;
            this.fileNameBox.Text = "No file selected...";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(6, 19);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Open File...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButtonClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.consoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox.Location = new System.Drawing.Point(253, 448);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.Size = new System.Drawing.Size(632, 44);
            this.consoleBox.TabIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.FileName = "RFIDImage";
            this.saveFileDialog1.Title = "Save image as...";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogFileOk);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.consoleBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.controlPane, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 495);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.datasetToolStripMenuItem,
            this.encDecryptionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // datasetToolStripMenuItem
            // 
            this.datasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatasetToolStripMenuItem,
            this.saveBinaryDumpToolStripMenuItem,
            this.saveDatasetToolStripMenuItem,
            this.saveAsstfToolStripMenuItem});
            this.datasetToolStripMenuItem.Name = "datasetToolStripMenuItem";
            this.datasetToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.datasetToolStripMenuItem.Text = "Dataset";
            // 
            // newDatasetToolStripMenuItem
            // 
            this.newDatasetToolStripMenuItem.Name = "newDatasetToolStripMenuItem";
            this.newDatasetToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.newDatasetToolStripMenuItem.Text = "New Dataset";
            this.newDatasetToolStripMenuItem.Click += new System.EventHandler(this.NewDatasetEvent);
            // 
            // saveBinaryDumpToolStripMenuItem
            // 
            this.saveBinaryDumpToolStripMenuItem.Name = "saveBinaryDumpToolStripMenuItem";
            this.saveBinaryDumpToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveBinaryDumpToolStripMenuItem.Text = "Save binary dump";
            this.saveBinaryDumpToolStripMenuItem.Click += new System.EventHandler(this.NewBinaryDumpClick);
            // 
            // saveDatasetToolStripMenuItem
            // 
            this.saveDatasetToolStripMenuItem.Name = "saveDatasetToolStripMenuItem";
            this.saveDatasetToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveDatasetToolStripMenuItem.Text = "Save as plain text";
            this.saveDatasetToolStripMenuItem.Click += new System.EventHandler(this.SaveDatasetEvent);
            // 
            // saveAsstfToolStripMenuItem
            // 
            this.saveAsstfToolStripMenuItem.Name = "saveAsstfToolStripMenuItem";
            this.saveAsstfToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveAsstfToolStripMenuItem.Text = "Save as .stf";
            this.saveAsstfToolStripMenuItem.Click += new System.EventHandler(this.NewStfFileEvent);
            // 
            // encDecryptionToolStripMenuItem
            // 
            this.encDecryptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shiftCipherEncToolStripMenuItem,
            this.shiftCipherDecToolStripMenuItem,
            this.padEncDecToolStripMenuItem});
            this.encDecryptionToolStripMenuItem.Name = "encDecryptionToolStripMenuItem";
            this.encDecryptionToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.encDecryptionToolStripMenuItem.Text = "Enc/Decryption";
            // 
            // shiftCipherEncToolStripMenuItem
            // 
            this.shiftCipherEncToolStripMenuItem.Name = "shiftCipherEncToolStripMenuItem";
            this.shiftCipherEncToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.shiftCipherEncToolStripMenuItem.Text = "Shift Cipher Enc";
            this.shiftCipherEncToolStripMenuItem.Click += new System.EventHandler(this.ShiftCipherEncEvent);
            // 
            // shiftCipherDecToolStripMenuItem
            // 
            this.shiftCipherDecToolStripMenuItem.Name = "shiftCipherDecToolStripMenuItem";
            this.shiftCipherDecToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.shiftCipherDecToolStripMenuItem.Text = "Shift Cipher Dec";
            this.shiftCipherDecToolStripMenuItem.Click += new System.EventHandler(this.ShiftCipherDecEvent);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(888, 21);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 15);
            this.toolStripStatusLabel1.Text = "Loading application...";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 15);
            // 
            // padEncDecToolStripMenuItem
            // 
            this.padEncDecToolStripMenuItem.Name = "padEncDecToolStripMenuItem";
            this.padEncDecToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.padEncDecToolStripMenuItem.Text = "Pad Enc/Dec";
            this.padEncDecToolStripMenuItem.Click += new System.EventHandler(this.DoPadCrypt);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 519);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RFID2PNG";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.controlPane.ResumeLayout(false);
            this.controlPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageScaleBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.RadioButton freqBtn;
		private System.Windows.Forms.RadioButton asciiBlueBtn;
		private System.Windows.Forms.NumericUpDown imageScaleBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.RadioButton xorSelect;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TextBox consoleBox;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.TextBox fileNameBox;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.RadioButton normalMode;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.GroupBox controlPane;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDatasetToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem saveDatasetToolStripMenuItem;
        private System.Windows.Forms.RadioButton timestampBtn;
        private System.Windows.Forms.NumericUpDown timeWindowSize;
        private System.Windows.Forms.DateTimePicker timeWindowTarget;
        private System.Windows.Forms.ToolStripMenuItem saveAsstfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBinaryDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encDecryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftCipherEncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftCipherDecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem padEncDecToolStripMenuItem;
	}
}
