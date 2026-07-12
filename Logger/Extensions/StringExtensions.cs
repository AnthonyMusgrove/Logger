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

        public enum CryptoFormat
        {
            PlainText,
            Hex,
            Base64
        }

        /// <summary>
        /// Converts a cryptographic key or initialization vector string into its raw byte array representation based on the specified encoding format.
        /// </summary>
        /// <remarks>
        /// This method avoids heuristic guessing to ensure cryptographic integrity. 
        /// Supported formats include:
        /// <list type="bullet">
        /// <item><description><see cref="CryptoFormat.PlainText"/>: Converts the raw string directly using UTF-8 encoding (Default).</description></item>
        /// <item><description><see cref="CryptoFormat.Hex"/>: Decodes a standard hexadecimal string (e.g., 'A1B2C3D4').</description></item>
        /// <item><description><see cref="CryptoFormat.Base64"/>: Decodes a standard Base64 encoded string (e.g., 'dGhpcy...').</description></item>
        /// </list>
        /// </remarks>
        /// <param name="input">The string representation of the cryptographic key or IV to convert.</param>
        /// <param name="format">The expected cryptographic encoding format of the input string.</param>
        /// <returns>A <see cref="T:System.Byte[]"/> containing the converted bytes, or an empty byte array if the input is null, empty, or whitespace.</returns>

        public static byte[] ToCryptographicBytes(this string? input, CryptoFormat format = CryptoFormat.PlainText)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Array.Empty<byte>();

            string trimmed = input.Trim();

            return format switch
            {
                CryptoFormat.Hex => Convert.FromHexString(trimmed),
                CryptoFormat.Base64 => Convert.FromBase64String(trimmed),
                _ => Encoding.UTF8.GetBytes(trimmed) // Default to PlainText
            };
        }


    }
}
