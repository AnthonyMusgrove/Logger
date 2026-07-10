using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Labworx.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Converts a human-readable descriptive filesize string to its equivalent in bytes. 
        /// </summary>
        /// <remarks>
        /// Some examples are '2 MB', '500 GB',  '3MB',  '2B',  '5TB'.  
        /// </remarks>
        /// <returns>The filesize converted into bytes, as a long integer.</returns>
        /// <param name="FileSize">The string representation of the filesize to convert.  If you do not specify a unit measurement, this parameter will be treated as bytes.</param>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="FileSize"/> is null or empty.</exception>
        /// <exception cref="System.FormatException">Thrown when <paramref name="FileSize"/> doesn't specify a valid string-representation of a filesize</exception>
        /// <exception cref="System.FormatException">Thrown when <paramref name="FileSize"/> doesn't specify a valid unit of measurement (B, KB, MB, GB, TB, PB) </exception>
        public static long toLongFileSize(this string FileSize)
        {
            if (string.IsNullOrWhiteSpace(FileSize))
                throw new ArgumentException("File size string cannot be null or empty.");

            // Extract numbers (including decimals) and letters cleanly
            var match = Regex.Match(FileSize.Trim(), @"^([\d\.]+)\s*([a-zA-Z]*)$");
            if (!match.Success)
                throw new FormatException("Invalid file size format.");

            double value = double.Parse(match.Groups[1].Value);
            string unit = match.Groups[2].Value.ToUpper();

            // Calculate bytes based on the binary unit standard (1024)
            return unit switch
            {
                "" or "B" or "BYTES" => (long)value,
                "KB" or "K" => (long)(value * 1024),
                "MB" or "M" => (long)(value * Math.Pow(1024, 2)),
                "GB" or "G" => (long)(value * Math.Pow(1024, 3)),
                "TB" or "T" => (long)(value * Math.Pow(1024, 4)),
                "PB" or "P" => (long)(value * Math.Pow(1024, 5)),
                _ => throw new FormatException($"Unsupported size unit: '{unit}'")
            };
        }


    }
}
