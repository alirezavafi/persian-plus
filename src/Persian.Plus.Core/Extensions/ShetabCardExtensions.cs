using System.Linq;
using System.Text.RegularExpressions;
using Persian.Plus.Core.Extensions.Normalizer;

namespace Persian.Plus.Core.Extensions
{
    public static class ShetabCardExtensions
    {
        private static readonly Regex _matchIranShetab = new Regex(@"[0-9]{16}", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: StringExtensions.MatchTimeout);

        public static bool IsShetabCardNumber(this string creditCardNumber)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            creditCardNumber = creditCardNumber.Replace("-", string.Empty).Replace(" ", string.Empty);

            if (creditCardNumber.Length != 16)
            {
                return false;
            }

            if (!_matchIranShetab.IsMatch(creditCardNumber))
            {
                return false;
            }

            int sumOfDigits = creditCardNumber.Where(e => e >= '0' && e <= '9')
                .Reverse()
                .Select((e, i) => (e - 48) * (i % 2 == 0 ? 1 : 2))
                .Sum(e => e / 10 + e % 10);

            return sumOfDigits % 10 == 0;
        }
    }
}