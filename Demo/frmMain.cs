using Labworx;
using Labworx.Extensions;
using Labworx.Util;
using System.Drawing.Imaging;
using System.Net.Security;
using System.Text;

namespace LoggerDemo
{
    public partial class frmMain : Form
    {

        private DemoPreferences _demoPreferences = new DemoPreferences();

        public frmMain()
        {
            InitializeComponent();
            this.FormClosing += FrmMain_FormClosing;
        }

        private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _demoPreferences.LogName = this.txtLogName.Text;
            _demoPreferences.CustomLogDir = this.txtFilePath.Text;
            _demoPreferences.AutoRoute = this.chkAutoRoute.Checked;
            _demoPreferences.CustomFileExtension = this.txtCustomExtension.Text;
            _demoPreferences.DefaultFileExtension = this.chkDefaultExtension.Checked;
            _demoPreferences.LogFilesToRetain = (int)this.txtTotalLogfilesToRetain.Value;
            _demoPreferences.UnlimitedLogFiles = this.chkUnlimitedFilesToRetain.Checked;
            _demoPreferences.RotationInterval = (LoggerRotationInterval?)this.cboLoggerRotationInterval.SelectedItem ?? LoggerRotationInterval.Disabled;
            _demoPreferences.TimeStampFormat = (LoggerTimestampFormat?)this.cboTimestampFormat.SelectedItem ?? LoggerTimestampFormat.DateTime24HrFormatSQL;
            _demoPreferences.CustomTimestampFormat = this.txtCustomTimestampFormat.Text;
            _demoPreferences.UnlimitedLogFileSize = this.chkUnlimitedFileSize.Checked;
            _demoPreferences.RotateOnFileSize = this.txtLogFilesizeLimit.Text;
            _demoPreferences.encoding = cboLogTextEncoding.SelectedValue?.ToString() ?? "utf-8";
            _demoPreferences.logLevel = (LogLevel?)this.cboLogLevel.SelectedItem ?? LogLevel.Info;
            _demoPreferences.writeProtectionMode = (WriteProtectionMode?)this.cboWriteProtectionMode.SelectedItem ?? WriteProtectionMode.Plaintext;
            _demoPreferences.encryptionKey = this.txtEncryptionKey.Text;
            _demoPreferences.encryptionIv = this.txtEncryptionIV.Text;
            _demoPreferences.AsyncMode = this.chkAsynchronousMode.Checked;
            _demoPreferences.Save();
        }

        private ILogger? _logger { get; set; } = null;
        private frmTestStatus? _frmTestStatus { get; set; } = null;
        private Boolean _isTestRunning { get; set; } = false;
        private Boolean _isAsyncMode { get; set; } = false;

        private string custom_path_pre_autoroute = "";
        private string custom_logfile_extension_pre_default = "";
        private decimal custom_filestoretain_pre_default = 0;
        private string custom_filesize_per_file_pre_default = "";
        private string custom_timestampformat_pre_custom = "";

