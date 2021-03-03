using System.Text.RegularExpressions;
using Persian.Plus.Core.Extensions.Normalizer;

namespace Persian.Plus.Core.Extensions
{
    public static class ShebaExtensions
    {
        private static readonly Regex _matchIranSheba = new Regex(@"IR[0-9]{24}", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: StringExtensions.MatchTimeout);

        public static bool IsShebaNumber(this string iban)
        {
            if (string.IsNullOrEmpty(iban))
            {
                return false;
            }

            if (iban.Length < 4 || iban[0] == ' ' || iban[1] == ' ' || iban[2] == ' ' || iban[3] == ' ')
            {
                return false;
            }

            if (iban.Length != 26)
            {
                return false;
            }

            if (!_matchIranSheba.IsMatch(iban))
            {
                return false;
            }

            var checksum = 0;
            var ibanLength = iban.Length;
            for (int charIndex = 0; charIndex < ibanLength; charIndex++)
            {
                if (iban[charIndex] == ' ')
                {
                    continue;
                }

                int value;
                var c = iban[(charIndex + 4) % ibanLength];
                if ((c >= '0') && (c <= '9'))
                {
                    value = c - '0';
                }
                else if ((c >= 'A') && (c <= 'Z'))
                {
                    value = c - 'A';
                    checksum = (checksum * 10 + (value / 10 + 1)) % 97;
                    value %= 10;
                }
                else if ((c >= 'a') && (c <= 'z'))
                {
                    value = c - 'a';
                    checksum = (checksum * 10 + (value / 10 + 1)) % 97;
                    value %= 10;
                }
                else
                {
                    return false;
                }

                checksum = (checksum * 10 + value) % 97;
            }
            return checksum == 1;
        }
    }
}