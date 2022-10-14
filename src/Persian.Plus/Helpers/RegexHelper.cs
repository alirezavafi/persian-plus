using System;
using System.Text.RegularExpressions;

namespace Persian.Plus.Helpers
{
    public static class RegexHelper
    {
        public static readonly TimeSpan MatchTimeout = TimeSpan.FromMinutes(1);

        public const string MatchAllTagsRegexPattern = @"<(.|\n)*?>";
        public static readonly Regex MatchAllTagsRegex =
            new(MatchAllTagsRegexPattern, options: RegexOptions.Compiled | RegexOptions.IgnoreCase,
                matchTimeout: MatchTimeout);

        public const string MatchArabicHebrewRegexPattern = @"[\u0600-\u06FF,\u0590-\u05FF,«,»]";
        public static readonly Regex MatchArabicHebrewRegex =
            new Regex(MatchArabicHebrewRegexPattern, options: RegexOptions.Compiled | RegexOptions.IgnoreCase,
                matchTimeout: MatchTimeout);

        public const string MatchOnlyPersianNumbersRangeRegexPattern = @"^[\u06F0-\u06F9 ]+$";
        public static readonly Regex MatchOnlyPersianNumbersRangeRegex =
            new Regex(MatchOnlyPersianNumbersRangeRegexPattern, options: RegexOptions.Compiled | RegexOptions.IgnoreCase,
                matchTimeout: MatchTimeout);

        public const string MatchOnlyPersianLettersRegexPattern = @"^[\s,\u06A9\u06AF\u06C0\u06CC\u060C,\u062A\u062B\u062C\u062D\u062E\u062F,\u063A\u064A\u064B\u064C\u064D\u064E,\u064F\u067E\u0670\u0686\u0698\u200C,\u0621-\u0629\u0630-\u0639\u0641-\u0654]+$";
        public static readonly Regex MatchOnlyPersianLettersRegex =
            new Regex(MatchOnlyPersianLettersRegexPattern,
                options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        public const string MatchOnlyPersianOrEnglishLettersRegexPattern = @"^[\s,A-Za-z,\u06A9\u06AF\u06C0\u06CC\u060C,\u062A\u062B\u062C\u062D\u062E\u062F,\u063A\u064A\u064B\u064C\u064D\u064E,\u064F\u067E\u0670\u0686\u0698\u200C,\u0621-\u0629\u0630-\u0639\u0641-\u0654]+$";
        public static readonly Regex MatchOnlyPersianOrEnglishLettersRegex =
            new Regex(MatchOnlyPersianOrEnglishLettersRegexPattern,
                options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        public const string MatchOnlyPersianOrEnglishLettersOrDigitsRegexPattern = @"^[\s,\u06F0-\u06F9,0-9,A-Za-z,\u06A9\u06AF\u06C0\u06CC\u060C,\u062A\u062B\u062C\u062D\u062E\u062F,\u063A\u064A\u064B\u064C\u064D\u064E,\u064F\u067E\u0670\u0686\u0698\u200C,\u0621-\u0629\u0630-\u0639\u0641-\u0654]+$";
        public static readonly Regex MatchOnlyPersianOrEnglishLettersOrDigitsRegex =
            new Regex(MatchOnlyPersianOrEnglishLettersOrDigitsRegexPattern,
                options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        public const string MatchOnlyPersianOrEnglishPhraseRegexPattern = @"^[\s,-,\u06F0-\u06F9,0-9,A-Za-z,\u06A9\u06AF\u06C0\u06CC\u060C,\u062A\u062B\u062C\u062D\u062E\u062F,\u063A\u064A\u064B\u064C\u064D\u064E,\u064F\u067E\u0670\u0686\u0698\u200C,\u0621-\u0629\u0630-\u0639\u0641-\u0654]+$";
        public static readonly Regex MatchOnlyPersianOrEnglishPhraseRegex =
            new Regex(MatchOnlyPersianOrEnglishPhraseRegexPattern, options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        public const string MatchOnlyPersianPhraseRegexPattern = @"^[\s,-,\u06F0-\u06F9,0-9,\u06A9\u06AF\u06C0\u06CC\u060C,\u062A\u062B\u062C\u062D\u062E\u062F,\u063A\u064A\u064B\u064C\u064D\u064E,\u064F\u067E\u0670\u0686\u0698\u200C,\u0621-\u0629\u0630-\u0639\u0641-\u0654]+$";
        public static readonly Regex MatchOnlyPersianPhraseRegex =
            new Regex(MatchOnlyPersianPhraseRegexPattern, options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);

        public const string HasHalfSpacesRegexPattern = @"\u200B|\u200C|\u200E|\u200F";
        public static readonly Regex HasHalfSpacesRegex =
            new Regex(HasHalfSpacesRegexPattern, options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: MatchTimeout);
    }
}