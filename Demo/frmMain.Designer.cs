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
            label10 = new Label();
            cboLogTextEncoding = new ComboBox();
            label9 = new Label();
            txtLogName = new TextBox();
            btnExit = new Button();
            btnRunTest = new Button();
            tmrLogTest = new System.Windows.Forms.Timer(components);
            label12 = new Label();
            txtEncryptionIV = new TextBox();
            btnOpenEncryptedLogFileReader = new Button();
            label11 = new Label();
            txtEncryptionKey = new TextBox();
            label13 = new Label();
            cboWriteProtectionMode = new ComboBox();
            label14 = new Label();
            cboLogLevel = new ComboBox();
            chkAsynchronousMode = new CheckBox();
            tabsMain = new TabControl();
            tabGeneral = new TabPage();
            tabAdvanced = new TabPage();
            tabAbout = new TabPage();
            label16 = new Label();
            ((System.ComponentModel.ISupportInitialize)pctLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTotalLogfilesToRetain).BeginInit();
            panel1.SuspendLayout();
            tabsMain.SuspendLayout();
            tabGeneral.SuspendLayout();
            tabAdvanced.SuspendLayout();
            tabAbout.SuspendLayout();
            SuspendLayout();
            // 
            // pctLogo
            // 
            pctLogo.Image = Properties.Resources.LoggerIcon;
            pctLogo.Location = new Point(12, 13);
            pctLogo.Name = "pctLogo";
            pctLogo.Size = new Size(333, 385);
            pctLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pctLogo.TabIndex = 0;
            pctLogo.TabStop = false;
            // 
            // txtFilePath
            // 
            txtFilePath.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilePath.Location = new Point(168, 57);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "Custom Log Directory";
            txtFilePath.Size = new Size(266, 29);
            txtFilePath.TabIndex = 2;
            // 
            // txtTotalLogfilesToRetain
            // 
            txtTotalLogfilesToRetain.Font = new Font("Consola Mono", 12F);
            txtTotalLogfilesToRetain.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtTotalLogfilesToRetain.Location = new Point(262, 18);
            txtTotalLogfilesToRetain.Name = "txtTotalLogfilesToRetain";
            txtTotalLogfilesToRetain.Size = new Size(191, 29);
            txtTotalLogfilesToRetain.TabIndex = 4;
            // 
            // txtCustomTimestampFormat
            // 
            txtCustomTimestampFormat.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomTimestampFormat.Location = new Point(200, 180);
            txtCustomTimestampFormat.Name = "txtCustomTimestampFormat";
            txtCustomTimestampFormat.PlaceholderText = "Custom Timestamp Format";
            txtCustomTimestampFormat.Size = new Size(354, 29);
            txtCustomTimestampFormat.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Consola Mono", 12F);
            label7.Location = new Point(58, 183);
            label7.Name = "label7";
            label7.Size = new Size(136, 22);
            label7.TabIndex = 18;
            label7.Text = "Custom Format:";
            // 
            // chkUnlimitedFileSize
            // 
            chkUnlimitedFileSize.AutoSize = true;
            chkUnlimitedFileSize.Font = new Font("Consola Mono", 12F);
            chkUnlimitedFileSize.Location = new Point(467, 111);
            chkUnlimitedFileSize.Name = "chkUnlimitedFileSize";
            chkUnlimitedFileSize.Size = new Size(110, 26);
            chkUnlimitedFileSize.TabIndex = 17;
            chkUnlimitedFileSize.Text = "Unlimited";
            chkUnlimitedFileSize.UseVisualStyleBackColor = true;
            chkUnlimitedFileSize.CheckedChanged += chkUnlimitedFileSize_CheckedChanged;
            // 
            // chkUnlimitedFilesToRetain
            // 
            chkUnlimitedFilesToRetain.AutoSize = true;
            chkUnlimitedFilesToRetain.Font = new Font("Consola Mono", 12F);
            chkUnlimitedFilesToRetain.Location = new Point(467, 19);
            chkUnlimitedFilesToRetain.Name = "chkUnlimitedFilesToRetain";
            chkUnlimitedFilesToRetain.Size = new Size(110, 26);
            chkUnlimitedFilesToRetain.TabIndex = 16;
            chkUnlimitedFilesToRetain.Text = "Unlimited";
            chkUnlimitedFilesToRetain.UseVisualStyleBackColor = true;
            chkUnlimitedFilesToRetain.CheckedChanged += chkUnlimitedFilesToRetain_CheckedChanged;
            // 
            // chkDefaultExtension
            // 
            chkDefaultExtension.AutoSize = true;
            chkDefaultExtension.Font = new Font("Consola Mono", 12F);
            chkDefaultExtension.ForeColor = Color.Black;
            chkDefaultExtension.Location = new Point(409, 97);
            chkDefaultExtension.Name = "chkDefaultExtension";
            chkDefaultExtension.Size = new Size(155, 26);
            chkDefaultExtension.TabIndex = 15;
            chkDefaultExtension.Text = "Default (.log)";
            chkDefaultExtension.UseVisualStyleBackColor = true;
            chkDefaultExtension.CheckedChanged += chkDefaultExtension_CheckedChanged;
            // 
            // chkAutoRoute
            // 
            chkAutoRoute.AutoSize = true;
            chkAutoRoute.Font = new Font("Consola Mono", 12F);
            chkAutoRoute.Location = new Point(452, 60);
            chkAutoRoute.Name = "chkAutoRoute";
            chkAutoRoute.Size = new Size(110, 26);
            chkAutoRoute.TabIndex = 14;
            chkAutoRoute.Text = "AutoRoute";
            chkAutoRoute.UseVisualStyleBackColor = true;
            chkAutoRoute.CheckedChanged += chkAutoRoute_CheckedChanged;
            // 
            // txtLogFilesizeLimit
            // 
            txtLogFilesizeLimit.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogFilesizeLimit.Location = new Point(207, 109);
            txtLogFilesizeLimit.Name = "txtLogFilesizeLimit";
            txtLogFilesizeLimit.PlaceholderText = "Eg:  1MB, 1GB, 500B, 500KB, etc";
            txtLogFilesizeLimit.Size = new Size(246, 29);
            txtLogFilesizeLimit.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Consola Mono", 12F);
            label6.Location = new Point(20, 112);
            label6.Name = "label6";
            label6.Size = new Size(181, 22);
            label6.TabIndex = 12;
            label6.Text = "Log Filesize Limit:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consola Mono", 12F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(31, 139);
            label5.Name = "label5";
            label5.Size = new Size(163, 22);
            label5.TabIndex = 11;
            label5.Text = "Timestamp Format:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Consola Mono", 12F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(80, 65);
            label4.Name = "label4";
            label4.Size = new Size(172, 22);
            label4.TabIndex = 10;
            label4.Text = "Rotation Interval:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consola Mono", 12F);
            label3.Location = new Point(17, 22);
            label3.Name = "label3";
            label3.Size = new Size(235, 22);
            label3.TabIndex = 9;
            label3.Text = "Total Logfiles To Retain:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consola Mono", 12F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(31, 100);
            label2.Name = "label2";
            label2.Size = new Size(208, 22);
            label2.TabIndex = 8;
            label2.Text = "Custom File Extension:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consola Mono", 12F);
            label1.Location = new Point(31, 61);
            label1.Name = "label1";
            label1.Size = new Size(109, 22);
            label1.TabIndex = 7;
            label1.Text = "Custom Dir:";
            // 
            // cboTimestampFormat
            // 
            cboTimestampFormat.DropDownHeight = 200;
            cboTimestampFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimestampFormat.DropDownWidth = 300;
            cboTimestampFormat.Font = new Font("Consola Mono", 12F);
            cboTimestampFormat.FormattingEnabled = true;
            cboTimestampFormat.IntegralHeight = false;
            cboTimestampFormat.ItemHeight = 22;
            cboTimestampFormat.Location = new Point(200, 136);
            cboTimestampFormat.Name = "cboTimestampFormat";
            cboTimestampFormat.Size = new Size(354, 30);
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
            cboLoggerRotationInterval.Location = new Point(262, 62);
            cboLoggerRotationInterval.Name = "cboLoggerRotationInterval";
            cboLoggerRotationInterval.Size = new Size(315, 30);
            cboLoggerRotationInterval.TabIndex = 5;
            // 
            // txtCustomExtension
            // 
            txtCustomExtension.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomExtension.Location = new Point(245, 97);
            txtCustomExtension.Name = "txtCustomExtension";
            txtCustomExtension.PlaceholderText = "Custom File Extension";
            txtCustomExtension.Size = new Size(145, 29);
            txtCustomExtension.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 454);
            panel1.Name = "panel1";
            panel1.Size = new Size(962, 27);
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
            label8.Size = new Size(962, 27);
            label8.TabIndex = 8;
            label8.Text = "Labworx Logger, developed by Anthony Musgrove (anthony@labworx.au)";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Consola Mono", 12F);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(22, 227);
            label10.Name = "label10";
            label10.Size = new Size(172, 22);
            label10.TabIndex = 25;
            label10.Text = "Log Text Encoding:";
            // 
            // cboLogTextEncoding
            // 
            cboLogTextEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLogTextEncoding.DropDownWidth = 300;
            cboLogTextEncoding.Font = new Font("Consola Mono", 12F);
            cboLogTextEncoding.FormattingEnabled = true;
            cboLogTextEncoding.ItemHeight = 22;
            cboLogTextEncoding.Items.AddRange(new object[] { "Disabled", "Hourly", "Minutely", "Daily", "Weekly", "Fortnightly", "Monthly", "Yearly" });
            cboLogTextEncoding.Location = new Point(200, 225);
            cboLogTextEncoding.Name = "cboLogTextEncoding";
            cboLogTextEncoding.Size = new Size(354, 30);
            cboLogTextEncoding.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Consola Mono", 12F);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(50, 20);
            label9.Name = "label9";
            label9.Size = new Size(91, 22);
            label9.TabIndex = 22;
            label9.Text = "Log Name:";
            // 
            // txtLogName
            // 
            txtLogName.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogName.Location = new Point(168, 17);
            txtLogName.Name = "txtLogName";
            txtLogName.PlaceholderText = "Log Name (eg 'Test')";
            txtLogName.Size = new Size(349, 29);
            txtLogName.TabIndex = 23;
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(857, 411);
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
            btnRunTest.Location = new Point(776, 411);
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
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Consola Mono", 12F);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(92, 261);
            label12.Name = "label12";
            label12.Size = new Size(136, 22);
            label12.TabIndex = 27;
            label12.Text = "Encryption IV:";
            // 
            // txtEncryptionIV
            // 
            txtEncryptionIV.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEncryptionIV.Location = new Point(244, 258);
            txtEncryptionIV.Name = "txtEncryptionIV";
            txtEncryptionIV.PlaceholderText = "AES Encryption IV (16 Bytes)";
            txtEncryptionIV.Size = new Size(333, 29);
            txtEncryptionIV.TabIndex = 38;
            // 
            // btnOpenEncryptedLogFileReader
            // 
            btnOpenEncryptedLogFileReader.FlatStyle = FlatStyle.Flat;
            btnOpenEncryptedLogFileReader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenEncryptedLogFileReader.Location = new Point(372, 411);
            btnOpenEncryptedLogFileReader.Name = "btnOpenEncryptedLogFileReader";
            btnOpenEncryptedLogFileReader.Size = new Size(199, 32);
            btnOpenEncryptedLogFileReader.TabIndex = 38;
            btnOpenEncryptedLogFileReader.Text = "Read an Encrypted Log File ...";
            btnOpenEncryptedLogFileReader.UseVisualStyleBackColor = true;
            btnOpenEncryptedLogFileReader.Click += btnOpenEncryptedLogFileReader_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Consola Mono", 12F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(83, 209);
            label11.Name = "label11";
            label11.Size = new Size(145, 22);
            label11.TabIndex = 26;
            label11.Text = "Encryption Key:";
            // 
            // txtEncryptionKey
            // 
            txtEncryptionKey.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEncryptionKey.Location = new Point(245, 206);
            txtEncryptionKey.Name = "txtEncryptionKey";
            txtEncryptionKey.PlaceholderText = "AES Encryption Key (32 Bytes)";
            txtEncryptionKey.Size = new Size(332, 29);
            txtEncryptionKey.TabIndex = 37;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Consola Mono", 12F);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(20, 161);
            label13.Name = "label13";
            label13.Size = new Size(208, 22);
            label13.TabIndex = 40;
            label13.Text = "Write Protection Mode:";
            // 
            // cboWriteProtectionMode
            // 
            cboWriteProtectionMode.DropDownHeight = 200;
            cboWriteProtectionMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWriteProtectionMode.DropDownWidth = 300;
            cboWriteProtectionMode.Font = new Font("Consola Mono", 12F);
            cboWriteProtectionMode.FormattingEnabled = true;
            cboWriteProtectionMode.IntegralHeight = false;
            cboWriteProtectionMode.ItemHeight = 22;
            cboWriteProtectionMode.Location = new Point(244, 158);
            cboWriteProtectionMode.Name = "cboWriteProtectionMode";
            cboWriteProtectionMode.Size = new Size(333, 30);
            cboWriteProtectionMode.TabIndex = 39;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Consola Mono", 12F);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(53, 273);
            label14.Name = "label14";
            label14.Size = new Size(100, 22);
            label14.TabIndex = 42;
            label14.Text = "Log Level:";
            // 
            // cboLogLevel
            // 
            cboLogLevel.DropDownHeight = 200;
            cboLogLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLogLevel.DropDownWidth = 300;
            cboLogLevel.Font = new Font("Consola Mono", 12F);
            cboLogLevel.FormattingEnabled = true;
            cboLogLevel.IntegralHeight = false;
            cboLogLevel.ItemHeight = 22;
            cboLogLevel.Location = new Point(200, 266);
            cboLogLevel.Name = "cboLogLevel";
            cboLogLevel.Size = new Size(235, 30);
            cboLogLevel.TabIndex = 41;
            // 
            // chkAsynchronousMode
            // 
            chkAsynchronousMode.AutoSize = true;
            chkAsynchronousMode.Font = new Font("Consola Mono", 12F);
            chkAsynchronousMode.Location = new Point(207, 311);
            chkAsynchronousMode.Name = "chkAsynchronousMode";
            chkAsynchronousMode.Size = new Size(209, 26);
            chkAsynchronousMode.TabIndex = 43;
            chkAsynchronousMode.Text = "Asynchronous Logging";
            chkAsynchronousMode.UseVisualStyleBackColor = true;
            // 
            // tabsMain
            // 
            tabsMain.Controls.Add(tabGeneral);
            tabsMain.Controls.Add(tabAdvanced);
            tabsMain.Controls.Add(tabAbout);
            tabsMain.Font = new Font("Consola Mono", 12F);
            tabsMain.Location = new Point(351, 11);
            tabsMain.Name = "tabsMain";
            tabsMain.SelectedIndex = 0;
            tabsMain.Size = new Size(604, 392);
            tabsMain.TabIndex = 44;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(txtLogName);
            tabGeneral.Controls.Add(label9);
            tabGeneral.Controls.Add(txtFilePath);
            tabGeneral.Controls.Add(label14);
            tabGeneral.Controls.Add(label1);
            tabGeneral.Controls.Add(cboLogLevel);
            tabGeneral.Controls.Add(chkAutoRoute);
            tabGeneral.Controls.Add(label2);
            tabGeneral.Controls.Add(txtCustomExtension);
            tabGeneral.Controls.Add(chkDefaultExtension);
            tabGeneral.Controls.Add(cboTimestampFormat);
            tabGeneral.Controls.Add(txtCustomTimestampFormat);
            tabGeneral.Controls.Add(label5);
            tabGeneral.Controls.Add(label10);
            tabGeneral.Controls.Add(label7);
            tabGeneral.Controls.Add(cboLogTextEncoding);
            tabGeneral.Location = new Point(4, 31);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(3);
            tabGeneral.Size = new Size(596, 357);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "General";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabAdvanced
            // 
            tabAdvanced.Controls.Add(txtTotalLogfilesToRetain);
            tabAdvanced.Controls.Add(label3);
            tabAdvanced.Controls.Add(txtEncryptionIV);
            tabAdvanced.Controls.Add(chkAsynchronousMode);
            tabAdvanced.Controls.Add(label12);
            tabAdvanced.Controls.Add(chkUnlimitedFilesToRetain);
            tabAdvanced.Controls.Add(txtEncryptionKey);
            tabAdvanced.Controls.Add(label13);
            tabAdvanced.Controls.Add(cboLoggerRotationInterval);
            tabAdvanced.Controls.Add(label11);
            tabAdvanced.Controls.Add(cboWriteProtectionMode);
            tabAdvanced.Controls.Add(label4);
            tabAdvanced.Controls.Add(txtLogFilesizeLimit);
            tabAdvanced.Controls.Add(label6);
            tabAdvanced.Controls.Add(chkUnlimitedFileSize);
            tabAdvanced.Location = new Point(4, 31);
            tabAdvanced.Name = "tabAdvanced";
            tabAdvanced.Size = new Size(596, 357);
            tabAdvanced.TabIndex = 3;
            tabAdvanced.Text = "Advanced";
            tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // tabAbout
            // 
            tabAbout.Controls.Add(label16);
            tabAbout.Location = new Point(4, 31);
            tabAbout.Name = "tabAbout";
            tabAbout.Size = new Size(596, 357);
            tabAbout.TabIndex = 2;
            tabAbout.Text = "About";
            tabAbout.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.Font = new Font("Consola Mono", 12F);
            label16.Location = new Point(17, 14);
            label16.Name = "label16";
            label16.Size = new Size(560, 326);
            label16.TabIndex = 12;
            label16.Text = resources.GetString("label16.Text");
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 481);
            Controls.Add(pctLogo);
            Controls.Add(tabsMain);
            Controls.Add(btnExit);
            Controls.Add(btnRunTest);
            Controls.Add(btnOpenEncryptedLogFileReader);
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
            tabsMain.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            tabGeneral.PerformLayout();
            tabAdvanced.ResumeLayout(false);
            tabAdvanced.PerformLayout();
            tabAbout.ResumeLayout(false);
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
        private Button btnRunTest;
        private Button btnExit;
        private Label label9;
        private TextBox txtLogName;
        private System.Windows.Forms.Timer tmrLogTest;
        private ComboBox cboLogTextEncoding;
        private Label label10;
        private TextBox txtEncryptionIV;
        private Label label12;
        private Button btnOpenEncryptedLogFileReader;
        private TextBox txtEncryptionKey;
        private Label label11;
        private Label label13;
        private ComboBox cboWriteProtectionMode;
        private Label label14;
        private ComboBox cboLogLevel;
        private CheckBox chkAsynchronousMode;
        private TabControl tabsMain;
        private TabPage tabGeneral;
        private TabPage tabEncryption;
        private TabPage tabAbout;
        private TabPage tabAdvanced;
        private Label label16;
    }
}
