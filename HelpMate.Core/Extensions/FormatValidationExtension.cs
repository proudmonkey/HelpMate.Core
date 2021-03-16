using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using HelpMate.Core.Internals;
using System.Text.RegularExpressions;

namespace HelpMate.Core.Extensions
{
    public static class FormatValidationExtension
    {
        public static bool IsValidEmailFormat(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return false; }

            // only return true if there is only 1 '@' character
            // and it is neither the first nor the last character
            int index = value.IndexOf('@');

            return
                index > 0 &&
                index != value.Length - 1 &&
                index == value.LastIndexOf('@');
        }

        public static bool IsValidCreditCardNumber(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return false; }

            value = value.Replace("-", "").Replace(" ", "");

            int checksum = 0;
            bool evenDigit = false;
            // http://www.beachnet.com/~hstiles/cardtype.html
            foreach (char digit in value.ToCharArray().Reverse())
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }

                int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return (checksum % 10) == 0;
        }

        public static bool IsValidPhoneNumber(this string value, int minLength = default, int maxLength = default)
        {
            value = value.Replace("+", string.Empty).TrimEnd();
            value = PhoneNumberUtility.RemoveExtension(value);

            if(minLength != default)
            {
                if(value.Length < minLength)
                {
                    return false;
                }
            }

            if (maxLength != default)
            {
                if (value.Length > maxLength)
                {
                    return false;
                }
            }

            bool digitFound = false;
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    digitFound = true;
                    break;
                }
            }

            if (!digitFound)
            {
                return false;
            }

            foreach (char c in value)
            {
                if (!(char.IsDigit(c)
                    || char.IsWhiteSpace(c)
                    || PhoneNumberUtility.AdditionalPhoneNumberCharacters.IndexOf(c) != -1))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidJson(this string json)
        {
            json = json.Trim();
            if ((json.StartsWith("{") && json.EndsWith("}")) || //For object
                (json.StartsWith("[") && json.EndsWith("]"))) //For array
            {
                try
                {
                    using var obj = JsonDocument.Parse(json);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidDateTime(this DateTime? date) 
            => date != default;

        public static bool IsValidDateTime(this DateTime date)
            => date != default;

        public static bool IsValidDateTimeString(this string date) 
            => date.ToDateTime() != default;

        public static bool IsFutureDate(this string date) 
            => date.ToDateTime() >= DateTime.Today;

        public static bool IsValidStandardDateString(this string value) 
            => DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

        public static bool IsNumber(this string value)
            => Regex.IsMatch(value, @"^\d+$");

        public static bool IsWholeNumber(this string value)
            => long.TryParse(value, out _);

        public static bool IsDecimalNumber(this string value)
            => decimal.TryParse(value, out _);

        public static bool IsBoolean(this string value)
            => bool.TryParse(value, out var _);

        public static bool IsHtml(this string value)
             => Regex.IsMatch(value, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");

        public static bool IsAlphaNumeric(this string value)
            => value.All(char.IsLetterOrDigit);

        public static bool IsAlphaNumericStrict(this string value)
            => value.All(c => (c >= 48 && c <= 57 || c >= 65 && c <= 90 || c >= 97 && c <= 122));
    }
}
