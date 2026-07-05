using Labworx.Extensions;
using Labworx.Util;
using System.Reflection;
using System.Text;
using static System.Environment;

namespace Labworx
{
    public class Logger
    {
        public event EventHandler<LoggerEventArgs>? onInitialize;
        public event EventHandler<LoggerErrorEventArgs>? onError;
        public event EventHandler<LoggerRolloverEventArgs>? onRollover;
        public event EventHandler<LoggerEventArgs>? onCreateNewLogfile;

        public String LogName { get; set; } = "";
        public String LogFilePath { get; set; } = "";

        private Boolean _IsInitialised = false;

        private LoggerOptions _options = new LoggerOptions();

        private string _currentWriteFile = "";

        public Logger(String LogName)
        {
            this.LogName = LogName;
            this._IsInitialised = this._Init();
        }

        public Logger(String LogName, LoggerOptions Options)
        {
            this.LogName = LogName;
            this._options = Options;
            this._IsInitialised = this._Init();
        }

        private Boolean _Init()
        {
            if (this._IsInitialised)
                return (true);

            // underscores are not allowed in log name, only dashes.  This is to do with log rolling.
            if (this.LogName.Contains('_'))
                this.LogName = this.LogName.Replace("_", "-");

            if (this._options.autoRoute)
            {
                this.LogFilePath = Environment.GetFolderPath(SpecialFolder.UserProfile) + "\\" + Assembly.GetEntryAssembly().GetName().Name + "\\Logs\\";
            }
            else
            {
                this.LogFilePath = this._options.CustomPath;
            }

            try
            {
                Directory.CreateDirectory(LogFilePath);
            }
            catch (IOException io_ex)
            {
                if (this.onError != null)
                    this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, io_ex));

