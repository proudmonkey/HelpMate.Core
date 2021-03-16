using HelpMate.Core.Internals;
using System;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace HelpMate.Core.Extensions
{
    public static class TypeConverterExtension
    {
        public static DateTime ToDateTime(this string value)
            => DateTime.TryParse(value, out var result) ? result : default;

        public static DateTime? ToNullableDateTime(this string value)
            => !string.IsNullOrWhiteSpace((value ?? "").Trim()) ? value.ToDateTime() : (DateTime?) null;

        public static short ToInt16(this string value)
            => short.TryParse(value, out var result) ? result : default;

        public static short? ToNullableInt16(this string value)
            => !string.IsNullOrWhiteSpace(value) ? value.ToInt16() : (short?)null;

        public static int ToInt32(this string value)
            => int.TryParse(value, out var result) ? result : default;

        public static int? ToNullableInt32(this string value)
            => !string.IsNullOrWhiteSpace(value) ? value.ToInt32() : (int?) null;

        public static long ToInt64(this string value)
            => long.TryParse(value, out var result) ? result : default;

        public static long? ToNullableInt64(this string value)
            => !string.IsNullOrWhiteSpace(value) ? value.ToInt64() : (long?) null;

        public static byte ToByte(this string value)
          => byte.TryParse(value, out var result) ? result : default;

        public static byte? ToNullableByte(this string value)
           => !string.IsNullOrWhiteSpace(value) ? value.ToByte() : (byte?)null;

        public static bool ToBoolean(this string value)
           => bool.TryParse(value, out var result) && result;

        public static bool? ToNullableBoolean(this string value)
           => !string.IsNullOrWhiteSpace(value) ? value.ToBoolean() : (bool?)null;

        public static float ToFloat(this string value)
            => float.TryParse(value, out var result) ? result : default;

        public static float? ToNullableFloat(this string value)
           => !string.IsNullOrWhiteSpace(value) ? value.ToFloat() : (float?)null;

        public static decimal ToDecimal(this string value)
            => decimal.TryParse(value, out var result) ? result : default;

        public static decimal? ToNullableDecimal(this string value)
            => !string.IsNullOrWhiteSpace(value) ? value.ToDecimal() : (decimal?)null;

        public static double ToDouble(this string value)
           => double.TryParse(value, out var result) ? result : default;

        public static double? ToNullableDouble(this string value)
            => !string.IsNullOrWhiteSpace(value) ? value.ToDouble() : (double?)null;

        public static Guid ToGuid(this string value)
            => Guid.TryParse(value, out var result) ? result : default;

        public static Guid? ToNullableGuid(this string value)
            => !string.IsNullOrWhiteSpace(value) ? value.ToGuid() : (Guid?)null;

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

        public static string ToDateTimeFormat(this string date, string format, CultureInfo cultureInfo)
            => date.ToDateTime().ToString(format, cultureInfo);

        public static T ToEnum<T>(this string value, T defaultValue, bool ignoreCase = false)
            where T: struct
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            return Enum.TryParse<T>(value, ignoreCase, out var result) ? result : defaultValue;
        }

        public static string ToCamelCase(this string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 1)
            {
                return char.ToLowerInvariant(value[0]) + value.Substring(1);
            }

            return value;
        }

        public static string ToJson<T>(this T value, JsonSerializerOptions jsonOptions = null)
        {
            var defaultJsonOptions = DefaultJsonSerializationSettings.GetSerializerOptions(JsonNamingPolicy.CamelCase, true);
            return JsonSerializer.Serialize(value, jsonOptions ?? defaultJsonOptions);
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
