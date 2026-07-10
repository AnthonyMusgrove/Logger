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
            btnOpenEncryptedLogFileReader = new Button();
            chkEncrypt = new CheckBox();
            panel11 = new Panel();
            txtEncryptionKey = new TextBox();
            label11 = new Label();
            panel12 = new Panel();
            txtEncryptionIV = new TextBox();
            label12 = new Label();
            panel13 = new Panel();
            panel14 = new Panel();
            label10 = new Label();
            cboLogTextEncoding = new ComboBox();
            panel9 = new Panel();
            panel10 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            label9 = new Label();
            txtLogName = new TextBox();
            btnExit = new Button();
            btnRunTest = new Button();
            tmrLogTest = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pctLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTotalLogfilesToRetain).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
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
            txtFilePath.Location = new Point(109, 5);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "Custom Log Directory";
            txtFilePath.Size = new Size(244, 29);
            txtFilePath.TabIndex = 2;
            // 
            // txtTotalLogfilesToRetain
            // 
            txtTotalLogfilesToRetain.Font = new Font("Consola Mono", 12F);
            txtTotalLogfilesToRetain.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtTotalLogfilesToRetain.Location = new Point(166, 6);
            txtTotalLogfilesToRetain.Name = "txtTotalLogfilesToRetain";
            txtTotalLogfilesToRetain.Size = new Size(191, 29);
            txtTotalLogfilesToRetain.TabIndex = 4;
            // 
            // txtCustomTimestampFormat
            // 
            txtCustomTimestampFormat.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomTimestampFormat.Location = new Point(161, 5);
            txtCustomTimestampFormat.Name = "txtCustomTimestampFormat";
            txtCustomTimestampFormat.PlaceholderText = "Custom Timestamp Format";
            txtCustomTimestampFormat.Size = new Size(302, 29);
            txtCustomTimestampFormat.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(58, 10);
            label7.Name = "label7";
            label7.Size = new Size(100, 17);
            label7.TabIndex = 18;
            label7.Text = "Custom Format:";
            // 
            // chkUnlimitedFileSize
            // 
            chkUnlimitedFileSize.AutoSize = true;
            chkUnlimitedFileSize.Font = new Font("Segoe UI", 9.75F);
            chkUnlimitedFileSize.Location = new Point(383, 10);
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
            chkUnlimitedFilesToRetain.Location = new Point(363, 9);
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
            chkDefaultExtension.ForeColor = Color.Black;
            chkDefaultExtension.Location = new Point(363, 10);
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
            chkAutoRoute.Location = new Point(363, 9);
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
            txtLogFilesizeLimit.Location = new Point(166, 4);
            txtLogFilesizeLimit.Name = "txtLogFilesizeLimit";
            txtLogFilesizeLimit.PlaceholderText = "Eg:  1MB, 1GB, 500B, 500KB, etc";
            txtLogFilesizeLimit.Size = new Size(211, 29);
            txtLogFilesizeLimit.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(48, 10);
            label6.Name = "label6";
            label6.Size = new Size(109, 17);
            label6.TabIndex = 12;
            label6.Text = "Log Filesize Limit:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(37, 11);
            label5.Name = "label5";
            label5.Size = new Size(120, 17);
            label5.TabIndex = 11;
            label5.Text = "Timestamp Format:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(48, 10);
            label4.Name = "label4";
            label4.Size = new Size(106, 17);
            label4.TabIndex = 10;
            label4.Text = "Rotation Interval:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(6, 13);
            label3.Name = "label3";
            label3.Size = new Size(146, 17);
            label3.TabIndex = 9;
            label3.Text = "Total Logfiles To Retain:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(15, 10);
            label2.Name = "label2";
            label2.Size = new Size(137, 17);
            label2.TabIndex = 8;
            label2.Text = "Custom File Extension:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(3, 10);
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
            cboTimestampFormat.Location = new Point(162, 4);
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
            cboLoggerRotationInterval.Location = new Point(166, 4);
            cboLoggerRotationInterval.Name = "cboLoggerRotationInterval";
            cboLoggerRotationInterval.Size = new Size(298, 30);
            cboLoggerRotationInterval.TabIndex = 5;
            // 
            // txtCustomExtension
            // 
            txtCustomExtension.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomExtension.Location = new Point(166, 6);
            txtCustomExtension.Name = "txtCustomExtension";
            txtCustomExtension.PlaceholderText = "Custom File Extension";
            txtCustomExtension.Size = new Size(187, 29);
            txtCustomExtension.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 489);
            panel1.Name = "panel1";
            panel1.Size = new Size(841, 27);
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
            label8.Size = new Size(841, 27);
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
            panel2.Size = new Size(370, 489);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnOpenEncryptedLogFileReader);
            panel3.Controls.Add(chkEncrypt);
            panel3.Controls.Add(panel11);
            panel3.Controls.Add(panel12);
            panel3.Controls.Add(panel13);
            panel3.Controls.Add(panel14);
            panel3.Controls.Add(panel9);
            panel3.Controls.Add(panel10);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(btnExit);
            panel3.Controls.Add(btnRunTest);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(370, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(471, 489);
            panel3.TabIndex = 6;
            // 
            // btnOpenEncryptedLogFileReader
            // 
            btnOpenEncryptedLogFileReader.FlatStyle = FlatStyle.Flat;
            btnOpenEncryptedLogFileReader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenEncryptedLogFileReader.Location = new Point(14, 446);
            btnOpenEncryptedLogFileReader.Name = "btnOpenEncryptedLogFileReader";
            btnOpenEncryptedLogFileReader.Size = new Size(199, 32);
            btnOpenEncryptedLogFileReader.TabIndex = 38;
            btnOpenEncryptedLogFileReader.Text = "Read an Encrypted Log File ...";
            btnOpenEncryptedLogFileReader.UseVisualStyleBackColor = true;
            btnOpenEncryptedLogFileReader.Click += btnOpenEncryptedLogFileReader_Click;
            // 
            // chkEncrypt
            // 
            chkEncrypt.Font = new Font("Segoe UI", 9.75F);
            chkEncrypt.Location = new Point(394, 365);
            chkEncrypt.Name = "chkEncrypt";
            chkEncrypt.Size = new Size(71, 70);
            chkEncrypt.TabIndex = 37;
            chkEncrypt.Text = "Encrypt Log";
            chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(173, 210, 252);
            panel11.Controls.Add(txtEncryptionKey);
            panel11.Controls.Add(label11);
            panel11.Location = new Point(0, 360);
            panel11.Name = "panel11";
            panel11.Size = new Size(388, 40);
            panel11.TabIndex = 36;
            // 
            // txtEncryptionKey
            // 
            txtEncryptionKey.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEncryptionKey.Location = new Point(107, 6);
            txtEncryptionKey.Name = "txtEncryptionKey";
            txtEncryptionKey.PlaceholderText = "AES Encryption Key (32 Bytes)";
            txtEncryptionKey.Size = new Size(270, 29);
            txtEncryptionKey.TabIndex = 37;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(7, 10);
            label11.Name = "label11";
            label11.Size = new Size(97, 17);
            label11.TabIndex = 26;
            label11.Text = "Encryption Key:";
            // 
            // panel12
            // 
            panel12.BackColor = Color.Transparent;
            panel12.Controls.Add(txtEncryptionIV);
            panel12.Controls.Add(label12);
            panel12.Location = new Point(0, 400);
            panel12.Name = "panel12";
            panel12.Size = new Size(388, 40);
            panel12.TabIndex = 35;
            // 
            // txtEncryptionIV
            // 
            txtEncryptionIV.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEncryptionIV.Location = new Point(106, 6);
            txtEncryptionIV.Name = "txtEncryptionIV";
            txtEncryptionIV.PlaceholderText = "AES Encryption IV (16 Bytes)";
            txtEncryptionIV.Size = new Size(271, 29);
            txtEncryptionIV.TabIndex = 38;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(8, 11);
            label12.Name = "label12";
            label12.Size = new Size(87, 17);
            label12.TabIndex = 27;
            label12.Text = "Encryption IV:";
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(173, 210, 252);
            panel13.Controls.Add(label7);
            panel13.Controls.Add(txtCustomTimestampFormat);
            panel13.Location = new Point(0, 280);
            panel13.Name = "panel13";
            panel13.Size = new Size(470, 40);
            panel13.TabIndex = 34;
            // 
            // panel14
            // 
            panel14.BackColor = Color.Transparent;
            panel14.Controls.Add(label10);
            panel14.Controls.Add(cboLogTextEncoding);
            panel14.Location = new Point(0, 320);
            panel14.Name = "panel14";
            panel14.Size = new Size(470, 40);
            panel14.TabIndex = 33;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(40, 9);
            label10.Name = "label10";
            label10.Size = new Size(118, 17);
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
            cboLogTextEncoding.Location = new Point(161, 3);
            cboLogTextEncoding.Name = "cboLogTextEncoding";
            cboLogTextEncoding.Size = new Size(302, 30);
            cboLogTextEncoding.TabIndex = 24;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(173, 210, 252);
            panel9.Controls.Add(label6);
            panel9.Controls.Add(chkUnlimitedFileSize);
            panel9.Controls.Add(txtLogFilesizeLimit);
            panel9.Location = new Point(0, 200);
            panel9.Name = "panel9";
            panel9.Size = new Size(470, 40);
            panel9.TabIndex = 32;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Transparent;
            panel10.Controls.Add(label5);
            panel10.Controls.Add(cboTimestampFormat);
            panel10.Location = new Point(0, 240);
            panel10.Name = "panel10";
            panel10.Size = new Size(470, 40);
            panel10.TabIndex = 31;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(173, 210, 252);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(chkUnlimitedFilesToRetain);
            panel7.Controls.Add(txtTotalLogfilesToRetain);
            panel7.Location = new Point(0, 120);
            panel7.Name = "panel7";
            panel7.Size = new Size(470, 40);
            panel7.TabIndex = 30;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Transparent;
            panel8.Controls.Add(label4);
            panel8.Controls.Add(cboLoggerRotationInterval);
            panel8.Location = new Point(0, 160);
            panel8.Name = "panel8";
            panel8.Size = new Size(470, 40);
            panel8.TabIndex = 29;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(173, 210, 252);
            panel6.Controls.Add(label1);
            panel6.Controls.Add(txtFilePath);
            panel6.Controls.Add(chkAutoRoute);
            panel6.Location = new Point(0, 40);
            panel6.Name = "panel6";
            panel6.Size = new Size(470, 40);
            panel6.TabIndex = 28;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(label2);
            panel5.Controls.Add(chkDefaultExtension);
            panel5.Controls.Add(txtCustomExtension);
            panel5.Location = new Point(0, 80);
            panel5.Name = "panel5";
            panel5.Size = new Size(470, 40);
            panel5.TabIndex = 27;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(label9);
            panel4.Controls.Add(txtLogName);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(470, 40);
            panel4.TabIndex = 26;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(17, 11);
            label9.Name = "label9";
            label9.Size = new Size(72, 17);
            label9.TabIndex = 22;
            label9.Text = "Log Name:";
            // 
            // txtLogName
            // 
            txtLogName.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogName.Location = new Point(109, 5);
            txtLogName.Name = "txtLogName";
            txtLogName.PlaceholderText = "Log Name (eg 'Test')";
            txtLogName.Size = new Size(302, 29);
            txtLogName.TabIndex = 23;
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(390, 446);
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
            btnRunTest.Location = new Point(309, 446);
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
            ClientSize = new Size(841, 516);
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
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private ComboBox cboLogTextEncoding;
        private Label label10;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Label label11;
        private Label label12;
        private TextBox txtEncryptionKey;
        private TextBox txtEncryptionIV;
        private CheckBox chkEncrypt;
        private Button btnOpenEncryptedLogFileReader;
    }
}
