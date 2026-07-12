using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Labworx.Extensions
{

    [AttributeUsage(AttributeTargets.Field)]
    public class LoggerTimestampFormatAttribute : Attribute
    {
        public String Format { get; set; }
        public String Example { get; set; }
        public String Description { get; set; }

        public LoggerTimestampFormatAttribute(String Format, String Example, String Description)
        {
            this.Format = Format;
            this.Example = Example;
            this.Description = Description;
        }
    }

    public static class EnumMetaExtensions
    {
        public static LoggerTimestampFormatAttribute? LoggerMeta(this Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());
            return field?.GetCustomAttribute<LoggerTimestampFormatAttribute>();
        }
    }
}
