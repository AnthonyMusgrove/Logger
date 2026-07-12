using Labworx.Extensions;
using Labworx.Util;
using Microsoft.Extensions.Hosting.WindowsServices;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static System.Environment;

namespace Labworx
{
    /// <summary>
    /// Provides a thread-safe, high-performance, asynchronous logging engine featuring auto-routing, 
    /// cryptographic write protection (AES), diagnostic log levels, and automatic file rotation.
    /// </summary>
    public class Logger : ILogger, IDisposable
    {
        private readonly SemaphoreSlim _lockSemaphore = new SemaphoreSlim(1, 1);
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        /// <summary>
        /// Occurs when the logger completes its initialization sequence.
        /// </summary>
        public event EventHandler<LoggerEventArgs>? onInitialize;

        /// <summary>
        /// Occurs when an unhandled exception is caught during file operations or encryption routines.
        /// </summary>
        public event EventHandler<LoggerErrorEventArgs>? onError;

        /// <summary>
        /// Occurs when an active log file meets rotation criteria and gets archived.
        /// </summary>
        public event EventHandler<LoggerRolloverEventArgs>? onRollover;

        /// <summary>
        /// Occurs when a brand new target log file is physically generated on disk.
        /// </summary>
        public event EventHandler<LoggerEventArgs>? onCreateNewLogfile;

        /// <summary>
        /// Gets or sets the alphanumeric base identifier for the generated log files.
        /// </summary>
        public string LogName { get; set; } = "";

        /// <summary>
        /// Gets or sets the fully qualified directory path where active and archived logs are stored.
        /// </summary>
        public string LogFilePath { get; set; } = "";

