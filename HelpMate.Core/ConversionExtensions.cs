using System;
using System.Globalization;
using System.Text;

namespace HelpMate.Core
{
    public static class TypeConverterExtensions
    {
        public static DateTime ToDateTime(this string value)
            => DateTime.TryParse(value, out var result) ? result : default;

        public static DateTime? ToNullableDateTime(this string value)
            => !string.IsNullOrEmpty((value ?? "").Trim()) ? value.ToDateTime() : (DateTime?) null;

        public static short ToInt16(this string value)
            => short.TryParse(value, out var result) ? result : default;

        public static int ToInt32(this string value)
            => int.TryParse(value, out var result) ? result : default;

        public static int? ToNullableInt32(this string value)
            => !string.IsNullOrEmpty(value) ? value.ToInt32() : (int?) null;

        public static long ToInt64(this string value)
            => long.TryParse(value, out var result) ? result : default;

        public static long? ToNullableInt64(this string value)
            => !string.IsNullOrEmpty(value) ? value.ToInt64() : (long?) null;

        public static bool ToBoolean(this string value)
            => bool.TryParse(value, out var result) ? result : default;

        public static float ToFloat(this string value)
            => float.TryParse(value, out var result) ? result : default;

        public static decimal ToDecimal(this string value)
            => decimal.TryParse(value, out var result) ? result : default;

        public static double ToDouble(this string value)
           => double.TryParse(value, out var result) ? result : default;

        public static string ToBase64Encode(this string value) 
           => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

        public static string ToBase64Encode(this byte[] value) 
            => Convert.ToBase64String(value);

        public static string ToBase64Decode(this string value) 
            => Encoding.UTF8.GetString(Convert.FromBase64String(value));

        public static byte[] ToByteFromBase64CharArray(this string value) 
            => Convert.FromBase64CharArray(value.ToCharArray(), 0, value.Length);

        public static byte[] ToByteArray(this string value) 
            => Convert.FromBase64String(value);

        public static string ToDateTimeFormat(this string date, string format) 
            => date.ToDateTime().ToString(format, CultureInfo.InvariantCulture);

        public static string ToCamelCase(this string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 1)
            {
                return char.ToLowerInvariant(value[0]) + value.Substring(1);
            }

            return value;
        }

        public static int GetYearsFromDate(this DateTime date)
        {
            var now = DateTime.UtcNow;
            int years = now.Year - date.Year;

            if ((date.Month > now.Month) || (date.Month == now.Month && date.Day > now.Day))
                years--;

            return years;
        }

        public static int GetYearsDifference(this DateTime date, DateTime dateToCompare)
        {
            int years = dateToCompare.Year - date.Year;

            if ((date.Month > dateToCompare.Month) || (date.Month == dateToCompare.Month && date.Day > dateToCompare.Day))
                years--;

            return years;
        }
    }
}
