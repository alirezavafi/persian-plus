using System;
using System.Text.RegularExpressions;
using Persian.Plus.Extensions.Normalizer;

namespace Persian.Plus.Extensions
{
    public static class IranianMobileNumberExtensions
    {
        private static readonly Regex _matchIranianMobileNumber1 = new Regex(@"^(((98)|(\+98)|(0098)|(980)|0)?(?<mobileNo>(9){1}[0-9]{9}))+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: StringExtensions.MatchTimeout);
        private static readonly Regex _matchIranianMobileNumber2 = new Regex(@"^(9){1}[0-9]{9}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: StringExtensions.MatchTimeout);

        public static bool IsValidIranianMobileNumber(this string mobileNumber)
        {
            return !string.IsNullOrWhiteSpace(mobileNumber) &&
                (_matchIranianMobileNumber1.IsMatch(mobileNumber) || _matchIranianMobileNumber2.IsMatch(mobileNumber));
        }

        public static string CoerceIranianMobileNumber(this string mobileNumber)
        {
            if (!mobileNumber.IsValidIranianMobileNumber())
                throw new FormatException("Invalid mobile number: " + mobileNumber);
            
            var m = _matchIranianMobileNumber1.Match(mobileNumber);
            return m.Groups["mobileNo"].Value;
        }
    }
}
