namespace LoggerDemo
{
    partial class frmEncryptedLogReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label11 = new Label();
            txtEncryptionIV = new TextBox();
            label12 = new Label();
            txtEncryptionKey = new TextBox();
            btnReadLogFile = new Button();
            label1 = new Label();
            txtLogFile = new TextBox();
            btnSelectLogFile = new Button();
            txtLogFileContents = new TextBox();
            btnClose = new Button();
            dialogOpenLog = new OpenFileDialog();
            btnSaveUnencryptedCopy = new Button();
            dialogSaveLog = new SaveFileDialog();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(12, 46);
            label11.Name = "label11";
            label11.Size = new Size(97, 17);
            label11.TabIndex = 39;
            label11.Text = "Encryption Key:";
            // 
            // txtEncryptionIV
            // 
            txtEncryptionIV.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEncryptionIV.Location = new Point(489, 43);
            txtEncryptionIV.Name = "txtEncryptionIV";
            txtEncryptionIV.PlaceholderText = "AES Encryption IV (16 Bytes)";
            txtEncryptionIV.Size = new Size(271, 29);
            txtEncryptionIV.TabIndex = 42;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(397, 48);
            label12.Name = "label12";
            label12.Size = new Size(87, 17);
            label12.TabIndex = 40;
            label12.Text = "Encryption IV:";
            // 
            // txtEncryptionKey
            // 
            txtEncryptionKey.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEncryptionKey.Location = new Point(115, 42);
            txtEncryptionKey.Name = "txtEncryptionKey";
            txtEncryptionKey.PlaceholderText = "AES Encryption Key (32 Bytes)";
            txtEncryptionKey.Size = new Size(270, 29);
            txtEncryptionKey.TabIndex = 41;
            // 
            // btnReadLogFile
            // 
            btnReadLogFile.FlatStyle = FlatStyle.Flat;
            btnReadLogFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReadLogFile.Location = new Point(12, 81);
            btnReadLogFile.Name = "btnReadLogFile";
            btnReadLogFile.Size = new Size(748, 37);
            btnReadLogFile.TabIndex = 43;
            btnReadLogFile.Text = "Read Log File";
            btnReadLogFile.UseVisualStyleBackColor = true;
            btnReadLogFile.Click += btnReadLogFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 44;
            label1.Text = "Log File:";
            // 
            // txtLogFile
            // 
            txtLogFile.Font = new Font("Consola Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogFile.Location = new Point(90, 5);
            txtLogFile.Name = "txtLogFile";
            txtLogFile.PlaceholderText = "Select browse button or type the path of the encrypted logfile here";
            txtLogFile.Size = new Size(627, 29);
            txtLogFile.TabIndex = 45;
            // 
            // btnSelectLogFile
            // 
            btnSelectLogFile.FlatStyle = FlatStyle.Flat;
            btnSelectLogFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectLogFile.Location = new Point(723, 5);
            btnSelectLogFile.Name = "btnSelectLogFile";
            btnSelectLogFile.Size = new Size(37, 32);
            btnSelectLogFile.TabIndex = 46;
            btnSelectLogFile.Text = "..";
            btnSelectLogFile.UseVisualStyleBackColor = true;
            btnSelectLogFile.Click += btnSelectLogFile_Click;
            // 
            // txtLogFileContents
            // 
            txtLogFileContents.BackColor = Color.White;
            txtLogFileContents.BorderStyle = BorderStyle.FixedSingle;
            txtLogFileContents.Font = new Font("Segoe UI", 12F);
            txtLogFileContents.Location = new Point(12, 124);
            txtLogFileContents.Multiline = true;
            txtLogFileContents.Name = "txtLogFileContents";
            txtLogFileContents.ReadOnly = true;
            txtLogFileContents.Size = new Size(748, 428);
            txtLogFileContents.TabIndex = 47;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(625, 561);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 29);
            btnClose.TabIndex = 49;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // dialogOpenLog
            // 
            dialogOpenLog.ShowHiddenFiles = true;
            // 
            // btnSaveUnencryptedCopy
            // 
            btnSaveUnencryptedCopy.FlatStyle = FlatStyle.Flat;
            btnSaveUnencryptedCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveUnencryptedCopy.Location = new Point(399, 561);
            btnSaveUnencryptedCopy.Name = "btnSaveUnencryptedCopy";
            btnSaveUnencryptedCopy.Size = new Size(210, 29);
            btnSaveUnencryptedCopy.TabIndex = 50;
            btnSaveUnencryptedCopy.Text = "Save Decrypted Data To File";
            btnSaveUnencryptedCopy.UseVisualStyleBackColor = true;
            btnSaveUnencryptedCopy.Click += btnSaveUnencryptedCopy_Click;
            // 
            // frmEncryptedLogReader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 599);
            Controls.Add(btnSaveUnencryptedCopy);
            Controls.Add(btnClose);
            Controls.Add(txtLogFileContents);
            Controls.Add(btnSelectLogFile);
            Controls.Add(txtLogFile);
            Controls.Add(label1);
            Controls.Add(btnReadLogFile);
            Controls.Add(label11);
            Controls.Add(txtEncryptionIV);
            Controls.Add(label12);
            Controls.Add(txtEncryptionKey);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEncryptedLogReader";
            Text = "Encrypted Log Reader";
            Load += frmEncryptedLogReader_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label11;
        private TextBox txtEncryptionIV;
        private Label label12;
        private TextBox txtEncryptionKey;
        private Button btnReadLogFile;
        private Label label1;
        private TextBox txtLogFile;
        private Button btnSelectLogFile;
        private TextBox txtLogFileContents;
        private Button button1;
        private Button btnClose;
        private OpenFileDialog dialogOpenLog;
        private Button btnSaveUnencryptedCopy;
        private SaveFileDialog dialogSaveLog;
    }
}