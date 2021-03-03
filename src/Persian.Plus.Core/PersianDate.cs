using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Persian.Plus.Core.Extensions
{
    public class PersianDate
    {
        private PersianDate()
        {
            CultureInfo = GetPersianCulture();
        }
        
        public PersianDate(DateTime dateTime) : this()
        {
            DateTime = dateTime;
            this.Year = Calendar.GetYear(dateTime);
            this.Month = Calendar.GetMonth(dateTime);
            this.Day = Calendar.GetDayOfMonth(dateTime);
        }

        public PersianDate(int year, int month, int day) : this()
        {
           this.DateTime =  Calendar.ToDateTime(year, month, day, 0, 0, 0, 0);
           this.Year = year;
           this.Month = month;
           this.Day = day;
        }
        
        public PersianCalendar Calendar { get; } = new PersianCalendar();
        public CultureInfo CultureInfo { get; }
        public DateTime DateTime { get; }
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public PersianDate AddYears(int years)
        {
            return new PersianDate(Calendar.AddYears(this.DateTime, years));
        }
        public PersianDate AddMonths(int months)
        {
            return new PersianDate(Calendar.AddMonths(this.DateTime, months));
        }
        public PersianDate AddDays(int days)
        {
            return new PersianDate(Calendar.AddDays(this.DateTime, days));
        }

        private CultureInfo GetPersianCulture()
        {
            var persianCulture = new CultureInfo("fa-IR")
            {
                DateTimeFormat =
                {
                    AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" },
                    AbbreviatedMonthGenitiveNames =
                        new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", string.Empty },
                    AbbreviatedMonthNames =
                        new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", string.Empty },
                    AMDesignator = "ق.ظ",
                    CalendarWeekRule = CalendarWeekRule.FirstDay,
                    //DateSeparator = "؍",
                    DayNames = new[] { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهار‌شنبه", "پنجشنبه", "جمعه", "شنبه" },
                    FirstDayOfWeek = DayOfWeek.Saturday,
                    FullDateTimePattern = "dddd dd MMMM yyyy",
                    LongDatePattern = "dd MMMM yyyy",
                    LongTimePattern = "h:mm:ss tt",
                    MonthDayPattern = "dd MMMM",
                    MonthGenitiveNames =
                        new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", string.Empty },
                    MonthNames =
                        new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", string.Empty },
                    PMDesignator = "ب.ظ",
                    ShortDatePattern = "yyyy/MM/dd",
                    ShortestDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" },
                    ShortTimePattern = "HH:mm",
                    //TimeSeparator = ":",
                    YearMonthPattern = "MMMM yyyy"
                }
            };

            var persianCalendar = new PersianCalendar();
            var fieldInfo = persianCulture.GetType()
                                          .GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo?.SetValue(persianCulture, persianCalendar);

            var info = persianCulture.DateTimeFormat.GetType()
                                                    .GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
            info?.SetValue(persianCulture.DateTimeFormat, persianCalendar);

            persianCulture.NumberFormat.NumberDecimalSeparator = "/";
            persianCulture.NumberFormat.NumberNegativePattern = 0;

            return persianCulture;
        }

       public static IDictionary<DayOfWeek, string> PersianDayWeekNames { get; } = new Dictionary<DayOfWeek, string>
          {
            {DayOfWeek.Saturday, "شنبه"},
            {DayOfWeek.Sunday,  "یک شنبه"},
            {DayOfWeek.Monday,  "دو شنبه"},
            {DayOfWeek.Tuesday, "سه شنبه"},
            {DayOfWeek.Wednesday, "چهار شنبه"},
            {DayOfWeek.Thursday, "پنج شنبه"},
            {DayOfWeek.Friday, "جمعه"}
          };

        public static IDictionary<int, string> PersianMonthDayNumberNames { get; } = new Dictionary<int, string>
           {
             { 1, "یکم" },
             { 2, "دوم" },
             { 3, "سوم" },
             { 4, "چهارم" },
             { 5, "پنجم" },
             { 6, "ششم" },
             { 7, "هفتم" },
             { 8, "هشتم" },
             { 9, "نهم" },
             { 10, "دهم" },
             { 11, "یازدهم" },
             { 12, "دوازدهم" },
             { 13, "سیزدهم" },
             { 14, "چهاردهم" },
             { 15, "پانزدهم" },
             { 16, "شانزدهم" },
             { 17, "هفدهم" },
             { 18, "هجدهم" },
             { 19, "نوزدهم" },
             { 20, "بیستم" },
             { 21, "بیست یکم" },
             { 22, "بیست دوم" },
             { 23, "بیست سوم" },
             { 24, "بیست چهارم" },
             { 25, "بیست پنجم" },
             { 26, "بیست ششم" },
             { 27, "بیست هفتم" },
             { 28, "بیست هشتم" },
             { 29, "بیست نهم" },
             { 30, "سی‌ام" },
             { 31, "سی یکم" }
           };

        public static IDictionary<int, string> PersianMonthNames { get; } = new Dictionary<int, string>
           {
            {1, "فروردین"},
            {2, "اردیبهشت"},
            {3, "خرداد"},
            {4, "تیر"},
            {5, "مرداد"},
            {6, "شهریور"},
            {7, "مهر"},
            {8, "آبان"},
            {9, "آذر"},
            {10, "دی"},
            {11, "بهمن"},
            {12, "اسفند"}
           };

        public static PersianDate Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new FormatException();
            }

            var parts = s.Split(new[] {'/', '-', ','});
            var temp = 0;
            if (parts.Length != 3 || parts.Any(x => int.TryParse(x, out temp)))
            {
                throw new FormatException();
            }

            var parsedParts = parts.Select(int.Parse).ToList();
            return new PersianDate(parsedParts[0], parsedParts[1], parsedParts[2]);
        }

        public static bool TryParse(string s, out PersianDate pd)
        {
            try
            {
                pd = PersianDate.Parse(s);
                return true;
            }
            catch (Exception e)
            {
                pd = null;
                return false;
            }
        }
        
        public static PersianDate Now => new PersianDate(DateTime.Now);
        public static implicit operator DateTime(PersianDate d) => d.DateTime;
        public static implicit operator PersianDate(DateTime d) => new PersianDate(d);
    }
}