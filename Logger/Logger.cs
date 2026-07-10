using Labworx.Extensions;
using Labworx.Util;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static System.Environment;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Labworx
{
    public class Logger : IDisposable
    {
        private readonly object _lockObject = new object();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public event EventHandler<LoggerEventArgs>? onInitialize;
        public event EventHandler<LoggerErrorEventArgs>? onError;
        public event EventHandler<LoggerRolloverEventArgs>? onRollover;
        public event EventHandler<LoggerEventArgs>? onCreateNewLogfile;

        public string LogName { get; set; } = "";
        public string LogFilePath { get; set; } = "";

        private bool _IsInitialised = false;
        private LoggerOptions _options = new LoggerOptions();
        private string _currentWriteFile = "";
        private bool disposedValue;

        // Both constructors now properly chain together to ensure the timer starts
        public Logger(string logName) : this(logName, new LoggerOptions())
        {
        }

        public Logger(string logName, LoggerOptions options)
        {
            this.LogName = logName;
            this._options = options;
            this._IsInitialised = this._Init();

            if (this._IsInitialised)
            {
                _ = StartRolloverTimerAsync(_cts.Token);
            }
        }

        private bool _Init()
        {
            if (this._IsInitialised) return true;

            if (this.LogName.Contains('_'))
                this.LogName = this.LogName.Replace("_", "-");

            if (this._options.AutoRoute)
            {
                string appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "LabworxLogger";

                if (OperatingSystem.IsWindows())
                {
                    this.LogFilePath = WindowsServiceHelpers.IsWindowsService()
                        ? Path.Combine(Environment.GetFolderPath(SpecialFolder.CommonApplicationData), appName, "Logs")
                        : Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), appName, "Logs");
                }
                else if (OperatingSystem.IsAndroid())
                {
                    this.LogFilePath = Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile), "files", "logs");
                }
                else if (OperatingSystem.IsLinux())
                {
                    this.LogFilePath = Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile), appName, "Logs");
                }
                else if (OperatingSystem.IsMacOS() || OperatingSystem.IsMacCatalyst())
                {
                    this.LogFilePath = Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), appName, "Logs");
                }
                else
                {
                    string userProfile = Environment.GetFolderPath(SpecialFolder.UserProfile);
                    if (!string.IsNullOrEmpty(userProfile))
                    {
                        this.LogFilePath = Path.Combine(userProfile, appName, "Logs");
                    }
                    else
                    {
                        throw new NotImplementedException($"Logger Autoroute cannot determine best location for your log files. [OSVersion={Environment.OSVersion}] [CLR_Ver={Environment.Version}]");
                    }
                }
            }
            else
            {
                this.LogFilePath = this._options.CustomPath;
            }

            try
            {
                Directory.CreateDirectory(LogFilePath);
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
                return false;
            }

            lock (_lockObject)
            {
                this.ProcessRollover();
            }

            this.onInitialize?.Invoke(this, new LoggerEventArgs(this._currentWriteFile));
            this._IsInitialised = true;

            return true;
        }

        private async Task StartRolloverTimerAsync(CancellationToken cancellationToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
            try
            {
                while (await timer.WaitForNextTickAsync(cancellationToken))
                {
                    lock (_lockObject)
                    {
                        this.ProcessRollover();
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        private bool ProcessRollover()
        {
            var opt = this._options;
            if (opt.RotationInterval == LoggerRotationInterval.Disabled &&
                opt.TotalFilesToRetain == 0 &&
                string.IsNullOrEmpty(opt.RotateOnFileSizeLimit))
            {
                return true;
            }

            string extension = string.IsNullOrEmpty(opt.CustomExtension) ? "log" : opt.CustomExtension;
            this._currentWriteFile = Path.Combine(this.LogFilePath, $"{this.LogName}.{extension}");

            if (!File.Exists(this._currentWriteFile))
            {
                this.touchNew("Initial logfile in set");
            }

            FileInfo newestLogFile = new FileInfo(this._currentWriteFile);
            List<FileInfo> currentFileSet = this.getCurrentFileSet();
            currentFileSet.Insert(0, newestLogFile);

            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            string archiveFilename = Path.Combine(this.LogFilePath, $"{this.LogName}_{timestamp}.{extension}");

            try
            {
                // 1. File Size Verification
                if (!string.IsNullOrEmpty(opt.RotateOnFileSizeLimit))
                {
                    long maxBytes = opt.RotateOnFileSizeLimit.toLongFileSize();
                    if (newestLogFile.Length >= maxBytes)
                    {
                        File.Move(this._currentWriteFile, archiveFilename);
                        this.touchNew(ref currentFileSet, $"Filesize Rotation Size> {opt.RotateOnFileSizeLimit}");
                        this.onRollover?.Invoke(this, new LoggerRolloverEventArgs(this._currentWriteFile, LoggerRolloverEventArgs.RolloverReason.FileSizeLimitHit, archiveFilename));
                        return true;
                    }
                }

                // 2. Interval Verification
                if (opt.RotationInterval != LoggerRotationInterval.Disabled)
                {
                    TimeSpan age = DateTime.Now - newestLogFile.CreationTime;
                    bool rotationRequired = opt.RotationInterval switch
                    {
                        LoggerRotationInterval.Minutely => age.TotalMinutes > 1,
                        LoggerRotationInterval.Hourly => age.TotalHours > 1,
                        LoggerRotationInterval.Daily => age.TotalDays > 1,
                        LoggerRotationInterval.Weekly => age.TotalDays > 7,
                        LoggerRotationInterval.Fortnightly => age.TotalDays > 14,
                        LoggerRotationInterval.Monthly => age.TotalDays > 30.41,
                        LoggerRotationInterval.Yearly => age.TotalDays > 365,
                        _ => false
                    };

                    if (rotationRequired)
                    {
                        File.Move(this._currentWriteFile, archiveFilename);
                        this.touchNew(ref currentFileSet, $"{opt.RotationInterval} Rotation");
                        this.onRollover?.Invoke(this, new LoggerRolloverEventArgs(this._currentWriteFile, LoggerRolloverEventArgs.RolloverReason.RolloverIntervalHit, archiveFilename));
                        return true;
                    }
                }

                // 3. File Set Pruning
                if (opt.TotalFilesToRetain > 0 && currentFileSet.Count > opt.TotalFilesToRetain)
                {
                    while (currentFileSet.Count > opt.TotalFilesToRetain)
                    {
                        FileInfo oldestFile = currentFileSet.Last();
                        if (File.Exists(oldestFile.FullName))
                        {
                            File.Delete(oldestFile.FullName);
                        }
                        currentFileSet.RemoveAt(currentFileSet.Count - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
                return false;
            }

            return true;
        }

        private void touchNew(string newFileReason = "")
        {
            try
            {
                using (File.Create(this._currentWriteFile)) { }
                File.SetCreationTime(this._currentWriteFile, DateTime.Now);

//                File.AppendAllText(this._currentWriteFile, $"{DateTime.Now}: Created new log file. [{newFileReason}]{Environment.NewLine}");
                this.onCreateNewLogfile?.Invoke(this, new LoggerEventArgs(this._currentWriteFile));
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }


        private void touchNew(ref List<FileInfo> currentFileSet, string newFileReason = "")
        {
            try
            {
                using (File.Create(this._currentWriteFile)) { }
                File.SetCreationTime(this._currentWriteFile, DateTime.Now);
                currentFileSet.Insert(0, new FileInfo(this._currentWriteFile));
//                File.AppendAllText(this._currentWriteFile, $"{DateTime.Now}: Created new log file. [{newFileReason}]{Environment.NewLine}");
                this.onCreateNewLogfile?.Invoke(this, new LoggerEventArgs(this._currentWriteFile));
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }
        public async Task WriteAsync(string Data)
        {
            try
            {
                LoggerTimestampFormat tf = this._options.TimeStampFormat;
                string formattedLog = $"{DateTime.Now.ToString(tf.LoggerMeta().Format)}: {Data}";
                string targetFile;
                lock (_lockObject)
                {
                    targetFile = this._currentWriteFile;
                }
                await File.AppendAllTextAsync(targetFile, formattedLog, this._options.encoding);
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }
        public async Task WriteLineAsync(string Data)
        {
            await this.WriteAsync($"{Data}{Environment.NewLine}");
        }

        public void Write(string Data)
        {
            try
            {
                LoggerTimestampFormat tf = this._options.TimeStampFormat;
                string formattedLog = $"{DateTime.Now.ToString(tf.LoggerMeta().Format)}: {Data}";
                string targetFile;
                lock (_lockObject)
                {
                    targetFile = this._currentWriteFile;
                }
                File.AppendAllText(targetFile, formattedLog, this._options.encoding);
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }
        public void WriteLine(string Data)
        {
            this.Write($"{Data}{Environment.NewLine}");
        }
        private List<FileInfo> getCurrentFileSet()
        {
            string extension = string.IsNullOrEmpty(_options.CustomExtension) ? "log" : _options.CustomExtension;
            var di = new DirectoryInfo(this.LogFilePath);
            if (!di.Exists) return new List<FileInfo>();
            return di.GetFiles($"{this.LogName}_*.{extension}")
            .OrderByDescending(f => f.CreationTime)
            .ToList();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _cts.Cancel();
                    _cts.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        private string EncryptLine(string plainText)
        {
            if (string.IsNullOrEmpty(this._options.EncryptionKey) || this._options.EncryptionKey.Length < 32 ||
                string.IsNullOrEmpty(this._options.EncryptionIV) || this._options.EncryptionIV.Length < 16)
            {
                return plainText;
            }

            string safeKeyStr = this._options.EncryptionKey.Substring(0, 32);
            string safeIvStr = this._options.EncryptionIV.Substring(0, 16);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(safeKeyStr);
                aes.IV = Encoding.UTF8.GetBytes(safeIvStr);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public async Task DecryptLogFileAsync(string encryptedFilePath, string destinationPlainFilePath)
        {
            if (!File.Exists(encryptedFilePath))
                throw new FileNotFoundException("Target encrypted log file not found.", encryptedFilePath);

            using (StreamReader reader = new StreamReader(encryptedFilePath, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(destinationPlainFilePath, false, Encoding.UTF8))
            {
                string? encryptedLine;
                while ((encryptedLine = await reader.ReadLineAsync()) != null)
                {
                    if (string.IsNullOrWhiteSpace(encryptedLine)) continue;

                    string decryptedLine = this.DecryptLine(encryptedLine, this._options.EncryptionKey, this._options.EncryptionIV);

                    await writer.WriteAsync(decryptedLine);
                }
            }
        }

        public async Task<string> DecryptLogFileAsyncAsString(string encryptedFilePath)
        {
            if (!File.Exists(encryptedFilePath))
                throw new FileNotFoundException("Target encrypted log file not found.", encryptedFilePath);

            string decrypted_logfile = string.Empty;

            using (StreamReader reader = new StreamReader(encryptedFilePath, Encoding.UTF8))
            {
                string? encryptedLine;
                while ((encryptedLine = await reader.ReadLineAsync()) != null)
                {
                    if (string.IsNullOrWhiteSpace(encryptedLine)) continue;

                    decrypted_logfile += DecryptLine(encryptedLine, this._options.EncryptionKey, this._options.EncryptionIV);
                }
            }

            return (decrypted_logfile);
        }

        public string DecryptLine(string cipherText, string encryptionKey, string encryptionIV)
        {
            if (string.IsNullOrWhiteSpace(cipherText)) {
                return string.Empty; 
            }

            if (string.IsNullOrEmpty(this._options.EncryptionKey) || this._options.EncryptionKey.Length < 32 ||
            string.IsNullOrEmpty(this._options.EncryptionIV) || this._options.EncryptionIV.Length < 16)
            {
            }

            string safeKeyStr = this._options.EncryptionKey.Substring(0, 32);
            string safeIvStr = this._options.EncryptionIV.Substring(0, 16);

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(safeKeyStr);
                    aes.IV = Encoding.UTF8.GetBytes(safeIvStr);

                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText.Trim())))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Returns an indicator or throws if the line is corrupted or tampered with
                return "[CORRUPTED OR INVALID LOG LINE]";
            }
        }

        public async Task WriteEncryptedLineAsync(string Data)
        {
            try
            {
                LoggerTimestampFormat tf = this._options.TimeStampFormat;

                string formattedLog = $"{DateTime.Now.ToString(tf.LoggerMeta().Format)}: {Data}{Environment.NewLine}";

                string encryptedLine = EncryptLine(formattedLog) + Environment.NewLine;
                string targetFile;

                lock (_lockObject)
                {
                    targetFile = this._currentWriteFile;
                }

                await File.AppendAllTextAsync(targetFile, encryptedLine, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }

        public void WriteEncryptedLine(string Data)
        {
            try
            {
                LoggerTimestampFormat tf = this._options.TimeStampFormat;
                string formattedLog = $"{DateTime.Now.ToString(tf.LoggerMeta().Format)}: {Data}{Environment.NewLine}";

                string encryptedLine = EncryptLine(formattedLog) + Environment.NewLine;
                string targetFile;

                lock (_lockObject)
                {
                    targetFile = this._currentWriteFile;
                }

                File.AppendAllText(targetFile, encryptedLine, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                this.onError?.Invoke(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }

    }
}