        private bool _IsInitialised = false;
        private LoggerOptions _options = new LoggerOptions();
        private string _currentWriteFile = "";
        private bool _disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class using default configuration profiles.
        /// </summary>
        /// <param name="logName">The base file name token for the logs.</param>
        public Logger(string logName) : this(logName, new LoggerOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class with explicit configuration controls.
        /// </summary>
        /// <param name="logName">The base file name token for the logs.</param>
        /// <param name="options">The detailed behavior configuration schema to apply.</param>
        public Logger(string logName, LoggerOptions options)
        {
            LogName = logName;
            _options = options;
            _IsInitialised = _Init();

            if (_IsInitialised)
            {
                _ = StartRolloverTimerAsync(_cts.Token);
            }
        }

        /// <summary>
        /// Executes underlying environment analysis, constructs necessary directory hierarchies, and verifies file layouts.
        /// </summary>
        /// <returns><see langword="true"/> if directories are set up and target files are synchronized; otherwise, <see langword="false"/>.</returns>
        private bool _Init()
        {
            if (_IsInitialised) return true;

            if (LogName.Contains('_'))
                LogName = LogName.Replace("_", "-");

            if (_options.AutoRoute)
            {
                string appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "LabworxLogger";

                if (OperatingSystem.IsWindows())
                {
                    LogFilePath = WindowsServiceHelpers.IsWindowsService()
                        ? Path.Combine(Environment.GetFolderPath(SpecialFolder.CommonApplicationData), appName, "Logs")
                        : Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), appName, "Logs");
                }
                else if (OperatingSystem.IsAndroid())
                {
                    LogFilePath = Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile), "files", "logs");
                }
                else if (OperatingSystem.IsLinux())
                {
                    LogFilePath = Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile), appName, "Logs");
                }
                else if (OperatingSystem.IsMacOS() || OperatingSystem.IsMacCatalyst())
                {
                    LogFilePath = Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), appName, "Logs");
                }
                else
                {
                    string userProfile = Environment.GetFolderPath(SpecialFolder.UserProfile);
                    if (!string.IsNullOrEmpty(userProfile))
                    {
                        LogFilePath = Path.Combine(userProfile, appName, "Logs");
                    }
                    else
                    {
                        throw new NotImplementedException($"Logger Autoroute cannot determine best location for your log files. [OSVersion={Environment.OSVersion}] [CLR_Ver={Environment.Version}]");
                    }
                }
            }
            else
            {
                LogFilePath = _options.CustomPath;
            }

            try
            {
                Directory.CreateDirectory(LogFilePath);
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(_currentWriteFile, ex));
                return false;
            }

            _lockSemaphore.Wait();
            try
            {
                ProcessRollover();
            }
            finally
            {
                _lockSemaphore.Release();
            }

            onInitialize?.Invoke(this, new LoggerEventArgs(_currentWriteFile));
            _IsInitialised = true;

            return true;
        }

        /// <summary>
        /// Hosts the asynchronous background interval ticker responsible for scheduling routine file-age rotations.
        /// </summary>
        private async Task StartRolloverTimerAsync(CancellationToken cancellationToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
            try
            {
                while (await timer.WaitForNextTickAsync(cancellationToken))
                {
                    await _lockSemaphore.WaitAsync(cancellationToken);
                    try
                    {
                        ProcessRollover();
                    }
                    finally
                    {
                        _lockSemaphore.Release();
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        /// <summary>
        /// Evaluates active file sizing constraints and runtime time-deltas against user parameters, performing file rotation if necessary.
        /// </summary>
        /// <returns><see langword="true"/> if file modifications occurred; otherwise, <see langword="false"/>.</returns>
        private bool ProcessRollover()
        {
            var opt = _options;
            if (opt.RotationInterval == LoggerRotationInterval.Disabled &&
                opt.TotalFilesToRetain == 0 &&
                string.IsNullOrEmpty(opt.RotateOnFileSizeLimit))
            {
                return true;
            }

            string extension = string.IsNullOrEmpty(opt.CustomExtension) ? "log" : opt.CustomExtension;
            _currentWriteFile = Path.Combine(LogFilePath, $"{LogName}.{extension}");

            if (!File.Exists(_currentWriteFile))
            {
                touchNew("Initial logfile in set");
            }

            FileInfo newestLogFile = new FileInfo(_currentWriteFile);
            List<FileInfo> currentFileSet = getCurrentFileSet();
            currentFileSet.Insert(0, newestLogFile);

            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            string archiveFilename = Path.Combine(LogFilePath, $"{LogName}_{timestamp}.{extension}");

            try
            {
                // 1. File Size Verification
                if (!string.IsNullOrEmpty(opt.RotateOnFileSizeLimit))
                {
                    long maxBytes = opt.RotateOnFileSizeLimit.toLongFileSize();
                    if (newestLogFile.Length >= maxBytes)
                    {
                        File.Move(_currentWriteFile, archiveFilename);
                        touchNew(currentFileSet, $"Filesize Rotation Size> {opt.RotateOnFileSizeLimit}");
                        onRollover?.Invoke(this, new LoggerRolloverEventArgs(_currentWriteFile, LoggerRolloverEventArgs.RolloverReason.FileSizeLimitHit, archiveFilename));
                        PruneOldFiles(currentFileSet);
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
                        File.Move(_currentWriteFile, archiveFilename);
                        touchNew(currentFileSet, $"Interval Rotation Type: {opt.RotationInterval}");
                        onRollover?.Invoke(this, new LoggerRolloverEventArgs(_currentWriteFile, LoggerRolloverEventArgs.RolloverReason.RolloverIntervalHit, archiveFilename));
                        PruneOldFiles(currentFileSet);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(_currentWriteFile, ex));
            }
            return false;
        }
        /// 
        /// Discovers all existing historical log archives belonging to the current base tracking identity.
        /// 
        /// A sorted collection of tracked file profiles, descending from newest to oldest.
        private List<FileInfo> getCurrentFileSet()
        {
            string extension = string.IsNullOrEmpty(_options.CustomExtension) ? "log" : _options.CustomExtension;
            var dir = new DirectoryInfo(LogFilePath);
            if (!dir.Exists) return new List<FileInfo>();
            return dir.GetFiles($"{LogName}_*.{extension}")
            .OrderByDescending(f => f.CreationTime)
            .ToList();
        }
        /// 
        /// Generates a blank physical file payload container on disk using standalone reasoning hooks.
        /// 
        /// The descriptive source cause prompting the action block.
        private void touchNew(string reason)
        {
            var set = new List<FileInfo>();
            touchNew(set, reason);
        }
        /// 
        /// Formulates a physical file descriptor while hard-smashing OS cache handles to preserve true cross-platform timestamp integrity.
        /// 
        /// The reference array collection tracking active archives.
        /// The logging event condition driving the update request.
        private void touchNew(List<FileInfo> currentFileSet, string reason)
        {
            try
            {
                using (var fs = File.Create(_currentWriteFile)) { }
                // Explicitly resets system creation handles to crush Windows OS metadata tunneling traps
                File.SetCreationTime(_currentWriteFile, DateTime.Now);
                var fileInfo = new FileInfo(_currentWriteFile);
                currentFileSet.Insert(0, fileInfo);
                onCreateNewLogfile?.Invoke(this, new LoggerEventArgs(_currentWriteFile));
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(_currentWriteFile, ex));
            }
        }
        /// 
        /// Clears out historic structural logs if total disk trace entries exceed configured retention allocations.
        /// 
        /// The full history layout map of target files.
        private void PruneOldFiles(List<FileInfo> currentFileSet)
        {
            if (_options.TotalFilesToRetain <= 0 || currentFileSet.Count <= _options.TotalFilesToRetain)
                return;
            for (int i = _options.TotalFilesToRetain; i < currentFileSet.Count; i++)
            {
                try
                {
                    if (currentFileSet[i].Exists)
                    {
                        currentFileSet[i].Delete();
                    }
                }
                catch (Exception ex)
                {
                    onError?.Invoke(this, new LoggerErrorEventArgs(currentFileSet[i].FullName, ex));
                }
            }
        }
        #region Route Core Helpers
        /// 
        /// Centralizes runtime metadata timestamp processing and routes the finalized context packet cleanly to the appropriate disk stream layer.
        /// 
        private void LogMessage(string message)
        {
            string formatString = _options.TimeStampFormat.LoggerMeta()?.Format ?? "yyyy-MM-dd HH:mm:ss";
            string formattedLog = $"{DateTime.Now.ToString(formatString)}: {message}";
            if (_options.ProtectionMode == WriteProtectionMode.Plaintext)
            {
                WriteLine(formattedLog);
            }
            else
            {
                WriteEncryptedLine(formattedLog);
            }
        }
        /// 
        /// Asynchronously centralizes runtime metadata timestamp processing and directly targets the correct async disk output layer.
        /// 
        private Task LogMessageAsync(string message)
        {
            string formatString = _options.TimeStampFormat.LoggerMeta()?.Format ?? "yyyy-MM-dd HH:mm:ss";
            string formattedLog = $"{DateTime.Now.ToString(formatString)}: {message}";
            return _options.ProtectionMode == WriteProtectionMode.Plaintext
            ? WriteLineAsync(formattedLog)
            : WriteEncryptedLineAsync(formattedLog);
        }
        #endregion
        #region Interface Configuration Runtime Mutators
        /// 
        /// Dynmically adjustments runtime tracking rules to intercept messages targeting the defined severity threshold.
        /// 
        /// The new core logging diagnostic limit filter level.
        public void setLogLevel(LogLevel level)
        {
            _options.logLevel = level;
        }
        /// 
        /// Dynamically transitions the logging security context between text output and secure stream output configurations on-the-fly.
        /// 
        /// The target security protection standard mode to enact.
        /// The alphanumeric passphrase raw seed for encryption matrices.
        /// The initialization vector raw text component.
        public void setProtectionMode(WriteProtectionMode mode, string? aesKey = null, string? aesIV = null)
        {
            _options.ProtectionMode = mode;
            if (mode != WriteProtectionMode.Plaintext)
            {
                _options.EncryptionKey = aesKey == null
                ? Array.Empty<byte>()
                : Encoding.UTF8.GetBytes(aesKey)[..Math.Min(aesKey.Length, 32)];
                _options.EncryptionIV = aesIV == null
                ? Array.Empty<byte>()
                : Encoding.UTF8.GetBytes(aesIV)[..Math.Min(aesIV.Length, 16)];
            }
        }
        #endregion
        #region Synchronous Logging API
        /// Logs a catastrophic application state mapping error via the primary pipeline channel.
        public void Fatal(string data) { if (_options.logLevel >= LogLevel.Fatal) LogMessage($"FATAL: {data}"); }
        /// Logs a typical runtime operational fault requiring attention via the primary channel.
        public void Error(string data) { if (_options.logLevel >= LogLevel.Error) LogMessage($"ERROR: {data}"); }
        /// Logs a non-blocking suspicious development issue state warning mapping trace.
        public void Warn(string data) { if (_options.logLevel >= LogLevel.Warn) LogMessage($"WARN: {data}"); }
        /// Logs general runtime operations diagnostic checkpoints.
        public void Info(string data) { if (_options.logLevel >= LogLevel.Info) LogMessage($"INFO: {data}"); }
        /// Logs fine-grained system details useful during debugging development.
        public void Debug(string data) { if (_options.logLevel >= LogLevel.Debug) LogMessage($"DEBUG: {data}"); }
        /// Logs hyper-detailed trace elements regarding program control-flow steps.
        public void Trace(string data) { if (_options.logLevel >= LogLevel.Trace) LogMessage($"TRACE: {data}"); }
        #endregion
        #region Asynchronous Logging API
        /// Asynchronously records a catastrophic application pipeline level fault trace.
        public Task FatalAsync(string data) => _options.logLevel < LogLevel.Fatal ? Task.CompletedTask : LogMessageAsync($"FATAL: {data}");
        /// Asynchronously records a standard critical validation operational error marker.
        public Task ErrorAsync(string data) => _options.logLevel < LogLevel.Error ? Task.CompletedTask : LogMessageAsync($"ERROR: {data}");
        /// Asynchronously records a normal operational warning trace profile step.
        public Task WarnAsync(string data) => _options.logLevel < LogLevel.Warn ? Task.CompletedTask : LogMessageAsync($"WARN: {data}");
        /// Asynchronously records standard tracking milestone confirmations.
        public Task InfoAsync(string data) => _options.logLevel < LogLevel.Info ? Task.CompletedTask : LogMessageAsync($"INFO: {data}");
        /// Asynchronously records deeper internal validation engine control details.
        public Task DebugAsync(string data) => _options.logLevel < LogLevel.Debug ? Task.CompletedTask : LogMessageAsync($"DEBUG: {data}");
        /// Asynchronously records complex instruction stack execution states.
        public Task TraceAsync(string data) => _options.logLevel < LogLevel.Trace ? Task.CompletedTask : LogMessageAsync($"TRACE: {data}");
        #endregion
        #region Low-Level IO Engine
        /// 
        /// Commits standard line records directly to text files on physical media using strict semaphore protection.
        /// 
        /// The payload message string to register.
        public void WriteLine(string message)
        {
            _lockSemaphore.Wait();
            try
            {
                File.AppendAllText(_currentWriteFile, message + Environment.NewLine, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(_currentWriteFile, ex));
            }
            finally
            {
                _lockSemaphore.Release();
            }
        }
        /// 
        /// Asynchronously commits raw text line components directly to disk using async semaphore hooks.
        /// 
        /// The payload message string to register.
        public async Task WriteLineAsync(string message)
        {
            await _lockSemaphore.WaitAsync(_cts.Token);
            try
            {
                await File.AppendAllTextAsync(_currentWriteFile, message + Environment.NewLine, Encoding.UTF8, _cts.Token);
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(_currentWriteFile, ex));
            }
            finally
            {
                _lockSemaphore.Release();
            }
        }
        /// 
        /// Transforms message content via AES algorithms and appends the secure Hex representation to disk.
        /// 
        /// The string information block to protect.
        public void WriteEncryptedLine(string message)
        {
            _lockSemaphore.Wait();
            try
            {
                byte[] encryptedBytes = EncryptStringToBytes(message);
                string outText = Convert.ToHexString(encryptedBytes) + Environment.NewLine;
                File.AppendAllText(_currentWriteFile, outText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(_currentWriteFile, ex));
            }
            finally
            {
                _lockSemaphore.Release();
            }
        }
        /// 
        /// Asynchronously transforms message text into secure cryptograms, writing Hex strings to physical media.
        /// 
        /// The string information block to protect.
        public async Task WriteEncryptedLineAsync(string message)
        {
            await _lockSemaphore.WaitAsync(_cts.Token);
            try
            {
                byte[] encryptedBytes = EncryptStringToBytes(message);
                string outText = Convert.ToHexString(encryptedBytes) + Environment.NewLine;
                await File.AppendAllTextAsync(_currentWriteFile, outText, Encoding.UTF8, _cts.Token);
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(_currentWriteFile, ex));
            }
            finally
            {
                _lockSemaphore.Release();
            }
        }
        /// 
        /// Internal symmetric key encryption engine converting raw strings into cipher bytes via hardware-accelerated AES parameters.
        /// 
        private byte[] EncryptStringToBytes(string plainText)
        {
            if (_options.EncryptionKey == null || _options.EncryptionKey.Length == 0)
                return Encoding.UTF8.GetBytes(plainText);
            using Aes aes = Aes.Create();
            aes.Key = _options.EncryptionKey;
            aes.IV = _options.EncryptionIV ?? Array.Empty<byte>();
            using MemoryStream ms = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
            {
                sw.Write(plainText);
            }
            return ms.ToArray();
        }

        /// <summary>
        /// Asynchronously parses hybrid plain-text or cryptographic log files line-by-line, exposing a clean, decrypted clear text output string.
        /// </summary>
        /// <param name="filePath">The targeted file path location of the log file to analyze.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing a unified block string of cleartext data representations.</returns>
        public async Task<string> DecryptLogFileAsyncAsString(string filePath)
        {
            if (!File.Exists(filePath))
                return "Log file not found.";
            var sb = new StringBuilder();
            await _lockSemaphore.WaitAsync(_cts.Token);
            try
            {
                string[] lines = await File.ReadAllLinesAsync(filePath, Encoding.UTF8, _cts.Token);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (line.Length % 2 == 0 && System.Text.RegularExpressions.Regex.IsMatch(line, @"\A[0-9a-fA-F]+\z"))
                    {
                        try
                        {
                            byte[] cipherBytes = Convert.FromHexString(line);
                            string decryptedLine = DecryptBytesToString(cipherBytes);
                            sb.AppendLine(decryptedLine);
                        }
                        catch
                        {
                            sb.AppendLine(line);
                        }
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, new LoggerErrorEventArgs(filePath, ex));
                return $"Error reading log file: {ex.Message}";
            }
            finally
            {
                _lockSemaphore.Release();
            }
            return sb.ToString();
        }
        /// 
        /// Decrypts targeted cryptogram payloads using current live memory symmetric parameters back into clear text.
        /// 
        private string DecryptBytesToString(byte[] cipherText)
        {
            if (_options.EncryptionKey == null || _options.EncryptionKey.Length == 0)
                return Encoding.UTF8.GetString(cipherText);
            using Aes aes = Aes.Create();
            aes.Key = _options.EncryptionKey;
            aes.IV = _options.EncryptionIV ?? Array.Empty<byte>();
            using MemoryStream ms = new MemoryStream(cipherText);
            using CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader sr = new StreamReader(cs, Encoding.UTF8);
            return sr.ReadToEnd();
        }
        #endregion
        #region Disposal Infrastructure
        /// 
        /// Clears native threading constructs, cancels active interval tokens, and flushes core file streams.
        /// 
        /// if managed components should be safely recycled; otherwise, .
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _cts.Cancel();
                    _cts.Dispose();
                    _lockSemaphore.Dispose();
                }
                _disposedValue = true;
            }
        }
        /// 
        /// Releases all processing resources actively utilized by the instance context.
        /// 
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
