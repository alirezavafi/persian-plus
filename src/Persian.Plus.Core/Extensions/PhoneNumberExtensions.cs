using System.Text.RegularExpressions;

namespace Persian.Plus.Core.Extensions
{
    public static class PhoneNumberExtensions
    {
        private static readonly Regex _matchIranianMobileNumber1 = new Regex(@"^(((98)|(\+98)|(0098)|0)(9){1}[0-9]{9})+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: RegexUtils.MatchTimeout);
        private static readonly Regex _matchIranianMobileNumber2 = new Regex(@"^(9){1}[0-9]{9}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: RegexUtils.MatchTimeout);
        private static readonly Regex _matchIranianPhoneNumber = new Regex("^[2-9][0-9]{7}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: RegexUtils.MatchTimeout);

        public static bool IsIranianMobileNumber(this string mobileNumber)
        {
            return !string.IsNullOrWhiteSpace(mobileNumber) &&
                (_matchIranianMobileNumber1.IsMatch(mobileNumber) || _matchIranianMobileNumber2.IsMatch(mobileNumber));
        }

        public static bool IsIranianPhoneNumber(this string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && _matchIranianPhoneNumber.IsMatch(phoneNumber);
        }
    }
}
