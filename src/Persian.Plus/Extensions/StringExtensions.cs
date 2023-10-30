using System;
using System.Text.RegularExpressions;
using Persian.Plus.Extensions.Normalizer;
using Persian.Plus.Helpers;

namespace Persian.Plus.Extensions
{
    public static class StringExtensions
    {
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
                RegexHelper.MatchArabicHebrewRegex.IsMatch(txt);
        }

        public static bool ContainsOnlyPersianLetters(this string txt)
        {
            var containsOnlyPersianLetters = !string.IsNullOrEmpty(txt) && RegexHelper.MatchOnlyPersianLettersRegex.IsMatch(txt);
            return containsOnlyPersianLetters;
        }
        
        public static bool ContainsOnlyPersianOrEnglishLetters(this string txt)
        {
            var containsOnlyPersianOrEnglishLetters = !string.IsNullOrEmpty(txt) && (RegexHelper.MatchOnlyPersianOrEnglishLettersRegex.IsMatch(txt));
            return containsOnlyPersianOrEnglishLetters;
        }

        public static bool ContainsOnlyPersianOrEnglishLettersOrDigits(this string txt)
        {
            var isMatch = !string.IsNullOrEmpty(txt) && (RegexHelper.MatchOnlyPersianOrEnglishLettersOrDigitsRegex.IsMatch(txt));
            return isMatch;
        }
        
        public static bool ContainsOnlyPersianPhrase(this string txt)
        {
            var isMatch = !string.IsNullOrEmpty(txt) && (RegexHelper.MatchOnlyPersianPhraseRegex.IsMatch(txt));
            return isMatch;
        }

        public static bool ContainsOnlyPersianOrEnglishPhrase(this string txt)
        {
            var isMatch = !string.IsNullOrEmpty(txt) && (RegexHelper.MatchOnlyPersianOrEnglishPhraseRegex.IsMatch(txt));
            return isMatch;
        }

        public static bool ContainsOnlyPersianDigits(this string text)
        {
            return !string.IsNullOrEmpty(text) &&
                   RegexHelper.MatchOnlyPersianNumbersRangeRegex.IsMatch(text);
        }
        
        public static bool ContainsThinSpace(this string text)
            => RegexHelper.HasHalfSpacesRegex.IsMatch(text);
        
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

            if (normalizerFlags.HasFlag(PersianNormalizerFlags.ApplyPersianCharacters))
            {
                text = text.ApplyCorrectPersianCharacters();
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
