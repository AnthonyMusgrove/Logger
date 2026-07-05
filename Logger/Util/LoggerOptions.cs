using Labworx.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labworx.Util
{
    public enum LoggerRotationInterval
    {
        /// <summary>
        /// Log Files will not rotate, and logger will continue using the same file, unless File Size limit is enabled and reached
        /// </summary>
        Disabled,

        /// <summary>
        /// A new log file will be created for every day (only if logger is used in that interval).
        /// </summary>
        Daily,

        /// <summary>
        /// A new log file will be created for every hour (only if logger is used in that interval).
        /// </summary>
        Hourly,

        /// <summary>
        /// A new log file will be created for every minute (only if logger is used in that interval).
        /// </summary>
        Minutely,

        /// <summary>
        /// A new log file will be created for every week (only if logger is used in that interval).
        /// </summary>
        Weekly,

        /// <summary>
        /// A new log file will be created for every fortnight (only if logger is used in that interval).
        /// </summary>
        Fortnightly,

        /// <summary>
        /// A new log file will be created for every month (only if logger is used in that interval).
        /// </summary>
        Monthly,

        /// <summary>
        /// A new log file will be created for every year (only if logger is used in that interval).
        /// </summary>
        Yearly

    }

    public enum LoggerTimestampFormat
    {

        /// <summary>
        /// dd/MM/yyyy hh:mm tt (05/07/2026 07:42 AM) [12-hour AM/PM format]
        /// </summary>
        [LoggerTimestampFormatAttribute("dd/MM/yyyy hh:mm tt", "05/07/2026 07:42 AM", "12-hour AM/PM format")]
        DateTime12HrFormat,

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss (2021-08-04 23:58:30) [24-hour SQL standard timestamp]
        /// </summary>
        [LoggerTimestampFormatAttribute("yyyy-MM-dd HH:mm:ss", "2021-08-04 23:58:30", "24-hour SQL standard timestamp")]
        DateTime24HrFormatSQL,

        /// <summary>
        /// yyyy-MM-ddTHH:mm:ss.fffK (2021-08-04T23:58:30.999+10:00) [ISO 8601 standard with timezone offset]
        /// </summary>
        [LoggerTimestampFormatAttribute("yyyy-MM-ddTHH:mm:ss.fffK", "2021-08-04T23:58:30.999+10:00", "ISO 8601 standard with timezone offset")]
        ISO8601TZOffset,


        /// <summary>
        /// dd MMM yyyy HH:mm:ss (04 Aug 2021 23:58:30) [International/readable timestamp]
        /// </summary>
        [LoggerTimestampFormatAttribute("dd MMM yyyy HH:mm:ss", "04 Aug 2021 23:58:30", "International/readable timestamp")]
        DateTime24HrInternational,


        /// <summary>
        /// yyMMdd_HHmmss (210804_235830) [File-system safe format (colons are invalid in file names)]
        /// </summary>
        [LoggerTimestampFormatAttribute("yyMMdd_HHmmss", "210804_235830", "File-system safe format (colons are invalid in file names)")]
        FileSystemSafe,

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss zzz (2021-08-04 23:58:30 +10:00) [Full date and time with UTC offset]
        /// </summary>
        [LoggerTimestampFormatAttribute("yyyy-MM-dd HH:mm:ss zzz", "2021-08-04 23:58:30 +10:00", "Full date and time with UTC offset")]
        FullDateTimeWithUTCOffset,

        /// <summary>
        /// dd-MM-yyyy (04-08-2021) [Date Only]
        /// </summary>
        [LoggerTimestampFormatAttribute("dd-MM-yyyy", "04-08-2021", "Date Only")]
        DateOnly,

        /// <summary>
        /// HH:mm:ss (23:58:30) [Time Only with seconds]
        /// </summary>
        [LoggerTimestampFormatAttribute("HH:mm:ss", "23:58:30", "Time Only with seconds")]
        TimeOnlyWithSeconds,

        /// <summary>
        /// HH:mm (23:58) [Time Only No Seconds]
        /// </summary>
        [LoggerTimestampFormatAttribute("HH:mm", "23:58", "Time Only No Seconds")]
        TimeOnlyNoSeconds,

        /// <summary>
        /// g (4/8/2021 11:58 PM) [General date/time (short time) - based on the users System Regional Settings]
        /// </summary>
        [LoggerTimestampFormatAttribute("g", "4/8/2021 11:58 PM", "General date/time (short time) - based on the users System Regional Settings")]
        GeneralShortDateTime,

        /// <summary>
        /// G (4/8/2021 11:58:30 PM) [date/time (long time) - based on the users System Regional Settings]
        /// </summary>
        [LoggerTimestampFormatAttribute("G", "4/8/2021 11:58:30 PM", "date/time (long time) - based on the users System Regional Settings")]
        GeneralLongDateTime,

        /// <summary>
        /// (Custom Format) [must specify in CustomTimestampFormat property otherwise it will revert to default DateTime24HrFormatSQL]
        /// </summary>
        [LoggerTimestampFormatAttribute("Custom Format", "", "Use CustomFormat property")]
        Custom
    }


    public class LoggerOptions
    {
        /// <summary>
        /// Logger will automatically select the most appropriate location on the system to create the log file.  If a CustomPath is specified, this option is overriden and your CustomPath is used.
        /// If autoRoute is set to false, but no CustomPath is configured, it will revert back to autoRoute.
        /// Default:true
        /// </summary>
        public Boolean autoRoute { get; set; } = true;

        /// <summary>
        /// Logger will use this file extension for the log files, if not specified the default is .log
        /// </summary>
        public String CustomExtension { get; set; } = String.Empty;


        /// <summary>
        /// Logger will store the log file in this location.
        /// </summary>
        public String CustomPath { get; set; } = String.Empty;


        /// <summary>
        /// Logger will automatically rotate and create a new log file after this size is reached.  If empty, this is unlimited. 
        /// You can specify sizes eg:  1MB = 1 Megabyte,  500b = 500 bytes, 2gb = 2 Gigabytes.
        /// </summary>
        public String RotateOnFileSizeLimit { get; set; } = String.Empty;

        /// <summary>
        /// The total number of log files the logger will keep for this log set.  When log files rotate,
        /// and new files are created, Logger will match the filenames, count and remove the oldest ones after this limit.  Set to 0 for unlimited.
        /// </summary>
        public int TotalFilesToRetain { get; set; } = 0;


        /// <summary>
        /// How often a new log file will be created (when rotation is enabled)
        /// Default:  Disabled
        /// </summary>
        public LoggerRotationInterval RotationInterval { get; set; } = LoggerRotationInterval.Disabled;

        public LoggerTimestampFormat TimeStampFormat { get; set; } = LoggerTimestampFormat.DateTime24HrFormatSQL;
        public String CustomTimestampFormat { get; set; } = "";

        public LoggerOptions()
        {
        }

        public LoggerOptions(Boolean autoRoute = true, String CustomExtension = null, String CustomPath = null, LoggerTimestampFormat TimeStampFormat = LoggerTimestampFormat.DateTime24HrFormatSQL, String CustomTimestampFormat = null, LoggerRotationInterval RotationInterval = LoggerRotationInterval.Disabled, int TotalFilesToRetain = 0, String RotateOnFileSizeLimit = "")
        {
            this.autoRoute = autoRoute;
            this.CustomExtension = CustomExtension;
            this.CustomPath = CustomPath;
            this.TimeStampFormat = TimeStampFormat;
            this.CustomTimestampFormat = CustomTimestampFormat;

            if (this.TimeStampFormat == LoggerTimestampFormat.Custom && (this.CustomTimestampFormat == "" || this.CustomTimestampFormat == null))
                this.TimeStampFormat = LoggerTimestampFormat.DateTime24HrFormatSQL;

            if (!this.autoRoute && (this.CustomPath == null || this.CustomPath == "" || this.CustomPath == String.Empty))
                this.autoRoute = true;

            if (this.autoRoute && (this.CustomPath != null && this.CustomPath != "" && this.CustomPath != String.Empty))
                this.autoRoute = false;

            this.RotationInterval = RotationInterval;
            this.TotalFilesToRetain = TotalFilesToRetain;
            this.RotateOnFileSizeLimit = RotateOnFileSizeLimit;
        }
    }
}
