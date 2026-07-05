# Logger

> A lightweight, high-performance C# file logging library with automatic log rotation, retention management, and flexible timestamp formatting.

![Logger Screenshot](https://raw.githubusercontent.com/AnthonyMusgrove/Logger/refs/heads/main/Screenshot.png)

---

## Overview

**Logger** is a simple yet powerful file logging library for .NET applications.

It was designed to make writing log files effortless while providing the features needed for production environments, including automatic log rotation, file size limits, retention policies, and configurable timestamp formats.

Whether you're building a console application, Windows Service, ASP.NET application, desktop software, or background worker, Logger provides an easy-to-use API without unnecessary complexity.

---

## Features

- ✅ Simple, clean API
- ✅ Automatic log file creation
- ✅ Automatic log directory routing
- ✅ Custom log directory support
- ✅ Custom file extension support
- ✅ Log rotation by:
  - Minute
  - Hour
  - Day
  - Week
  - Fortnight
  - Month
  - Year
- ✅ Log rotation by file size
- ✅ Automatic cleanup of old log files
- ✅ Configurable log retention limits
- ✅ Multiple built-in timestamp formats
- ✅ Custom timestamp formatting
- ✅ Lightweight
- ✅ No external dependencies
- ✅ Suitable for desktop, server and embedded applications

---

# Installation

## NuGet


```bash
dotnet add package labworx.logger 
```

or

```powershell
Install-Package labworx.logger
```

---

# Quick Start

```csharp
using Labworx;

var logger = new Logger(logName, LogOptions);

logger.WriteLine("Application Started");
logger.WriteLine("Loading configuration...");
logger.WriteLine("Finished.");
```

---

# Configuration

Logger can be configured using the `LoggerOptions` class.

```csharp
String logName = "MyAppLogins";

var options = new LoggerOptions
{
    autoRoute = true,
    RotationInterval = LoggerRotationInterval.Daily,
    RotateOnFileSizeLimit = "25MB",
    TotalFilesToRetain = 30,
    TimeStampFormat = LoggerTimestampFormat.DateTime24HrFormatSQL
};

var logger = new Logger(logName, options);
```

---

# LoggerOptions

| Property | Description |
|-----------|-------------|
| `autoRoute` | Automatically selects the best log location on the system. |
| `CustomPath` | Specify your own directory for log files. |
| `CustomExtension` | Change the default `.log` extension. |
| `RotateOnFileSizeLimit` | Rotate when a file reaches a specified size (e.g. `10MB`, `500KB`, `2GB`). |
| `RotationInterval` | Time-based log rotation interval. |
| `TotalFilesToRetain` | Maximum number of log files to retain. `0` = Unlimited. |
| `TimeStampFormat` | Select one of the built-in timestamp formats. |
| `CustomTimestampFormat` | Custom .NET DateTime format string when using `Custom`. |

---

# Rotation Intervals

Logger supports automatic time-based rotation.

| Interval | Description |
|----------|-------------|
| Disabled | No time-based rotation |
| Minutely | New log every minute |
| Hourly | New log every hour |
| Daily | New log every day |
| Weekly | New log every week |
| Fortnightly | New log every two weeks |
| Monthly | New log every month |
| Yearly | New log every year |

---

# File Size Rotation

Logger can automatically create a new log file when a file reaches a specified size.

Examples:

```text
500B
100KB
5MB
250MB
2GB
```

Size-based rotation works alongside time-based rotation.

---

# File Retention

Prevent log folders from growing indefinitely.

```csharp
TotalFilesToRetain = 20;
```

Once the configured limit is reached:

- Oldest log files are automatically deleted
- New log files continue to be created
- Rotation continues seamlessly

Set to:

```csharp
0
```

for unlimited retention.

---

# Timestamp Formats

Logger includes numerous built-in timestamp formats.

Examples include:

| Format | Example |
|---------|---------|
| SQL 24 Hour | `2026-07-05 19:42:18` |
| ISO 8601 | `2026-07-05T19:42:18.123+10:00` |
| International | `05 Jul 2026 19:42:18` |
| File Safe | `260705_194218` |
| Date Only | `05-07-2026` |
| Time Only | `19:42:18` |
| 12 Hour | `05/07/2026 07:42 PM` |
| Custom | Any .NET DateTime format |

Example:

```csharp
var options = new LoggerOptions
{
    TimeStampFormat = LoggerTimestampFormat.Custom,
    CustomTimestampFormat = "dddd dd MMMM yyyy HH:mm:ss"
};
```

---

# Automatic Log Routing

When `autoRoute` is enabled, Logger automatically selects an appropriate writable location on the operating system.

If a custom path is supplied, Logger will automatically use that location instead.

```csharp
autoRoute = true;
```

or

```csharp
CustomPath = @"C:\Logs";
```

---

# Example Configuration

```csharp
var options = new LoggerOptions(
    autoRoute: true,
    RotationInterval: LoggerRotationInterval.Daily,
    TotalFilesToRetain: 14,
    RotateOnFileSizeLimit: "50MB",
    TimeStampFormat: LoggerTimestampFormat.ISO8601TZOffset
);

var logger = new Logger(options);
```

---

# Planned Features

- Async logging

---

# Contributing

Contributions, feature requests, bug reports and pull requests are always welcome.

If you have an idea that would improve Logger, feel free to open an Issue or submit a Pull Request.

---

# License

This project is licensed under the GPL V3.0 License.

---

Created with ❤️ for the .NET community.
