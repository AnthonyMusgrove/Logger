using Labworx.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace LoggerDemo
{
    public class DemoPreferences
    {
        public string LogName { get; set; } = string.Empty;
        public string CustomLogDir { get; set; } = string.Empty;
        public bool AutoRoute { get; set; } = true;
        public string CustomFileExtension { get; set; } = string.Empty;
        public Boolean DefaultFileExtension { get; set; } = true;
        public int LogFilesToRetain { get; set; } = 0;
        public bool UnlimitedLogFiles { get; set; } = true;
        public bool UnlimitedLogFileSize { get; set; } = true;
        public string RotateOnFileSize { get; set; } = string.Empty;
        public LoggerRotationInterval RotationInterval { get; set; } = LoggerRotationInterval.Disabled;
        public LoggerTimestampFormat TimeStampFormat { get; set; } = LoggerTimestampFormat.DateTime24HrFormatSQL;
        public String CustomTimestampFormat { get; set; } = String.Empty;
        public String encoding { get; set;  } = "utf-8";
        public String encryptionKey { get; set; } = string.Empty;
        public String encryptionIv { get; set; } = string.Empty;
        public WriteProtectionMode writeProtectionMode { get; set; } = WriteProtectionMode.Plaintext;
        public LogLevel logLevel { get; set; } = LogLevel.Info;
        public Boolean AsyncMode { get; set; } = false;

        private static readonly string FolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Assembly.GetEntryAssembly()?.GetName().Name ?? "LabworxLoggerDemo"
        );

        private static readonly string FilePath = Path.Combine(FolderPath, "userprefs.json");

        public static DemoPreferences Load()
        {
            if (!File.Exists(FilePath))
                return new DemoPreferences();

            try
            {
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<DemoPreferences>(json) ?? new DemoPreferences();
            }
            catch
            {
                return new DemoPreferences(); // default if the file is corrupted
            }
        }

        public void Save()
        {
                Directory.CreateDirectory(FolderPath); // Ensures the folder exists
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(FilePath, json);
        }
    }
}
