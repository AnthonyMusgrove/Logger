using Labworx;
using Labworx.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoggerDemo
{
    public partial class frmEncryptedLogReader : Form
    {
        public frmEncryptedLogReader()
        {
            InitializeComponent();
        }

        private void frmEncryptedLogReader_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectLogFile_Click(object sender, EventArgs e)
        {
            DialogResult _dlg_result = this.dialogOpenLog.ShowDialog(this);

            if (_dlg_result == DialogResult.Cancel || _dlg_result == DialogResult.None || _dlg_result == DialogResult.Abort)
                return;

            this.txtLogFile.Text = this.dialogOpenLog.FileName;
        }

        private async void btnReadLogFile_Click(object sender, EventArgs e)
        {
            string validation_error_message = "";
            bool is_valid_input = true;

            if (this.txtEncryptionKey.Text.Length != 32)
            {
                validation_error_message += $"{Environment.NewLine}{Environment.NewLine}** Encryption Key needs to be 32 bytes, and must be the encryption key that was used to encrypt the log file you wish to read.";
                is_valid_input = false;
            }

            if (this.txtEncryptionIV.Text.Length != 16)
            {
                validation_error_message += $"{Environment.NewLine}{Environment.NewLine}** Encryption IV needs to be 16 bytes, and must be the encryption IV that was used to encrypt the log file you wish to read.";
                is_valid_input = false;
            }

            if (!File.Exists(this.txtLogFile.Text))
            {
                validation_error_message += $"{Environment.NewLine}{Environment.NewLine}** Logfile specified does not exist: {this.txtLogFile.Text}";
                is_valid_input = false;
            }

            if (!is_valid_input)
            {
                validation_error_message += $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}";
                MessageBox.Show($"Please correct the following: {Environment.NewLine}{Environment.NewLine}{validation_error_message}", "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var _loggerOptions = new LoggerOptions()
            {
                EncryptionKey = this.txtEncryptionKey.Text,
                EncryptionIV = this.txtEncryptionIV.Text
            };

            Logger _logger = new Logger("", _loggerOptions);

            string decrypted_log_contents = await _logger.DecryptLogFileAsyncAsString(this.txtLogFile.Text);

            this.txtLogFileContents.Text = decrypted_log_contents;
        }

        private void btnSaveUnencryptedCopy_Click(object sender, EventArgs e)
        {
            DialogResult _dlg_result = this.dialogSaveLog.ShowDialog(this);

            if (_dlg_result == DialogResult.Cancel || _dlg_result == DialogResult.None || _dlg_result == DialogResult.Abort)
                return;

            try
            {
                File.WriteAllText(this.dialogSaveLog.FileName, this.txtLogFile.Text);
                MessageBox.Show($"Successfully saved the log content to file: {this.dialogSaveLog.FileName}", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error occured trying to save file out: {ex.Message}", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