                return (false);
            }
            catch (Exception ex)
            {
                if (this.onError != null)
                    this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));

                return (false);
            }

            this.ProcessRollover();

            if(this.onInitialize != null)
                this.onInitialize(this, new LoggerEventArgs(this._currentWriteFile));

            this._IsInitialised = true;

            return (true);
        }

        private void touchNew(String newFileReason = "")
        {
            try
            {
                FileStream _cf = File.Create(this._currentWriteFile);
                _cf.Close();

                File.SetCreationTime(this._currentWriteFile, DateTime.Now);

                this.WriteLine("Created new log file. [" + newFileReason + "]");

                if (this.onCreateNewLogfile != null)
                    this.onCreateNewLogfile(this, new LoggerEventArgs(this._currentWriteFile));
            }
            catch (Exception ex)
            {
                if (this.onError != null)
                    this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }

        private void touchNew(ref List<FileInfo> currentFileSet, String newFileReason = "")
        {
            try
            {
                FileStream _cf = File.Create(this._currentWriteFile);
                _cf.Close();

                File.SetCreationTime(this._currentWriteFile, DateTime.Now);
                currentFileSet.Insert(0, new FileInfo(this._currentWriteFile));

                this.WriteLine("Created new log file. [" + newFileReason + "]");

                if (this.onCreateNewLogfile != null)
                    this.onCreateNewLogfile(this, new LoggerEventArgs(this._currentWriteFile));
            }
            catch (Exception ex)
            {
                if (this.onError != null)
                    this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }

        }

        public void Write(String Data)
        {
            try
            {
                ProcessRollover();
                LoggerTimestampFormat tf = this._options.TimeStampFormat;
                File.AppendAllText(this._currentWriteFile, DateTime.Now.ToString(tf.LoggerMeta().Format) + ": " + Data, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                if (this.onError != null)
                    this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }
        }

        public void WriteLine(String Data)
        {
            this.Write(Data + Environment.NewLine);
        }

        private List<FileInfo> getCurrentFileSet()
        {
            List<FileInfo> currentFileSet = new List<FileInfo>();

            try
            {
                currentFileSet = new DirectoryInfo(this.LogFilePath)
                .GetFiles(this.LogName + "_*", SearchOption.TopDirectoryOnly)
                .OrderByDescending(f => f.CreationTime)
                .ToList();
            }
            catch (Exception ex)
            {
                if (this.onError != null)
                    this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));
            }

            return (currentFileSet);
        }

        private Boolean ProcessRollover()
        {

            if (this._options.RotationInterval == LoggerRotationInterval.Disabled && this._options.TotalFilesToRetain == 0 && (this._options.RotateOnFileSizeLimit == "" || this._options.RotateOnFileSizeLimit == null))
                return (true);

            List<FileInfo> currentFileSet = this.getCurrentFileSet();

            String logfileExtension = "log";

            if (this._options.CustomExtension != null && this._options.CustomExtension != "")
                logfileExtension = this._options.CustomExtension;

            this._currentWriteFile = this.LogFilePath + this.LogName + "." + logfileExtension;

            if (!File.Exists(this._currentWriteFile))
                this.touchNew("Initial logfile in set");

            currentFileSet.Insert(0, new FileInfo(this._currentWriteFile));

            FileInfo newest_log_file = currentFileSet.First();

            if (this._options.RotateOnFileSizeLimit != "" && this._options.RotateOnFileSizeLimit != null)
            {
                long bytes_max_size = new long().FromDescriptiveFileSize(this._options.RotateOnFileSizeLimit);

                if (newest_log_file.Length >= bytes_max_size)
                {
                    //need to roll over! Delete last file, create new one, and rename old current to the date time format.
                    try
                    {
                        String precededFilename = this.LogFilePath + @"\" + this.LogName + "_" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + "." + logfileExtension;
                        File.Move(this._currentWriteFile, precededFilename);
                        this.touchNew(ref currentFileSet, "Filesize Rotation Size> " + this._options.RotateOnFileSizeLimit);

                        if (this.onRollover != null)
                            this.onRollover(this, new LoggerRolloverEventArgs(this._currentWriteFile, LoggerRolloverEventArgs.RolloverReason.FileSizeLimitHit, precededFilename));

                    }
                    catch (Exception ex)
                    {
                        if (this.onError != null)
                            this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));

                        return (false);
                    }
                }
            }

            // End check for File Size > Configured Rotate Size
            // Check for total files to retain ..

            if ((currentFileSet.Count - 1) >= this._options.TotalFilesToRetain)
            {
                try
                {
                    String fileToDelete = currentFileSet.Last().FullName;

                    File.Delete(currentFileSet.Last().FullName);
                    currentFileSet.RemoveAt(currentFileSet.Count - 1);

                    String precededFilename = this.LogFilePath + @"\" + this.LogName + "_" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + "." + logfileExtension;

                    File.Move(this._currentWriteFile, precededFilename);
                    this.touchNew(ref currentFileSet, "Total Files Retained >= " + this._options.TotalFilesToRetain);

                    if (this.onRollover != null)
                        this.onRollover(this, new LoggerRolloverEventArgs(this._currentWriteFile, LoggerRolloverEventArgs.RolloverReason.FileCountRetainLimitHit, precededFilename));

                }
                catch (Exception ex)
                {
                    if (this.onError != null)
                        this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));

                    return (false);
                }
            }
            /* end check total files retain */

            // now check Rotation Intervals 
            if (this._options.RotationInterval != LoggerRotationInterval.Disabled)
            {
                Boolean rotationRequired = false;
                String rotationReason = "";

                switch (this._options.RotationInterval)
                {
                    case LoggerRotationInterval.Minutely:

                        if ((DateTime.Now - currentFileSet.Last().CreationTime).TotalMinutes > 1)
                            rotationRequired = true;

                        rotationReason = "Minutely Rotation";

                        break;

                    case LoggerRotationInterval.Hourly:

                        if ((DateTime.Now - currentFileSet.Last().CreationTime).TotalHours > 1)
                            rotationRequired = true;

                        rotationReason = "Hourly Rotation";

                        break;

                    case LoggerRotationInterval.Daily:

                        if ((DateTime.Now - currentFileSet.Last().CreationTime).TotalDays > 1)
                            rotationRequired = true;

                        rotationReason = "Daily Rotation";

                        break;

                    case LoggerRotationInterval.Weekly:

                        if ((DateTime.Now - currentFileSet.Last().CreationTime).TotalDays > 7)
                            rotationRequired = true;

                        rotationReason = "Weekly Rotation";

                        break;

                    case LoggerRotationInterval.Fortnightly:

                        if ((DateTime.Now - currentFileSet.Last().CreationTime).TotalDays > 14)
                            rotationRequired = true;

                        rotationReason = "Fortnightly Rotation";

                        break;

                    case LoggerRotationInterval.Monthly:

                        if ((DateTime.Now - currentFileSet.Last().CreationTime).TotalDays > (360 / 12))
                            rotationRequired = true;

                        rotationReason = "Monthly Rotation";

                        break;

                    case LoggerRotationInterval.Yearly:

                        if ((DateTime.Now - currentFileSet.Last().CreationTime).TotalDays > 365)
                            rotationRequired = true;

                        rotationReason = "Yearly Rotation";

                        break;
                }

                if (rotationRequired)
                {
                    // do rotation!
                    try
                    {
                        String precededFilename = this.LogFilePath + @"\" + this.LogName + "_" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + "." + logfileExtension;

                        File.Move(this._currentWriteFile, precededFilename);
                        this.touchNew(ref currentFileSet, rotationReason);

                        if (this.onRollover != null)
                            this.onRollover(this, new LoggerRolloverEventArgs(this._currentWriteFile, LoggerRolloverEventArgs.RolloverReason.RolloverIntervalHit, precededFilename));

                    }
                    catch (Exception ex)
                    {
                        if (this.onError != null)
                            this.onError(this, new LoggerErrorEventArgs(this._currentWriteFile, ex));

                        return (false);
                    }
                }
            }
            /* end check Rotation Intervals */

            return (true);

        }
    }
}
