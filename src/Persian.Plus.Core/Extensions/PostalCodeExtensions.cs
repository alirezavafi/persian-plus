using System.Text.RegularExpressions;
using Persian.Plus.Core.Extensions.Normalizer;

namespace Persian.Plus.Core.Extensions
{
    public static class PostalCodeExtensions
    {
        private static readonly Regex _matchIranianPostalCode = new Regex(@"\b(?!(\d)\1{3})[13-9]{4}[1346-9][013-9]{5}\b", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: StringExtensions.MatchTimeout);
        public static bool IsIranianPostalCode(this string postalCode)
        {
            return !string.IsNullOrWhiteSpace(postalCode) && _matchIranianPostalCode.IsMatch(postalCode);
        }
    }
}