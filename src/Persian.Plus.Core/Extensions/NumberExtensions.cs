using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Persian.Plus.Core.Internal;

namespace Persian.Plus.Core.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsNumber(this string data)
        {
            return !string.IsNullOrWhiteSpace(data) && data.All(char.IsDigit);
        }

        public static string ToPersianNumbers(this int number, string format = "")
        {
            return ToPersianNumbers(!string.IsNullOrEmpty(format)
                ? number.ToString(format, CultureInfo.InvariantCulture)
                : number.ToString(CultureInfo.InvariantCulture));
        }

        public static string ToPersianNumbers(this long number, string format = "")
        {
            return ToPersianNumbers(!string.IsNullOrEmpty(format)
                ? number.ToString(format, CultureInfo.InvariantCulture)
                : number.ToString(CultureInfo.InvariantCulture));
        }

        public static string ToPersianNumbers(this int? number, string format = "")
        {
            if (!number.HasValue) number = 0;
            return ToPersianNumbers(!string.IsNullOrEmpty(format)
                ? number.Value.ToString(format, CultureInfo.InvariantCulture)
                : number.Value.ToString(CultureInfo.InvariantCulture));
        }

        public static string ToPersianNumbers(this long? number, string format = "")
        {
            if (!number.HasValue) number = 0;
            return ToPersianNumbers(!string.IsNullOrEmpty(format)
                ? number.Value.ToString(format, CultureInfo.InvariantCulture)
                : number.Value.ToString(CultureInfo.InvariantCulture));
        }

        public static string ToPersianNumbers(this string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return string.Empty;

            var dataChars = data.ToCharArray();
            for (var i = 0; i < dataChars.Length; i++)
            {
                switch (dataChars[i])
                {
                    case '0':
                    case '\u0660':
                        dataChars[i] = '\u06F0';
                        break;

                    case '1':
                    case '\u0661':
                        dataChars[i] = '\u06F1';
                        break;

                    case '2':
                    case '\u0662':
                        dataChars[i] = '\u06F2';
                        break;

                    case '3':
                    case '\u0663':
                        dataChars[i] = '\u06F3';
                        break;

                    case '4':
                    case '\u0664':
                        dataChars[i] = '\u06F4';
                        break;

                    case '5':
                    case '\u0665':
                        dataChars[i] = '\u06F5';
                        break;

                    case '6':
                    case '\u0666':
                        dataChars[i] = '\u06F6';
                        break;

                    case '7':
                    case '\u0667':
                        dataChars[i] = '\u06F7';
                        break;

                    case '8':
                    case '\u0668':
                        dataChars[i] = '\u06F8';
                        break;

                    case '9':
                    case '\u0669':
                        dataChars[i] = '\u06F9';
                        break;
                }
            }

            return new string(dataChars);
        }

        public static string ToEnglishNumbers(this string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return string.Empty;

            var dataChars = data.ToCharArray();
            for (var i = 0; i < dataChars.Length; i++)
            {
                switch (dataChars[i])
                {
                    case '\u06F0':
                    case '\u0660':
                        dataChars[i] = '0';
                        break;

                    case '\u06F1':
                    case '\u0661':
                        dataChars[i] = '1';
                        break;

                    case '\u06F2':
                    case '\u0662':
                        dataChars[i] = '2';
                        break;

                    case '\u06F3':
                    case '\u0663':
                        dataChars[i] = '3';
                        break;

                    case '\u06F4':
                    case '\u0664':
                        dataChars[i] = '4';
                        break;

                    case '\u06F5':
                    case '\u0665':
                        dataChars[i] = '5';
                        break;

                    case '\u06F6':
                    case '\u0666':
                        dataChars[i] = '6';
                        break;

                    case '\u06F7':
                    case '\u0667':
                        dataChars[i] = '7';
                        break;

                    case '\u06F8':
                    case '\u0668':
                        dataChars[i] = '8';
                        break;

                    case '\u06F9':
                    case '\u0669':
                        dataChars[i] = '9';
                        break;
                }
            }

            return new string(dataChars);
        }

        private static readonly IDictionary<Language, string> _and = new Dictionary<Language, string>
        {
            {Language.English, " "},
            {Language.Persian, " و "}
        };

        private static readonly IList<NumberWord> _numberWords = new List<NumberWord>
        {
            new NumberWord
            {
                Group = DigitGroup.Ones, Language = Language.English, Names =
                    new List<string>
                        {string.Empty, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}
            },
            new NumberWord
            {
                Group = DigitGroup.Ones, Language = Language.Persian, Names =
                    new List<string> {string.Empty, "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه"}
            },

            new NumberWord
            {
                Group = DigitGroup.Teens, Language = Language.English, Names =
                    new List<string>
                    {
                        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                        "Eighteen", "Nineteen"
                    }
            },
            new NumberWord
            {
                Group = DigitGroup.Teens, Language = Language.Persian, Names =
                    new List<string>
                        {"ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده"}
            },

            new NumberWord
            {
                Group = DigitGroup.Tens, Language = Language.English, Names =
                    new List<string> {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
            },
            new NumberWord
            {
                Group = DigitGroup.Tens, Language = Language.Persian, Names =
                    new List<string> {"بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود"}
            },

            new NumberWord
            {
                Group = DigitGroup.Hundreds, Language = Language.English, Names =
                    new List<string>
                    {
                        string.Empty, "One Hundred", "Two Hundred", "Three Hundred", "Four Hundred",
                        "Five Hundred", "Six Hundred", "Seven Hundred", "Eight Hundred", "Nine Hundred"
                    }
            },
            new NumberWord
            {
                Group = DigitGroup.Hundreds, Language = Language.Persian, Names =
                    new List<string>
                        {string.Empty, "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد"}
            },

            new NumberWord
            {
                Group = DigitGroup.Thousands, Language = Language.English, Names =
                    new List<string>
                    {
                        string.Empty, " Thousand", " Million", " Billion", " Trillion", " Quadrillion", " Quintillion",
                        " Sextillian",
                        " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion",
                        " Tredecillion",
                        " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion",
                        " Novemdecillion",
                        " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81",
                        " 10^84", " 10^87",
                        " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion"
                    }
            },
            new NumberWord
            {
                Group = DigitGroup.Thousands, Language = Language.Persian, Names =
                    new List<string>
                    {
                        string.Empty,
                        " هزار",
                        " میلیون",
                        " میلیارد",
                        " تریلیون",
                        " کادریلیون",
                        " کوينتيليون",
                        " سکستيليون",
                        " سپتيليون",
                        " اکتيليون",
                        " نونيليون",
                        " دسيليون",
                        " آندسيليون",
                        " دودسيليون",
                        " تريدسيليون",
                        " کواتردسيليون",
                        " کويندسيليون",
                        " سيکسدسيليون",
                        " سپتندسيليون",
                        " اکتودسيليوم",
                        " نومدسيليون",
                        " ويجينتيليون",
                        " آنويجينتيليون",
                        " دويجينتيليون",
                        " 10^72",
                        " 10^75",
                        " 10^78",
                        " 10^81",
                        " 10^84",
                        " 10^87",
                        " Vigintinonillion",
                        " 10^93",
                        " 10^96",
                        " Duotrigintillion",
                        " Trestrigintillion"
                    }
            },
        };

        private static readonly IDictionary<Language, string> _negative = new Dictionary<Language, string>
        {
            {Language.English, "Negative "},
            {Language.Persian, "منهای "}
        };

        private static readonly IDictionary<Language, string> _zero = new Dictionary<Language, string>
        {
            {Language.English, "Zero"},
            {Language.Persian, "صفر"}
        };

        public static string Textify(this int number, Language language)
        {
            return Textify((long) number, language);
        }

        public static string Textify(this uint number, Language language)
        {
            return Textify((long) number, language);
        }

        public static string Textify(this byte number, Language language)
        {
            return Textify((long) number, language);
        }

        public static string Textify(this decimal number, Language language)
        {
            return Textify((long) number, language);
        }

        public static string Textify(this double number, Language language)
        {
            return Textify((long) number, language);
        }

        public static string Textify(this long number, Language language)
        {
            if (number == 0)
            {
                return _zero[language];
            }

            if (number < 0)
            {
                return _negative[language] + Textify(-number, language);
            }

            return wordify(number, language, string.Empty, 0);
        }

        private static string getName(int idx, Language language, DigitGroup group)
        {
            return _numberWords.First(x => x.Group == group && x.Language == language).Names.ElementAt(idx);
        }

        private static string wordify(long number, Language language, string leftDigitsText, int thousands)
        {
            if (number == 0)
            {
                return leftDigitsText;
            }

            var wordValue = leftDigitsText;
            if (wordValue.Length > 0)
            {
                wordValue += _and[language];
            }

            if (number < 10)
            {
                wordValue += getName((int) number, language, DigitGroup.Ones);
            }
            else if (number < 20)
            {
                wordValue += getName((int) (number - 10), language, DigitGroup.Teens);
            }
            else if (number < 100)
            {
                wordValue += wordify(number % 10, language, getName((int) (number / 10 - 2), language, DigitGroup.Tens),
                    0);
            }
            else if (number < 1000)
            {
                wordValue += wordify(number % 100, language,
                    getName((int) (number / 100), language, DigitGroup.Hundreds), 0);
            }
            else
            {
                wordValue += wordify(number % 1000, language,
                    wordify(number / 1000, language, string.Empty, thousands + 1), 0);
            }

            if (number % 1000 == 0) return wordValue;
            return wordValue + getName(thousands, language, DigitGroup.Thousands);
        }
    }
}