using Labworx.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labworx
{
    public interface ILogger
    {
        event EventHandler<LoggerEventArgs>? onInitialize;
        event EventHandler<LoggerErrorEventArgs>? onError;
        event EventHandler<LoggerRolloverEventArgs>? onRollover;
        event EventHandler<LoggerEventArgs>? onCreateNewLogfile;

        void setLogLevel(LogLevel logLevel = LogLevel.Info);
        void setProtectionMode(WriteProtectionMode ProtectionMode, String AesKey = "", String AesIV = "");
        Task<string> DecryptLogFileAsyncAsString(string filePath);
        void Fatal(String Data);
        void Error(String Data);
        void Warn(String Data);
        void Info(String Data);
        void Debug(String Data);
        void Trace(String Data);

        Task FatalAsync(String Data);
        Task ErrorAsync(String Data);
        Task WarnAsync(String Data);
        Task InfoAsync(String Data);
        Task DebugAsync(String Data);
        Task TraceAsync(String Data);
    }
}
