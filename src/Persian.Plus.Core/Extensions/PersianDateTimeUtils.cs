using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using Persian.Plus.Core.Internal;
using static System.FormattableString;


namespace Persian.Plus.Core.Extensions
{
    /// <summary>
    /// Represents PersianDateTime utils.
    /// </summary>
    public static class PersianDateTimeUtils
    {
                /// <summary>
        /// معادل فارسی روزهای هفته میلادی
        /// </summary>
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

        /// <summary>
        /// عدد به حروف روزهای شمسی
        /// </summary>
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

        /// <summary>
        /// نام فارسی ماه‌های شمسی
        /// </summary>
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


        private static readonly Lazy<CultureInfo> _cultureInfoBuilder =
                    new Lazy<CultureInfo>(getPersianCulture, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// وهله‌ی یکتای فرهنگ فارسی سفارشی سازی شده
        /// </summary>
        public static CultureInfo Instance { get; } = _cultureInfoBuilder.Value;

        /// <summary>
        /// Returns the day-of-month part of this <see cref="DateTime"/> localized in Persian calendar.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        /// <returns>An integer between 1 and 31 representing the day-of-month part of this <see cref="DateTime"/>.</returns>
        public static int GetPersianDayOfMonth(this DateTime dateTime, bool convertToIranTimeZone = true)
        {
            if (dateTime.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                dateTime = dateTime.ToIranTimeZoneDateTime();
            }
            return Instance.DateTimeFormat.Calendar.GetDayOfMonth(dateTime);
        }

        /// <summary>
        /// Returns the month part of this <see cref="DateTime"/> localized in Persian calendar.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        /// <returns>An integer between 1 and 12 representing the month part of this <see cref="DateTime"/>.</returns>
        public static int GetPersianMonth(this DateTime dateTime, bool convertToIranTimeZone = true)
        {
            if (dateTime.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                dateTime = dateTime.ToIranTimeZoneDateTime();
            }
            return Instance.DateTimeFormat.Calendar.GetMonth(dateTime);
        }

        /// <summary>
        /// عدد به حروف روزهای شمسی
        /// </summary>
        public static string GetPersianMonthDayNumberName(this int dayNumber)
        {
            if (dayNumber < 1 || dayNumber > 31)
            {
                throw new ArgumentOutOfRangeException($"{nameof(dayNumber)} must be between 1, 31.");
            }
            return PersianMonthDayNumberNames[dayNumber];
        }

        /// <summary>
        /// نام فارسی ماه‌های شمسی
        /// </summary>
        public static string GetPersianMonthName(this int monthNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
            {
                throw new ArgumentOutOfRangeException($"{nameof(monthNumber)} must be between 1, 12.");
            }
            return PersianMonthNames[monthNumber];
        }

        /// <summary>
        /// دریافت معادل فارسی نام روز هفته‌ی میلادی
        /// </summary>
        public static string GetPersianWeekDayName(this DayOfWeek dayOfWeek)
        {
            return PersianDayWeekNames[dayOfWeek];
        }

        /// <summary>
        /// گرفتن نام فارسی روزهای هفته
        /// </summary>
        public static string GetPersianWeekDayName(int persianYear, int persianMonth, int persianDay)
        {
            return PersianDayWeekNames[new PersianCalendar().ToDateTime(persianYear, persianMonth, persianDay, 0, 0, 0, 0).DayOfWeek];
        }

        /// <summary>
        /// گرفتن نام فارسی روزهای هفته
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string GetPersianWeekDayName(this DateTime dt, bool convertToIranTimeZone = true)
        {
            if (dt.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                dt = dt.ToIranTimeZoneDateTime();
            }
            var dateParts = dt.ToPersianYearMonthDay(false);
            return PersianDayWeekNames[new PersianCalendar().ToDateTime(dateParts.Year, dateParts.Month, dateParts.Day, dt.Hour, dt.Minute, dt.Second, 0).DayOfWeek];
        }

        /// <summary>
        /// گرفتن نام فارسی روزهای هفته
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string GetPersianWeekDayName(this DateTime? dt, bool convertToIranTimeZone = true)
        {
            return dt == null ? string.Empty : GetPersianWeekDayName(dt.Value, convertToIranTimeZone);
        }

        /// <summary>
        /// گرفتن نام فارسی روزهای هفته
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string GetPersianWeekDayName(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return dt == null ? string.Empty : GetPersianWeekDayName(dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// گرفتن نام فارسی روزهای هفته
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string GetPersianWeekDayName(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return GetPersianWeekDayName(dt.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// Returns the year part of this <see cref="DateTime"/> localized in Persian calendar.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        /// <returns>An integer between 1 and 9999 representing the year part of this <see cref="DateTime"/>.</returns>
        public static int GetPersianYear(this DateTime dateTime, bool convertToIranTimeZone = true)
        {
            if (dateTime.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                dateTime = dateTime.ToIranTimeZoneDateTime();
            }
            return Instance.DateTimeFormat.Calendar.GetYear(dateTime);
        }

        /// <summary>
        /// تاریخ روزهای ابتدا و انتهای سال شمسی را بازگشت می‌دهد
        /// </summary>
        public static DateRange GetPersianYearStartAndEndDates(this int persianYear)
        {
            var persianCalendar = new PersianCalendar();
            return new DateRange
            {
                StartDate = persianCalendar.ToDateTime(persianYear, 1, 1, 0, 0, 0, 0),
                EndDate = persianCalendar.ToDateTime(persianYear, 12, persianYear.GetPersianMonthLastDay(12), 23, 59, 59, 0)
            };
        }

        /// <summary>
        /// سال شمسی معادل را محاسبه کرده و سپس
        /// تاریخ روزهای ابتدا و انتهای آن سال شمسی را بازگشت می‌دهد
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static DateRange GetPersianYearStartAndEndDates(this DateTime dateTime, bool convertToIranTimeZone = true)
        {
            var persianYear = dateTime.GetPersianYear(convertToIranTimeZone);
            return persianYear.GetPersianYearStartAndEndDates();
        }

        /// <summary>
        /// سال شمسی معادل را محاسبه کرده و سپس
        /// تاریخ روزهای ابتدا و انتهای آن سال شمسی را بازگشت می‌دهد
        /// </summary>
        public static DateRange GetPersianYearStartAndEndDates(this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            var persianYear = dateTimeOffset.GetDateTimeOffsetPart(dateTimeOffsetPart).GetPersianYear();
            return persianYear.GetPersianYearStartAndEndDates();
        }

        /// <summary>
        /// تاریخ روزهای ابتدا و انتهای ماه شمسی را بازگشت می‌دهد
        /// </summary>
        public static DateRange GetPersianMonthStartAndEndDates(this int persianYear, int persianMonth)
        {
            var persianCalendar = new PersianCalendar();
            return new DateRange
            {
                StartDate = persianCalendar.ToDateTime(persianYear, persianMonth, 1, 0, 0, 0, 0),
                EndDate = persianCalendar.ToDateTime(persianYear, persianMonth, persianYear.GetPersianMonthLastDay(persianMonth), 23, 59, 59, 0)
            };
        }

        /// <summary>
        /// ماه شمسی معادل را محاسبه کرده و سپس
        /// تاریخ روزهای ابتدا و انتهای آن ماه شمسی را بازگشت می‌دهد
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static DateRange GetPersianMonthStartAndEndDates(this DateTime dateTime, bool convertToIranTimeZone = true)
        {
            var persianYear = dateTime.GetPersianYear(convertToIranTimeZone);
            var persianMonth = dateTime.GetPersianMonth(convertToIranTimeZone);
            return persianYear.GetPersianMonthStartAndEndDates(persianMonth);
        }

        /// <summary>
        /// ماه شمسی معادل را محاسبه کرده و سپس
        /// تاریخ روزهای ابتدا و انتهای آن ماه شمسی را بازگشت می‌دهد
        /// </summary>
        public static DateRange GetPersianMonthStartAndEndDates(this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            var dateTime = dateTimeOffset.GetDateTimeOffsetPart(dateTimeOffsetPart);
            var persianYear = dateTime.GetPersianYear();
            var persianMonth = dateTime.GetPersianMonth();
            return persianYear.GetPersianMonthStartAndEndDates(persianMonth);
        }

        /// <summary>
        /// تاریخ روزهای ابتدا و انتهای هفته شمسی را بازگشت می‌دهد
        /// </summary>
        public static DateRange GetPersianWeekStartAndEndDates(this int persianYear, int persianMonth, int persianDay)
        {
            var dateTime = new PersianCalendar().ToDateTime(persianYear, persianMonth, persianDay, 0, 0, 0, 0);
            return GetPersianWeekStartAndEndDates(dateTime);
        }

        /// <summary>
        /// هفته شمسی معادل را محاسبه کرده و سپس
        /// تاریخ روزهای ابتدا و انتهای آن هفته شمسی را بازگشت می‌دهد
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static DateRange GetPersianWeekStartAndEndDates(this DateTime dateTime, bool convertToIranTimeZone = true)
        {
            if (dateTime.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                dateTime = dateTime.ToIranTimeZoneDateTime();
            }

            var firstDayOfWeek = Instance.DateTimeFormat.FirstDayOfWeek;
            var offset = -1 * ((7 + (dateTime.DayOfWeek - firstDayOfWeek)) % 7);
            var firstDayOfWeekDate = dateTime.AddDays(offset);
            var lastDayOfWeekDate = firstDayOfWeekDate.AddDays(6);
            return new DateRange
            {
                StartDate = firstDayOfWeekDate,
                EndDate = new DateTime(lastDayOfWeekDate.Year, lastDayOfWeekDate.Month, lastDayOfWeekDate.Day, 23, 59, 59, 0)
            };
        }

        /// <summary>
        /// هفته شمسی معادل را محاسبه کرده و سپس
        /// تاریخ روزهای ابتدا و انتهای آن هفته شمسی را بازگشت می‌دهد
        /// </summary>
        public static DateRange GetPersianWeekStartAndEndDates(this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            var dateTime = dateTimeOffset.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return GetPersianWeekStartAndEndDates(dateTime);
        }

        /// <summary>
        /// شماره آخرین روز ماه شمسی را بر می‌گرداند
        /// </summary>
        /// <param name="persianYear">سال شمسی</param>
        /// <param name="persianMonth">ماه شمسی</param>
        /// <returns>شماره آخرین روز ماه</returns>
        public static int GetPersianMonthLastDay(this int persianYear, int persianMonth)
        {
            if (persianMonth > 12 || persianMonth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(persianMonth), "ماه وارد شده معتبر نیست.");
            }

            if (persianMonth <= 6)
            {
                return 31;
            }

            if (persianMonth == 12)
            {
                var persianCalendar = new PersianCalendar();
                return persianCalendar.IsLeapYear(persianYear) ? 30 : 29;
            }
            return 30;
        }

        /// <summary>
        /// اصلاح تقویم فرهنگ فارسی
        /// </summary>
        private static CultureInfo getPersianCulture()
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
        
        
               /// نمایش فارسی روز دریافتی شمسی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(int persianYear, int persianMonth, int persianDay)
        {
            if (persianYear <= 99)
            {
                persianYear += 1300;
            }

            var strDay = GetPersianWeekDayName(persianYear, persianMonth, persianDay);
            var strMonth = PersianMonthNames[persianMonth];
            return Invariant($"{strDay} {persianDay} {strMonth} {persianYear}").ToPersianNumbers();
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(this DateTime dt, bool convertToIranTimeZone = true)
        {
            var dateParts = dt.ToPersianYearMonthDay(convertToIranTimeZone);
            return ToPersianDateTextify(dateParts.Year, dateParts.Month, dateParts.Day);
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(this DateTime? dt)
        {
            return dt == null ? string.Empty : ToPersianDateTextify(dt.Value);
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string ToPersianDateTextify(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return ToPersianDateTextify(dt.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string ToPersianDateTextify(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return dt == null ? string.Empty : ToPersianDateTextify(dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <param name="appendHhMm">آیا ساعت نیز به نتیجه‌اضافه شود؟</param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        /// <param name="includePersianDate">آيا تاريخ نيز به نتيجه اضافه شود؟</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(
            this DateTime dt, DateTime comparisonBase, bool appendHhMm = true, bool convertToIranTimeZone = true, bool includePersianDate = true)
        {
            return $"{UnicodeConstants.RightToLeftDirectionChar}{toFriendlyPersianDate(dt, comparisonBase, appendHhMm, convertToIranTimeZone, includePersianDate).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <param name="appendHhMm">آیا ساعت نیز به نتیجه‌اضافه شود؟</param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        /// <param name="includePersianDate">آيا تاريخ نيز به نتيجه اضافه شود؟</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(
            this DateTime dt, bool appendHhMm = true, bool convertToIranTimeZone = true, bool includePersianDate = true)
        {
            var comparisonBase = convertToIranTimeZone ? dt.Kind.GetNow().ToIranTimeZoneDateTime() : dt.Kind.GetNow();
            return $"{UnicodeConstants.RightToLeftDirectionChar}{toFriendlyPersianDate(dt, comparisonBase, appendHhMm, convertToIranTimeZone, includePersianDate).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        /// <param name="appendHhMm">آیا ساعت نیز به نتیجه‌اضافه شود؟</param>
        /// <param name="includePersianDate">آيا تاريخ نيز به نتيجه اضافه شود؟</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(
            this DateTimeOffset dt, DateTime comparisonBase,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime, bool appendHhMm = true, bool includePersianDate = true)
        {
            return $"{UnicodeConstants.RightToLeftDirectionChar}{toFriendlyPersianDate(dt.GetDateTimeOffsetPart(dateTimeOffsetPart), comparisonBase, appendHhMm, false, includePersianDate).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <param name="appendHhMm">آیا ساعت نیز به نتیجه‌اضافه شود؟</param>
        /// <param name="includePersianDate">آيا تاريخ نيز به نتيجه اضافه شود؟</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTimeOffset dt, bool appendHhMm = true, bool includePersianDate = true)
        {
            var comparisonBase = DateTime.UtcNow.ToIranTimeZoneDateTime();
            var iranLocalTime = dt.GetDateTimeOffsetPart(DateTimeOffsetPart.IranLocalDateTime);
            return $"{UnicodeConstants.RightToLeftDirectionChar}{toFriendlyPersianDate(iranLocalTime, comparisonBase, appendHhMm, false, includePersianDate).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTime? dt, DateTime comparisonBase)
        {
            return dt == null ? string.Empty : ToFriendlyPersianDateTextify(dt.Value, comparisonBase);
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTime? dt, bool convertToIranTimeZone = true)
        {
            if (dt == null)
            {
                return string.Empty;
            }
            var comparisonBase = convertToIranTimeZone ? dt.Value.Kind.GetNow().ToIranTimeZoneDateTime() : dt.Value.Kind.GetNow();
            return ToFriendlyPersianDateTextify(dt.Value, comparisonBase, convertToIranTimeZone);
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTimeOffset? dt, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return dt == null ? string.Empty : ToFriendlyPersianDateTextify(dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart), comparisonBase);
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="dt">تاریخ ورودی</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTimeOffset? dt)
        {
            if (dt == null)
            {
                return string.Empty;
            }
            var comparisonBase = DateTime.UtcNow.ToIranTimeZoneDateTime();
            var iranLocalTime = dt.Value.GetDateTimeOffsetPart(DateTimeOffsetPart.IranLocalDateTime);
            return ToFriendlyPersianDateTextify(iranLocalTime, comparisonBase);
        }

        private static string toFriendlyPersianDate(
            this DateTime dt,
            DateTime comparisonBase,
            bool appendHhMm,
            bool convertToIranTimeZone,
            bool includePersianDate)
        {
            if (dt.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                dt = dt.ToIranTimeZoneDateTime();
            }
            var persianDate = dt.ToPersianYearMonthDay(false);

            //1388/10/22
            var persianYear = persianDate.Year;
            var persianMonth = persianDate.Month;
            var persianDay = persianDate.Day;

            //13:14
            var hour = dt.Hour;
            var min = dt.Minute;
            var hhMm =
                $"{hour.ToString("00", CultureInfo.InvariantCulture)}:{min.ToString("00", CultureInfo.InvariantCulture)}";

            var date = new PersianCalendar().ToDateTime(persianYear, persianMonth, persianDay, hour, min, 0, 0);
            var diff = date - comparisonBase;
            var totalSeconds = Math.Round(diff.TotalSeconds);
            var totalDays = Math.Round(diff.TotalDays);

            var suffix = " بعد";
            if (totalSeconds < 0)
            {
                suffix = " قبل";
                totalSeconds = Math.Abs(totalSeconds);
                totalDays = Math.Abs(totalDays);
            }

            var dateTimeToday = DateTime.Today;
            var yesterday = dateTimeToday.AddDays(-1);
            var today = dateTimeToday.Date;
            var tomorrow = dateTimeToday.AddDays(1);

            hhMm = appendHhMm ? $"، ساعت {hhMm}" : string.Empty;

            if (today == date.Date)
            {
                // Less than one minute ago.
                if (totalSeconds < 60)
                {
                    return "هم اکنون";
                }

                // Less than 2 minutes ago.
                if (totalSeconds < 120)
                {
                    return $"یک دقیقه{suffix}{hhMm}";
                }

                // Less than one hour ago.
                if (totalSeconds < 3600)
                {
                    return string.Format(CultureInfo.InvariantCulture, "{0} دقیقه",
                        ((int)Math.Floor(totalSeconds / 60))) + suffix + hhMm;
                }

                // Less than 2 hours ago.
                if (totalSeconds < 7200)
                {
                    return $"یک ساعت{suffix}{hhMm}";
                }

                // Less than one day ago.
                if (totalSeconds < 86400)
                {
                    return
                        string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} ساعت",
                        ((int)Math.Floor(totalSeconds / 3600))
                        ) + suffix + hhMm;
                }
            }

            if (yesterday == date.Date)
            {
                return $"دیروز {GetPersianWeekDayName(persianYear, persianMonth, persianDay)}{hhMm}";
            }

            if (tomorrow == date.Date)
            {
                return $"فردا {GetPersianWeekDayName(persianYear, persianMonth, persianDay)}{hhMm}";
            }

            var dayStr = includePersianDate ? $"، {ToPersianDateTextify(persianYear, persianMonth, persianDay)}{hhMm}" : string.Empty;

            if (totalSeconds < 30 * TimeConstants.Day)
            {
                return Invariant($"{(int)Math.Abs(totalDays)} روز{suffix}{dayStr}");
            }

            if (totalSeconds < 12 * TimeConstants.Month)
            {
                int months = Convert.ToInt32(Math.Floor((double)Math.Abs(diff.Days) / 30));
                return months <= 1 ? Invariant($"1 ماه{suffix}{dayStr}") : Invariant($"{months} ماه{suffix}{dayStr}");
            }

            var years = Convert.ToInt32(Math.Floor((double)Math.Abs(diff.Days) / 365));
            var daysMonths = (double)Math.Abs(diff.Days) / 30;
            var nextMonths = Convert.ToInt32(Math.Truncate(daysMonths)) - (years * 12) - 1;
            var and = years >= 1 ? " و " : "";
            var nextMonthsStr = nextMonths <= 0 ? "" : Invariant($"{and}{nextMonths} ماه");

            if (years < 1)
            {
                return $"{nextMonthsStr}{suffix}{dayStr}";
            }

            return Invariant($"{years} سال{nextMonthsStr}{suffix}{dayStr}");
        }
        
        /// <summary>
        /// تعیین اعتبار تاریخ شمسی
        /// </summary>
        /// <param name="persianYear">سال شمسی</param>
        /// <param name="persianMonth">ماه شمسی</param>
        /// <param name="persianDay">روز شمسی</param>
        public static bool IsValidPersianDate(int persianYear, int persianMonth, int persianDay)
        {
            if (persianDay > 31 || persianDay <= 0)
            {
                return false;
            }

            if (persianMonth > 12 || persianMonth <= 0)
            {
                return false;
            }

            if (persianMonth <= 6 && persianDay > 31)
            {
                return false;
            }

            if (persianMonth >= 7 && persianDay > 30)
            {
                return false;
            }

            if (persianMonth == 12)
            {
                var persianCalendar = new PersianCalendar();
                var isLeapYear = persianCalendar.IsLeapYear(persianYear);

                if (isLeapYear && persianDay > 30)
                {
                    return false;
                }

                if (!isLeapYear && persianDay > 29)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// تعیین اعتبار تاریخ و زمان رشته‌ای شمسی
        /// با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴
        /// </summary>
        /// <param name="persianDateTime">تاریخ و زمان شمسی</param>
        /// <param name="throwOnException"></param>
        public static bool IsValidPersianDateTime(this string persianDateTime, bool throwOnException = false)
        {
            try
            {
                var dt = persianDateTime.ToGregorianDateTime();
                return dt.HasValue;
            }
            catch
            {
                if (throwOnException)
                {
                    throw;
                }
                return false;
            }
        }

        /// <summary>
        /// تبدیل تاریخ و زمان رشته‌ای شمسی به میلادی
        /// با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴
        /// در اینجا اگر رشته‌ی مدنظر قابل تبدیل نباشد، مقدار نال را دریافت خواهید کرد
        /// </summary>
        /// <param name="persianDateTime">تاریخ و زمان شمسی</param>
        /// <param name="convertToUtc">Converts the value of the current DateTime to Coordinated Universal Time (UTC)</param>
        /// <returns>تاریخ و زمان میلادی</returns>
        public static DateTime? ToGregorianDateTime(this string persianDateTime, bool convertToUtc = false)
        {
            if (string.IsNullOrWhiteSpace(persianDateTime))
            {
                return null;
            }

            persianDateTime = persianDateTime.Trim().ToEnglishNumbers();
            var splitedDateTime = persianDateTime.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rawTime = Array.Find(splitedDateTime, s => s.Contains(':'));
            var rawDate = Array.Find(splitedDateTime, s => !s.Contains(':'));

            var splitedDate = rawDate?.Split('/', ',', '؍', '.', '-');
            if (splitedDate?.Length != 3)
            {
                return null;
            }

            var day = getDay(splitedDate[2]);
            if (!day.HasValue)
            {
                return null;
            }

            var month = getMonth(splitedDate[1]);
            if (!month.HasValue)
            {
                return null;
            }

            var year = getYear(splitedDate[0]);
            if (!year.HasValue)
            {
                return null;
            }

            if (!IsValidPersianDate(year.Value, month.Value, day.Value))
            {
                return null;
            }

            var hour = 0;
            var minute = 0;
            var second = 0;

            if (!string.IsNullOrWhiteSpace(rawTime))
            {
                var splitedTime = rawTime.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                hour = int.Parse(splitedTime[0], CultureInfo.InvariantCulture);
                minute = int.Parse(splitedTime[1], CultureInfo.InvariantCulture);
                if (splitedTime.Length > 2)
                {
                    var lastPart = splitedTime[2].Trim();
                    var formatInfo = Instance.DateTimeFormat;
                    if (lastPart.Equals(formatInfo.PMDesignator, StringComparison.OrdinalIgnoreCase))
                    {
                        if (hour < 12)
                        {
                            hour += 12;
                        }
                    }
                    else
                    {
                        if (!int.TryParse(lastPart, NumberStyles.Number, CultureInfo.InvariantCulture, out second))
                        {
                            second = 0;
                        }
                    }
                }
            }

            var persianCalendar = new PersianCalendar();
            var dateTime = persianCalendar.ToDateTime(year.Value, month.Value, day.Value, hour, minute, second, 0);
            if (convertToUtc)
            {
                dateTime = dateTime.ToUniversalTime();
            }
            return dateTime;
        }

        /// <summary>
        /// تبدیل تاریخ و زمان رشته‌ای شمسی به میلادی
        /// با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴
        /// در اینجا اگر رشته‌ی مدنظر قابل تبدیل نباشد، مقدار نال را دریافت خواهید کرد
        /// </summary>
        /// <param name="persianDateTime">تاریخ و زمان شمسی</param>
        /// <returns>تاریخ و زمان میلادی</returns>
        public static DateTimeOffset? ToGregorianDateTimeOffset(this string persianDateTime)
        {
            var dateTime = persianDateTime.ToGregorianDateTime();
            if (dateTime == null)
            {
                return null;
            }

            return new DateTimeOffset(dateTime.Value, DateTimeUtils.IranStandardTime.BaseUtcOffset);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToLongPersianDateString(this DateTime dt, bool convertToIranTimeZone = true)
        {
            return dt.ToPersianDateTimeString(Instance.DateTimeFormat.LongDatePattern, convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToLongPersianDateString(this DateTime? dt, bool convertToIranTimeZone = true)
        {
            return dt == null ? string.Empty : ToLongPersianDateString(dt.Value, convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string ToLongPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return dt == null ? string.Empty : ToLongPersianDateString(dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string ToLongPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return ToLongPersianDateString(dt.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToLongPersianDateTimeString(this DateTime dt, bool convertToIranTimeZone = true)
        {
            return dt.ToPersianDateTimeString(
                $"{Instance.DateTimeFormat.LongDatePattern}، {Instance.DateTimeFormat.LongTimePattern}",
                convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToLongPersianDateTimeString(this DateTime? dt, bool convertToIranTimeZone = true)
        {
            return dt == null ? string.Empty : ToLongPersianDateTimeString(dt.Value, convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string ToLongPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return dt == null ? string.Empty : ToLongPersianDateTimeString(dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static string ToLongPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return ToLongPersianDateTimeString(dt.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dateTime"></param>
        /// <param name="format"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToPersianDateTimeString(this DateTime dateTime, string format, bool convertToIranTimeZone = true)
        {
            if (dateTime.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                dateTime = dateTime.ToIranTimeZoneDateTime();
            }
            return dateTime.ToString(format, Instance);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
        /// </summary>
        /// <param name="gregorianDate">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static PersianDay ToPersianYearMonthDay(this DateTimeOffset? gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return gregorianDate == null ?
               throw new ArgumentNullException(nameof(gregorianDate)) :
               ToPersianYearMonthDay(gregorianDate.Value.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
        /// </summary>
        /// <param name="gregorianDate"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static PersianDay ToPersianYearMonthDay(this DateTime? gregorianDate, bool convertToIranTimeZone = true)
        {
            return gregorianDate == null ?
                throw new ArgumentNullException(nameof(gregorianDate)) :
                ToPersianYearMonthDay(gregorianDate.Value, convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
        /// </summary>
        /// <param name="gregorianDate">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        public static PersianDay ToPersianYearMonthDay(this DateTimeOffset gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return ToPersianYearMonthDay(gregorianDate.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
        /// </summary>
        /// <param name="gregorianDate"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static PersianDay ToPersianYearMonthDay(this DateTime gregorianDate, bool convertToIranTimeZone = true)
        {
            if (gregorianDate.Kind == DateTimeKind.Utc && convertToIranTimeZone)
            {
                gregorianDate = gregorianDate.ToIranTimeZoneDateTime();
            }

            var persianCalendar = new PersianCalendar();
            var persianYear = persianCalendar.GetYear(gregorianDate);
            var persianMonth = persianCalendar.GetMonth(gregorianDate);
            var persianDay = persianCalendar.GetDayOfMonth(gregorianDate);
            return new PersianDay { Year = persianYear, Month = persianMonth, Day = persianDay };
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToShortPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return dt == null ? string.Empty : ToShortPersianDateString(dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToShortPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return ToShortPersianDateString(dt.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToShortPersianDateString(this DateTime dt, bool convertToIranTimeZone = true)
        {
            return dt.ToPersianDateTimeString(Instance.DateTimeFormat.ShortDatePattern, convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToShortPersianDateString(this DateTime? dt, bool convertToIranTimeZone = true)
        {
            return dt == null ? string.Empty : ToShortPersianDateString(dt.Value, convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21 10:20
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToShortPersianDateTimeString(this DateTime dt, bool convertToIranTimeZone = true)
        {
            return dt.ToPersianDateTimeString(
                $"{Instance.DateTimeFormat.ShortDatePattern} {Instance.DateTimeFormat.ShortTimePattern}",
                convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21 10:20
        /// </summary>
        /// <returns>تاریخ شمسی</returns>
        /// <param name="dt"></param>
        /// <param name="convertToIranTimeZone">اگر تاریخ و زمان با فرمت UTC باشند، ابتدا آن‌ها را به منطقه‌ی زمانی ایران تبدیل می‌کند</param>
        public static string ToShortPersianDateTimeString(this DateTime? dt, bool convertToIranTimeZone = true)
        {
            return dt == null ? string.Empty : ToShortPersianDateTimeString(dt.Value, convertToIranTimeZone);
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21 10:20
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToShortPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return dt == null ? string.Empty : ToShortPersianDateTimeString(dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// با قالبی مانند 1395/10/21 10:20
        /// </summary>
        /// <param name="dt">تاریخ و زمان</param>
        /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToShortPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
        {
            return ToShortPersianDateTimeString(dt.GetDateTimeOffsetPart(dateTimeOffsetPart));
        }

        private static int? getDay(string part)
        {
            var day = part.toNumber();
            if (!day.Item1) return null;
            var pDay = day.Item2;
            if (pDay == 0 || pDay > 31) return null;
            return pDay;
        }

        private static int? getMonth(string part)
        {
            var month = part.toNumber();
            if (!month.Item1) return null;
            var pMonth = month.Item2;
            if (pMonth == 0 || pMonth > 12) return null;
            return pMonth;
        }

        private static int? getYear(string part)
        {
            var year = part.toNumber();
            if (!year.Item1) return null;
            var pYear = year.Item2;
            if (part.Length == 2) pYear += 1300;
            return pYear;
        }

        private static Tuple<bool, int> toNumber(this string data)
        {
            bool result = int.TryParse(data, NumberStyles.Number, CultureInfo.InvariantCulture, out var number);
            return new Tuple<bool, int>(result, number);
        }
    }

    public class PersianDay
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }

    public class DateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}