        public Image SetImageOpacity(Image image, float opacity)
        {
            // Ensure opacity stays between 0.0 (transparent) and 1.0 (opaque)
            if (opacity < 0f) opacity = 0f;
            if (opacity > 1f) opacity = 1f;

            // Create a blank bitmap with the same dimensions as the original image
            Bitmap bmp = new Bitmap(image.Width, image.Height);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                // Define a ColorMatrix with the alpha scale factor
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;

                // Apply matrix settings
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Draw the modified image onto the blank bitmap
                gfx.DrawImage(image,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, image.Width, image.Height,
                    GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _demoPreferences = DemoPreferences.Load();

            this.pctLogo.BackColor = Color.Transparent;
            this.pctLogo.Image = this.pctLogo.Image is null ? null : this.SetImageOpacity(this.pctLogo.Image, 0.75f);

            this.cboLoggerRotationInterval.SelectedIndex = 0;

            this.cboTimestampFormat.DataSource = Enum.GetValues<Labworx.Util.LoggerTimestampFormat>()
                     .Select(f => f)
                     .ToList();

            this.cboLoggerRotationInterval.DataSource = Enum.GetValues<Labworx.Util.LoggerRotationInterval>()
                     .Select(f => f)
                     .ToList();

            this.cboLogTextEncoding.DataSource = Encoding.GetEncodings()
                     .Select(e => e.GetEncoding()) // Convert the info objects into actual Encoding instances
                     .ToList();

            this.cboLogLevel.DataSource = Enum.GetValues<Labworx.Util.LogLevel>()
                     .Select(f => f)
                     .ToList();

            this.cboWriteProtectionMode.DataSource = Enum.GetValues<Labworx.Util.WriteProtectionMode>()
                     .Select(f => f)
                     .ToList();

            this.cboLogTextEncoding.DisplayMember = "DisplayName";
            this.cboLogTextEncoding.ValueMember = "WebName";

            this.txtLogName.Text = _demoPreferences.LogName;
            this.chkAutoRoute.Checked = _demoPreferences.AutoRoute;
            this.txtFilePath.Text = _demoPreferences.CustomLogDir;
            this.txtCustomExtension.Text = _demoPreferences.CustomFileExtension;
            this.chkDefaultExtension.Checked = _demoPreferences.DefaultFileExtension;
            this.txtTotalLogfilesToRetain.Value = (int)_demoPreferences.LogFilesToRetain;
            this.chkUnlimitedFilesToRetain.Checked = _demoPreferences.UnlimitedLogFiles;
            this.cboLoggerRotationInterval.SelectedItem = _demoPreferences.RotationInterval;
            this.chkUnlimitedFileSize.Checked = _demoPreferences.UnlimitedLogFileSize;
            this.txtLogFilesizeLimit.Text = _demoPreferences.RotateOnFileSize;

            this.cboTimestampFormat.SelectedItem = _demoPreferences.TimeStampFormat;
            this.txtCustomTimestampFormat.Text = _demoPreferences.CustomTimestampFormat;

            cboLogTextEncoding.SelectedValue = _demoPreferences.encoding;

            this.cboLogLevel.SelectedItem = _demoPreferences.logLevel;
            this.cboWriteProtectionMode.SelectedItem = _demoPreferences.writeProtectionMode;

            this.txtEncryptionKey.Text = _demoPreferences.encryptionKey;
            this.txtEncryptionIV.Text = _demoPreferences.encryptionIv;

            this.chkAsynchronousMode.Checked = _demoPreferences.AsyncMode;

        }

        private void chkAutoRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRoute.Checked)
            {
                this.txtFilePath.Enabled = false;
                this.custom_path_pre_autoroute = this.txtFilePath.Text;
                this.txtFilePath.Clear();
                this.txtFilePath.PlaceholderText = "AutoRoute Enabled";
            }
            else
            {
                this.txtFilePath.Enabled = true;
                this.txtFilePath.Text = this.custom_path_pre_autoroute;
                this.txtFilePath.PlaceholderText = "Custom Log Directory";
            }
        }

        private void chkDefaultExtension_CheckedChanged(object sender, EventArgs e)
        {
            //custom_logfile_extension_pre_default
            if (chkDefaultExtension.Checked)
            {
                this.txtCustomExtension.Enabled = false;
                this.custom_logfile_extension_pre_default = this.txtCustomExtension.Text;
                this.txtCustomExtension.Clear();
                this.txtCustomExtension.PlaceholderText = "Default set (log)";
            }
            else
            {
                this.txtCustomExtension.Enabled = true;
                this.txtCustomExtension.Text = this.custom_logfile_extension_pre_default;
                this.txtCustomExtension.PlaceholderText = "Custom File Extension";
            }
        }

        private void chkUnlimitedFilesToRetain_CheckedChanged(object sender, EventArgs e)
        {
            //custom_filestoretain_pre_default
            if (chkUnlimitedFilesToRetain.Checked)
            {
                this.txtTotalLogfilesToRetain.Enabled = false;
                this.custom_filestoretain_pre_default = this.txtTotalLogfilesToRetain.Value;
                this.txtTotalLogfilesToRetain.Value = 0;
            }
            else
            {
                this.txtTotalLogfilesToRetain.Enabled = true;
                this.txtTotalLogfilesToRetain.Value = this.custom_filestoretain_pre_default;
            }

        }

        private void chkUnlimitedFileSize_CheckedChanged(object sender, EventArgs e)
        {
            //custom_filesize_per_file_pre_default
            if (chkUnlimitedFileSize.Checked)
            {
                this.txtLogFilesizeLimit.Enabled = false;
                this.custom_filesize_per_file_pre_default = this.txtLogFilesizeLimit.Text;
                this.txtLogFilesizeLimit.Clear();
                this.txtLogFilesizeLimit.PlaceholderText = "Unlimited";
            }
            else
            {
                this.txtLogFilesizeLimit.Enabled = true;
                this.txtLogFilesizeLimit.Text = this.custom_filesize_per_file_pre_default;
                this.txtLogFilesizeLimit.PlaceholderText = "Eg:  1MB, 1GB, 500B, 500KB, etc";
            }

        }

        private void cboTimestampFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

            //custom_timestampformat_pre_custom
            if (cboTimestampFormat.Text.StartsWith("Use CustomFormat"))
            {
                // custom format!
                this.txtCustomTimestampFormat.Enabled = true;
                this.txtCustomTimestampFormat.Text = custom_timestampformat_pre_custom;
                this.txtCustomTimestampFormat.PlaceholderText = "Custom Timestamp Format";
            }
            else
            {
                //Custom Timestamp Format
                this.txtCustomTimestampFormat.Enabled = false;
                custom_timestampformat_pre_custom = this.txtCustomTimestampFormat.Text;
                this.txtCustomTimestampFormat.Clear();
                this.txtCustomTimestampFormat.PlaceholderText = "Choose 'Use CustomFormat' above";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            if (btnRunTest.Text == "Stop Test")
            {
                this.btnRunTest.Text = "Run Test";
                this.tmrLogTest.Stop();
                this.tmrLogTest.Enabled = false;

                this._isTestRunning = false;

                if (this._frmTestStatus != null)
                    this._frmTestStatus.TestStopped();

            }
            else
            {
                if (!this.validate_inputs())
                    return;

                if (!this._isTestRunning)
                {
                    if (this._frmTestStatus == null)
                        this._frmTestStatus = new frmTestStatus();

                    LoggerOptions _loggerOptions = new LoggerOptions()
                    {
                        AutoRoute = this.chkAutoRoute.Checked,
                        CustomPath = this.chkAutoRoute.Checked ? "" : this.txtFilePath.Text,
                        CustomExtension = this.chkDefaultExtension.Checked ? "" : this.txtCustomExtension.Text,
                        TotalFilesToRetain = this.chkUnlimitedFilesToRetain.Checked ? 0 : (int)this.txtTotalLogfilesToRetain.Value,
                        RotationInterval = (LoggerRotationInterval)(this.cboLoggerRotationInterval.SelectedItem ?? LoggerRotationInterval.Disabled),
                        RotateOnFileSizeLimit = this.chkUnlimitedFileSize.Checked ? "" : this.txtLogFilesizeLimit.Text,
                        TimeStampFormat = (LoggerTimestampFormat)(this.cboTimestampFormat.SelectedItem ?? LoggerTimestampFormat.DateTime24HrFormatSQL),
                        CustomTimestampFormat = (this.cboTimestampFormat.Text.StartsWith("Use CustomFormat")) ? this.txtCustomTimestampFormat.Text : "",
                        encoding = (Encoding)(this.cboLogTextEncoding.SelectedItem ?? Encoding.UTF8),
                        EncryptionKey = this.txtEncryptionKey.Text.ToCryptographicBytes(),
                        EncryptionIV = this.txtEncryptionIV.Text.ToCryptographicBytes(),
                        logLevel = (LogLevel)(this.cboLogLevel.SelectedItem ?? LogLevel.Info),
                        ProtectionMode = (WriteProtectionMode)(this.cboWriteProtectionMode.SelectedItem ?? WriteProtectionMode.Plaintext)
                    };

                    this._isAsyncMode = this.chkAsynchronousMode.Checked;

                    this._logger = new Logger(this.txtLogName.Text, _loggerOptions);

                    this._logger.onError += _logger_onError;
                    this._logger.onRollover += _logger_onRollover;
                    this._logger.onCreateNewLogfile += _logger_onCreateNewLogfile;
                    this._logger.onInitialize += _logger_onInitialize;

                    if (!this._frmTestStatus.Visible)
                        this._frmTestStatus.Show(this);

                    this.btnRunTest.Text = "Stop Test";
                    this.tmrLogTest.Enabled = true;
                    this.tmrLogTest.Start();

                    if (this._frmTestStatus != null)
                        this._frmTestStatus.TestStarted();

                }
            }

        }

        private void _logger_onInitialize(object? sender, LoggerEventArgs e)
        {
            if (this._frmTestStatus != null)
                this._frmTestStatus.addToTestOutput("Logger Initialised Successfully: " + e.LogFile);
        }

        private void _logger_onCreateNewLogfile(object? sender, LoggerEventArgs e)
        {
            if (this._frmTestStatus != null)
                this._frmTestStatus.addToTestOutput("Created New Logfile: " + e.LogFile);
        }

        private void _logger_onRollover(object? sender, LoggerRolloverEventArgs e)
        {
            if (this._frmTestStatus != null)
                this._frmTestStatus.addToTestOutput("Log Rollover: " + e.LogFile + " because: " + e.Reason.ToString() + ", last file: " + e.Precedes);
        }

        private void _logger_onError(object? sender, LoggerErrorEventArgs e)
        {
            if (this._frmTestStatus != null)
                this._frmTestStatus.addToTestOutput("Logger Error: " + e.LogFile + " because: " + e.innerException.Message);
        }

        private Boolean validate_inputs()
        {
            string validation_message = "Please enter valid input for the following: " + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            Boolean is_valid = true;

            if (this.txtLogName.Text.Trim() == "")
            {
                validation_message += "** Log Name - the name of the log set." + Environment.NewLine + Environment.NewLine;
                is_valid = false;
            }

            if (this.txtFilePath.Text.Trim() == "" && !this.chkAutoRoute.Checked)
            {
                validation_message += "** Custom Log Directory - If you do not wish to specify this, check the 'AutoRoute' option" + Environment.NewLine + Environment.NewLine;
                is_valid = false;
            }

            if (this.txtCustomExtension.Text.Trim() == "" && !this.chkDefaultExtension.Checked)
            {
                validation_message += "** Custom File Extension - If you do not wish to specify this, check the 'Default (.log)' option" + Environment.NewLine + Environment.NewLine;
                is_valid = false;
            }

            if (this.txtLogFilesizeLimit.Text.Trim() == "" && !this.chkUnlimitedFileSize.Checked)
            {
                validation_message += "** Filesize Limit per log file in set - If you do not wish to specify this, check the 'Unlimited' option" + Environment.NewLine + Environment.NewLine;
                is_valid = false;
            }

            if (this.txtCustomTimestampFormat.Text.Trim() == "" && this.cboTimestampFormat.Text.StartsWith("Use CustomFormat"))
            {
                validation_message += "** Custom Timestamp Format - If you do not wish to specify this, select an option other than Custom Format" + Environment.NewLine + Environment.NewLine;
                is_valid = false;
            }

            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(txtEncryptionKey.Text);
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(txtEncryptionIV.Text);

            if (keyBytes.Length < 32)
            {
                validation_message += "** Encryption is enabled, but a valid 32-byte encryption key hasn't been specified (Detected: " + keyBytes.Length + " bytes)" + Environment.NewLine + Environment.NewLine;
                is_valid = false;
            }

            if (ivBytes.Length < 16)
            {
                validation_message += "** Encryption is enabled, but a valid 16-byte encryption IV hasn't been specified (Detected: " + ivBytes.Length + " bytes)" + Environment.NewLine + Environment.NewLine;
                is_valid = false;
            }

            validation_message += Environment.NewLine;

            if (!is_valid)
                MessageBox.Show(validation_message, "Please check options:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return (is_valid);
        }

        private void tmrLogTest_Tick(object sender, EventArgs e)
        {
            // write to the log file
            if (_logger != null && _frmTestStatus != null)
            {
                string text = LoremIpsumGenerator.GenerateWords(40);

                if (_isAsyncMode) _ = _logger.InfoAsync(text);
                else _logger.Info(text);
            }
            else
            {
                _frmTestStatus?.addToTestOutput("Test stopped prematurely, isTestRunning or logger not initialised.");

                btnRunTest.Text = "Run Test";
                tmrLogTest.Stop();
                tmrLogTest.Enabled = false;

                _frmTestStatus?.TestStopped();
            }
        }

        public Boolean isTestRunning()
        {
            return this.tmrLogTest.Enabled;
        }

        public ILogger? getLoggerInstance()
        {
            return (this._logger);
        }

        public void StopTest()
        {
            this.btnRunTest.Text = "Run Test";
            this.tmrLogTest.Stop();
            this.tmrLogTest.Enabled = false;

            if (this._frmTestStatus != null)
                this._frmTestStatus.addToTestOutput("Test stopped as requested by user.");

            if (this._frmTestStatus != null)
                this._frmTestStatus.TestStopped();
        }

        private void btnOpenEncryptedLogFileReader_Click(object sender, EventArgs e)
        {
            frmEncryptedLogReader _encrypedLogReaderForm = new frmEncryptedLogReader();
            _encrypedLogReaderForm.ShowDialog(this);
        }
    }
}
