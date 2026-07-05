using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Labworx.Util
{
    public class LoggerEventArgs : EventArgs
    {
        public String LogFile { get; } 

        public LoggerEventArgs(String logFile)
        {
            LogFile = logFile;
        }

    }

    public class LoggerErrorEventArgs : LoggerEventArgs
    {

        public Exception innerException { get; }

        // call base constructor to provide required logFile argument
        public LoggerErrorEventArgs(String LogFile, Exception innerException) : base(LogFile)
        {
            this.innerException = innerException;
        }
    }


    public class LoggerRolloverEventArgs : LoggerEventArgs
    {

        public enum RolloverReason
        {
            FileSizeLimitHit,
            FileCountRetainLimitHit,
            RolloverIntervalHit,
        }

        public RolloverReason Reason { get; }

        public String Precedes { get; }

        // call base constructor to provide required logFile argument
        public LoggerRolloverEventArgs(String LogFile, RolloverReason Reason, String Precedes) : base(LogFile)
        {
            this.Precedes = Precedes;
            this.Reason = Reason;
        }
    }

}
