using System;
using System.Text.RegularExpressions;
using Persian.Plus.Extensions.Normalizer;

namespace Persian.Plus.Extensions
{
    public static class IranianMobileNumberExtensions
    {
        private static readonly Regex _matchIranianMobileNumber1 = new Regex(@"^(((98)|(\+98)|(0098)|(980)|0)?(?<mobileNo>(9){1}[0-9]{9}))+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex _matchIranianMobileNumber2 = new Regex(@"^(9){1}[0-9]{9}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

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
            return '0' + m.Groups["mobileNo"].Value;
        }
        
        public static string MaskIranianMobileNumber(this string mobileNumber, bool inverse = false)
        {
            if (!mobileNumber.IsValidIranianMobileNumber())
                throw new FormatException("Invalid mobile number: " + mobileNumber);
            mobileNumber = mobileNumber.CoerceIranianMobileNumber();
            if (inverse)
                return mobileNumber.Substring(9) + "****" + mobileNumber.Substring(0, 6);
            return mobileNumber.Substring(0, 6) + "xxx" + mobileNumber.Substring(9);
        }
    }
}
