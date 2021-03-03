using System;
using System.Text.RegularExpressions;

namespace Persian.Plus.Core.Extensions.Normalizer
{
    public static class StringExtensions
    {
        public static readonly TimeSpan MatchTimeout = TimeSpan.FromMinutes(1);

        private static readonly Regex _matchAllTags =
            new Regex(@"<(.|\n)*?>", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        private static readonly Regex _matchArabicHebrew =
            new Regex(@"[\u0600-\u06FF,\u0590-\u05FF,«,»]", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        private static readonly Regex _matchOnlyPersianNumbersRange =
            new Regex(@"^[\u06F0-\u06F9]+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        private static readonly Regex _matchOnlyPersianLetters =
            new Regex(@"^[\\s,\u06A9\u06AF\u06C0\u06CC\u060C,\u062A\u062B\u062C\u062D\u062E\u062F,\u063A\u064A\u064B\u064C\u064D\u064E,\u064F\u067E\u0670\u0686\u0698\u200C,\u0621-\u0629\u0630-\u0639\u0641-\u0654]+$",
                options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        internal static readonly Regex _hasHalfSpaces =
                    new Regex(@"\u200B|\u200C|\u200E|\u200F",
                        options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);
        

        private const char RightToLeftDirectionChar = (char)0x202B;

        public static string ApplyRtlDirection(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            return text.ContainsPersianLettersOrDigits() ? $"{RightToLeftDirectionChar}{text}" : text;
        }

        public static bool IsRtlDirection(this string text)
        {
            return text.StartsWith(RightToLeftDirectionChar);
        }

        
        public static bool ContainsPersianLettersOrDigits(this string txt)
        {
            return !string.IsNullOrEmpty(txt) &&
                _matchArabicHebrew.IsMatch(txt);
        }

        public static bool ContainsOnlyPersianLetters(this string txt)
        {
            return !string.IsNullOrEmpty(txt) &&
                   _matchOnlyPersianLetters.IsMatch(txt);
        }
       
        public static bool ContainsOnlyPersianDigits(this string text)
        {
            return !string.IsNullOrEmpty(text) &&
                   _matchOnlyPersianNumbersRange.IsMatch(text);
        }
        
        public static bool ContainsThinSpace(this string text)
            => _hasHalfSpaces.IsMatch(text);
        
        public static string NormalizePersianText(this string text, PersianNormalizerFlags normalizerFlags)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            
            if (!text.ContainsPersianLettersOrDigits())
            {
                return text;
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.RemoveDiacritics))
            {
                text = text.RemoveDiacritics();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.ApplyPersianYeKe))
            {
                text = text.ApplyCorrectYeKe();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.ApplyHalfSpaceRule))
            {
                text = text.ApplyHalfSpaceRule();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.CleanupZwnj))
            {
                text = text.NormalizeZwnj();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.FixDashes))
            {
                text = text.NormalizeDashes();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.ConvertDotsToEllipsis))
            {
                text = text.NormalizeDotsToEllipsis();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.ConvertEnglishQuotes))
            {
                text = text.NormalizeEnglishQuotes();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.CleanupExtraMarks))
            {
                text = text.NormalizeExtraMarks();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.RemoveAllKashida))
            {
                text = text.NormalizeAllKashida();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.CleanupSpacingAndLineBreaks))
            {
                text = text.NormalizeSpacingAndLineBreaks();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.RemoveOutsideInsideSpacing))
            {
                text = text.NormalizeOutsideInsideSpacing();
            }

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.RemoveHexadecimalSymbols))
            {
                text = text.RemoveHexadecimalSymbols();
            }

            return text;
        }
    }
}
