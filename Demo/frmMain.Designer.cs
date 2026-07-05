namespace LoggerDemo
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            pctLogo = new PictureBox();
            txtFilePath = new TextBox();
            txtTotalLogfilesToRetain = new NumericUpDown();
            txtCustomTimestampFormat = new TextBox();
            label7 = new Label();
            chkUnlimitedFileSize = new CheckBox();
            chkUnlimitedFilesToRetain = new CheckBox();
            chkDefaultExtension = new CheckBox();
            chkAutoRoute = new CheckBox();
            txtLogFilesizeLimit = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cboTimestampFormat = new ComboBox();
            cboLoggerRotationInterval = new ComboBox();
            txtCustomExtension = new TextBox();
            panel1 = new Panel();
            label8 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            txtLogName = new TextBox();
            label9 = new Label();
            btnExit = new Button();
            btnRunTest = new Button();
            tmrLogTest = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pctLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTotalLogfilesToRetain).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pctLogo
            // 
            pctLogo.Image = Properties.Resources.LoggerIcon;
            pctLogo.Location = new Point(12, 25);
            pctLogo.Name = "pctLogo";
            pctLogo.Size = new Size(347, 360);
            pctLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pctLogo.TabIndex = 0;
            pctLogo.TabStop = false;
            // 
            // txtFilePath
            // 
            txtFilePath.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilePath.Location = new Point(168, 67);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "Custom Log Directory";
            txtFilePath.Size = new Size(302, 29);
            txtFilePath.TabIndex = 2;
            // 
            // txtTotalLogfilesToRetain
            // 
            txtTotalLogfilesToRetain.Font = new Font("Consola Mono", 12F);
            txtTotalLogfilesToRetain.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtTotalLogfilesToRetain.Location = new Point(169, 168);
            txtTotalLogfilesToRetain.Name = "txtTotalLogfilesToRetain";
            txtTotalLogfilesToRetain.Size = new Size(301, 29);
            txtTotalLogfilesToRetain.TabIndex = 4;
            // 
            // txtCustomTimestampFormat
            // 
            txtCustomTimestampFormat.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomTimestampFormat.Location = new Point(168, 346);
            txtCustomTimestampFormat.Name = "txtCustomTimestampFormat";
            txtCustomTimestampFormat.PlaceholderText = "Custom Timestamp Format";
            txtCustomTimestampFormat.Size = new Size(302, 29);
            txtCustomTimestampFormat.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(16, 351);
            label7.Name = "label7";
            label7.Size = new Size(100, 17);
            label7.TabIndex = 18;
            label7.Text = "Custom Format:";
            // 
            // chkUnlimitedFileSize
            // 
            chkUnlimitedFileSize.AutoSize = true;
            chkUnlimitedFileSize.Font = new Font("Segoe UI", 9.75F);
            chkUnlimitedFileSize.Location = new Point(29, 279);
            chkUnlimitedFileSize.Name = "chkUnlimitedFileSize";
            chkUnlimitedFileSize.Size = new Size(82, 21);
            chkUnlimitedFileSize.TabIndex = 17;
            chkUnlimitedFileSize.Text = "Unlimited";
            chkUnlimitedFileSize.UseVisualStyleBackColor = true;
            chkUnlimitedFileSize.CheckedChanged += chkUnlimitedFileSize_CheckedChanged;
            // 
            // chkUnlimitedFilesToRetain
            // 
            chkUnlimitedFilesToRetain.AutoSize = true;
            chkUnlimitedFilesToRetain.Font = new Font("Segoe UI", 9.75F);
            chkUnlimitedFilesToRetain.Location = new Point(32, 183);
            chkUnlimitedFilesToRetain.Name = "chkUnlimitedFilesToRetain";
            chkUnlimitedFilesToRetain.Size = new Size(101, 21);
            chkUnlimitedFilesToRetain.TabIndex = 16;
            chkUnlimitedFilesToRetain.Text = "Unlimited (0)";
            chkUnlimitedFilesToRetain.UseVisualStyleBackColor = true;
            chkUnlimitedFilesToRetain.CheckedChanged += chkUnlimitedFilesToRetain_CheckedChanged;
            // 
            // chkDefaultExtension
            // 
            chkDefaultExtension.AutoSize = true;
            chkDefaultExtension.Font = new Font("Segoe UI", 9.75F);
            chkDefaultExtension.Location = new Point(31, 130);
            chkDefaultExtension.Name = "chkDefaultExtension";
            chkDefaultExtension.Size = new Size(102, 21);
            chkDefaultExtension.TabIndex = 15;
            chkDefaultExtension.Text = "Default (.log)";
            chkDefaultExtension.UseVisualStyleBackColor = true;
            chkDefaultExtension.CheckedChanged += chkDefaultExtension_CheckedChanged;
            // 
            // chkAutoRoute
            // 
            chkAutoRoute.AutoSize = true;
            chkAutoRoute.Font = new Font("Segoe UI", 9.75F);
            chkAutoRoute.Location = new Point(21, 81);
            chkAutoRoute.Name = "chkAutoRoute";
            chkAutoRoute.Size = new Size(88, 21);
            chkAutoRoute.TabIndex = 14;
            chkAutoRoute.Text = "AutoRoute";
            chkAutoRoute.UseVisualStyleBackColor = true;
            chkAutoRoute.CheckedChanged += chkAutoRoute_CheckedChanged;
            // 
            // txtLogFilesizeLimit
            // 
            txtLogFilesizeLimit.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogFilesizeLimit.Location = new Point(168, 264);
            txtLogFilesizeLimit.Name = "txtLogFilesizeLimit";
            txtLogFilesizeLimit.PlaceholderText = "Eg:  1MB, 1GB, 500B, 500KB, etc";
            txtLogFilesizeLimit.Size = new Size(302, 29);
            txtLogFilesizeLimit.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(16, 259);
            label6.Name = "label6";
            label6.Size = new Size(109, 17);
            label6.TabIndex = 12;
            label6.Text = "Log Filesize Limit:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(16, 312);
            label5.Name = "label5";
            label5.Size = new Size(120, 17);
            label5.TabIndex = 11;
            label5.Text = "Timestamp Format:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(18, 219);
            label4.Name = "label4";
            label4.Size = new Size(106, 17);
            label4.TabIndex = 10;
            label4.Text = "Rotation Interval:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(13, 163);
            label3.Name = "label3";
            label3.Size = new Size(146, 17);
            label3.TabIndex = 9;
            label3.Text = "Total Logfiles To Retain:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(13, 110);
            label2.Name = "label2";
            label2.Size = new Size(137, 17);
            label2.TabIndex = 8;
            label2.Text = "Custom File Extension:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(13, 61);
            label1.Name = "label1";
            label1.Size = new Size(102, 17);
            label1.TabIndex = 7;
            label1.Text = "Custom Log Dir:";
            // 
            // cboTimestampFormat
            // 
            cboTimestampFormat.DropDownHeight = 200;
            cboTimestampFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimestampFormat.DropDownWidth = 800;
            cboTimestampFormat.Font = new Font("Consola Mono", 12F);
            cboTimestampFormat.FormattingEnabled = true;
            cboTimestampFormat.IntegralHeight = false;
            cboTimestampFormat.ItemHeight = 22;
            cboTimestampFormat.Location = new Point(168, 305);
            cboTimestampFormat.Name = "cboTimestampFormat";
            cboTimestampFormat.Size = new Size(302, 30);
            cboTimestampFormat.TabIndex = 6;
            cboTimestampFormat.SelectedIndexChanged += cboTimestampFormat_SelectedIndexChanged;
            // 
            // cboLoggerRotationInterval
            // 
            cboLoggerRotationInterval.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoggerRotationInterval.DropDownWidth = 300;
            cboLoggerRotationInterval.Font = new Font("Consola Mono", 12F);
            cboLoggerRotationInterval.FormattingEnabled = true;
            cboLoggerRotationInterval.ItemHeight = 22;
            cboLoggerRotationInterval.Items.AddRange(new object[] { "Disabled", "Hourly", "Minutely", "Daily", "Weekly", "Fortnightly", "Monthly", "Yearly" });
            cboLoggerRotationInterval.Location = new Point(168, 212);
            cboLoggerRotationInterval.Name = "cboLoggerRotationInterval";
            cboLoggerRotationInterval.Size = new Size(302, 30);
            cboLoggerRotationInterval.TabIndex = 5;
            // 
            // txtCustomExtension
            // 
            txtCustomExtension.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomExtension.Location = new Point(168, 116);
            txtCustomExtension.Name = "txtCustomExtension";
            txtCustomExtension.PlaceholderText = "Custom File Extension";
            txtCustomExtension.Size = new Size(302, 29);
            txtCustomExtension.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 433);
            panel1.Name = "panel1";
            panel1.Size = new Size(858, 27);
            panel1.TabIndex = 4;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Dock = DockStyle.Fill;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(858, 27);
            label8.TabIndex = 8;
            label8.Text = "Labworx Logger, developed by Anthony Musgrove (anthony@labworx.au)";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(pctLogo);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(370, 433);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtLogName);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(btnExit);
            panel3.Controls.Add(btnRunTest);
            panel3.Controls.Add(txtTotalLogfilesToRetain);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtCustomTimestampFormat);
            panel3.Controls.Add(txtFilePath);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(txtCustomExtension);
            panel3.Controls.Add(chkUnlimitedFileSize);
            panel3.Controls.Add(cboLoggerRotationInterval);
            panel3.Controls.Add(chkUnlimitedFilesToRetain);
            panel3.Controls.Add(cboTimestampFormat);
            panel3.Controls.Add(chkDefaultExtension);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(chkAutoRoute);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtLogFilesizeLimit);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(370, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(488, 433);
            panel3.TabIndex = 6;
            // 
            // txtLogName
            // 
            txtLogName.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogName.Location = new Point(169, 21);
            txtLogName.Name = "txtLogName";
            txtLogName.PlaceholderText = "Log Name (eg 'Test')";
            txtLogName.Size = new Size(302, 29);
            txtLogName.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.Location = new Point(16, 25);
            label9.Name = "label9";
            label9.Size = new Size(72, 17);
            label9.TabIndex = 22;
            label9.Text = "Log Name:";
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(392, 388);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 32);
            btnExit.TabIndex = 21;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnRunTest
            // 
            btnRunTest.FlatStyle = FlatStyle.Flat;
            btnRunTest.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRunTest.Location = new Point(311, 388);
            btnRunTest.Name = "btnRunTest";
            btnRunTest.Size = new Size(75, 32);
            btnRunTest.TabIndex = 20;
            btnRunTest.Text = "Run Test";
            btnRunTest.UseVisualStyleBackColor = true;
            btnRunTest.Click += btnRunTest_Click;
            // 
            // tmrLogTest
            // 
            tmrLogTest.Interval = 5000;
            tmrLogTest.Tick += tmrLogTest_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 460);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Labworx Logger Demo";
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)pctLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTotalLogfilesToRetain).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pctLogo;
        private TextBox txtFilePath;
        private TextBox txtCustomExtension;
        private ComboBox cboLoggerRotationInterval;
        private ComboBox cboTimestampFormat;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label6;
        private TextBox txtLogFilesizeLimit;
        private CheckBox chkAutoRoute;
        private CheckBox chkDefaultExtension;
        private CheckBox chkUnlimitedFilesToRetain;
        private CheckBox chkUnlimitedFileSize;
        private Label label7;
        private TextBox txtCustomTimestampFormat;
        private NumericUpDown txtTotalLogfilesToRetain;
        private Panel panel1;
        private Label label8;
        private Panel panel2;
        private Panel panel3;
        private Button btnRunTest;
        private Button btnExit;
        private Label label9;
        private TextBox txtLogName;
        private System.Windows.Forms.Timer tmrLogTest;
    }
}
