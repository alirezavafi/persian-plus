using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Persian.Plus.Core.DateTime
{
    public class PersianDateTime :
        IFormattable, IConvertible,
        IComparable<PersianDateTime>, IComparable<System.DateTime>,
        IEquatable<PersianDateTime>, IEquatable<System.DateTime>
    {
        private const string DefaultStringFormat = "yyyy/MM/dd HH:mm:ss";

        static PersianDateTime()
        {
            CultureInfo = GetPersianCulture();
        }

        public static PersianCalendar Calendar { get; } = new PersianCalendar();
        public static CultureInfo CultureInfo { get; }


        public PersianDateTime(System.DateTime dateTime)
        {
            DateTime = dateTime;
            this.Year = Calendar.GetYear(dateTime);
            this.Month = Calendar.GetMonth(dateTime);
            this.Day = Calendar.GetDayOfMonth(dateTime);
        }

        public PersianDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0,
            int milisecond = 0)
        {
            this.DateTime = Calendar.ToDateTime(year, month, day, hour, minute, second, milisecond);
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
        public System.DateTime DateTime { get; }
        public DayOfWeek DayOfWeek => Calendar.GetDayOfWeek(DateTime);
        public TimeSpan TimeOfDay => DateTime.TimeOfDay;
        public bool IsLeapYear => Calendar.IsLeapYear(Year);
        public int DaysInMonth => Calendar.GetDaysInMonth(Year, Month);

        public PersianDateTime AddYears(int years)
        {
            return new PersianDateTime(Calendar.AddYears(this.DateTime, years));
        }

        public PersianDateTime AddMonths(int months)
        {
            return new PersianDateTime(Calendar.AddMonths(this.DateTime, months));
        }

        public PersianDateTime AddDays(int days)
        {
            return new PersianDateTime(Calendar.AddDays(this.DateTime, days));
        }

        private static CultureInfo GetPersianCulture()
        {
            var persianCulture = new CultureInfo("fa-IR")
            {
                DateTimeFormat =
                {
                    AbbreviatedDayNames = new[] {"ی", "د", "س", "چ", "پ", "ج", "ش"},
                    AbbreviatedMonthGenitiveNames =
                        new[]
                        {
                            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                            "بهمن", "اسفند", string.Empty
                        },
                    AbbreviatedMonthNames =
                        new[]
                        {
                            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                            "بهمن", "اسفند", string.Empty
                        },
                    AMDesignator = "ق.ظ",
                    CalendarWeekRule = CalendarWeekRule.FirstDay,
                    //DateSeparator = "؍",
                    DayNames = new[] {"یکشنبه", "دوشنبه", "سه‌شنبه", "چهار‌شنبه", "پنجشنبه", "جمعه", "شنبه"},
                    FirstDayOfWeek = DayOfWeek.Saturday,
                    FullDateTimePattern = "dddd dd MMMM yyyy",
                    LongDatePattern = "dd MMMM yyyy",
                    LongTimePattern = "h:mm:ss tt",
                    MonthDayPattern = "dd MMMM",
                    MonthGenitiveNames =
                        new[]
                        {
                            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                            "بهمن", "اسفند", string.Empty
                        },
                    MonthNames =
                        new[]
                        {
                            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                            "بهمن", "اسفند", string.Empty
                        },
                    PMDesignator = "ب.ظ",
                    ShortDatePattern = "yyyy/MM/dd",
                    ShortestDayNames = new[] {"ی", "د", "س", "چ", "پ", "ج", "ش"},
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
            {DayOfWeek.Sunday, "یک شنبه"},
            {DayOfWeek.Monday, "دو شنبه"},
            {DayOfWeek.Tuesday, "سه شنبه"},
            {DayOfWeek.Wednesday, "چهار شنبه"},
            {DayOfWeek.Thursday, "پنج شنبه"},
            {DayOfWeek.Friday, "جمعه"}
        };

        public static IDictionary<int, string> PersianMonthDayNumberNames { get; } = new Dictionary<int, string>
        {
            {1, "یکم"},
            {2, "دوم"},
            {3, "سوم"},
            {4, "چهارم"},
            {5, "پنجم"},
            {6, "ششم"},
            {7, "هفتم"},
            {8, "هشتم"},
            {9, "نهم"},
            {10, "دهم"},
            {11, "یازدهم"},
            {12, "دوازدهم"},
            {13, "سیزدهم"},
            {14, "چهاردهم"},
            {15, "پانزدهم"},
            {16, "شانزدهم"},
            {17, "هفدهم"},
            {18, "هجدهم"},
            {19, "نوزدهم"},
            {20, "بیستم"},
            {21, "بیست یکم"},
            {22, "بیست دوم"},
            {23, "بیست سوم"},
            {24, "بیست چهارم"},
            {25, "بیست پنجم"},
            {26, "بیست ششم"},
            {27, "بیست هفتم"},
            {28, "بیست هشتم"},
            {29, "بیست نهم"},
            {30, "سی‌ام"},
            {31, "سی یکم"}
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

        public static PersianDateTime Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new FormatException();
            }

            var parts = s.Split(new[] {'/', '-', ',', ' ', '.', ':'}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3 || parts.Any(x => !int.TryParse(x.TrimStart('0'), out var temp)))
            {
                throw new FormatException("invalid input");
            }

            var parsedParts = parts.Select(int.Parse).ToList();
            if (parsedParts.Count >= 6)
            {
                return new PersianDateTime(parsedParts[0], parsedParts[1], parsedParts[2], parsedParts[3],
                    parsedParts[4], parsedParts[5]);
            }

            return new PersianDateTime(parsedParts[0], parsedParts[1], parsedParts[2]);
        }

        public static bool TryParse(string s, out PersianDateTime pd)
        {
            try
            {
                pd = PersianDateTime.Parse(s);
                return true;
            }
            catch (Exception e)
            {
                pd = null;
                return false;
            }
        }

        public static PersianDateTime Now => new PersianDateTime(System.DateTime.Now);
        public static implicit operator System.DateTime(PersianDateTime d) => d.DateTime;
        public static implicit operator PersianDateTime(System.DateTime d) => new PersianDateTime(d);

        public static bool operator ==(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2) => persianDateTime1.Equals(persianDateTime2);

        public static bool operator !=(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2) => !persianDateTime1.Equals(persianDateTime2);

        public static bool operator >(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2) => persianDateTime1.DateTime > persianDateTime2.DateTime;

        public static bool operator <(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2) => persianDateTime1.DateTime < persianDateTime2.DateTime;

        public static bool operator >=(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2) => persianDateTime1.DateTime >= persianDateTime2.DateTime;

        public static bool operator <=(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2) => persianDateTime1.DateTime <= persianDateTime2.DateTime;

        public static PersianDateTime operator +(PersianDateTime persianDateTime1, TimeSpan timeSpanToAdd)
        {
            System.DateTime dateTime1 = persianDateTime1;
            return new PersianDateTime(dateTime1.Add(timeSpanToAdd));
        }

        public static TimeSpan operator -(PersianDateTime persianDateTime1, PersianDateTime persianDateTime2)
        {
            System.DateTime dateTime1 = persianDateTime1;
            System.DateTime dateTime2 = persianDateTime2;
            return dateTime1 - dateTime2;
        }

        public string ToString(string? format, IFormatProvider? formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = DefaultStringFormat;
            }

            var dateTimeString = format.Trim();

            dateTimeString = dateTimeString.Replace("yyyy", $"{Year:0000}");
            dateTimeString = dateTimeString.Replace("yy", $"{Year:00}");
            dateTimeString = dateTimeString.Replace("MMMM", PersianMonthNames[Month]);
            dateTimeString = dateTimeString.Replace("MM", $"{Month:00}");
            dateTimeString = dateTimeString.Replace("M", $"{Month:##}");
            dateTimeString = dateTimeString.Replace("dddd", $"{PersianDayWeekNames[DayOfWeek]} {Day:00}");
            dateTimeString = dateTimeString.Replace("dd", $"{Day:00}");
            dateTimeString = dateTimeString.Replace("d", $"{Day:##}");
            dateTimeString = dateTimeString.Replace("HH", $"{DateTime:HH}");
            //dateTimeString = dateTimeString.Replace("H", $"{DateTime:H}");
            //dateTimeString = dateTimeString.Replace("h", $"{DateTime:h}");
            dateTimeString = dateTimeString.Replace("hh", $"{DateTime:hh}");
            dateTimeString = dateTimeString.Replace("mm", $"{DateTime:mm}");
            dateTimeString = dateTimeString.Replace("m", $"{DateTime:m}");
            dateTimeString = dateTimeString.Replace("ss", $"{DateTime:ss}");
            dateTimeString = dateTimeString.Replace("s", $"{DateTime:s}");
            dateTimeString = dateTimeString.Replace("tt", $"{DateTime:tt}");
            dateTimeString = dateTimeString.Replace("t", $"{DateTime:t}");
            dateTimeString = dateTimeString.Replace("fff", $"{DateTime:fff}");
            dateTimeString = dateTimeString.Replace("ff", $"{DateTime:ff}");
            dateTimeString = dateTimeString.Replace("f", $"{DateTime:f}");

            return dateTimeString;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.DateTime;
        }

        public bool ToBoolean(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public byte ToByte(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public char ToChar(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public System.DateTime ToDateTime(IFormatProvider? provider)
        {
            return DateTime;
        }

        public decimal ToDecimal(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public double ToDouble(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public short ToInt16(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public int ToInt32(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public long ToInt64(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public float ToSingle(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public string ToString(IFormatProvider? provider)
        {
            return ToString(string.Empty, null);
        }

        public object ToType(Type conversionType, IFormatProvider? provider)
        {
            switch (Type.GetTypeCode(conversionType))
            {
                case TypeCode.Boolean:
                    return ToBoolean(provider);
                case TypeCode.Byte:
                    return ToByte(provider);
                case TypeCode.Char:
                    return ToChar(provider);
                case TypeCode.DateTime:
                    return ToDateTime(provider);
                case TypeCode.Decimal:
                    return ToDecimal(provider);
                case TypeCode.Double:
                    return ToDouble(provider);
                case TypeCode.Int16:
                    return ToInt16(provider);
                case TypeCode.Int32:
                    return ToInt32(provider);
                case TypeCode.Int64:
                    return ToInt64(provider);
                case TypeCode.Object:
                    if (typeof(PersianDateTime) == conversionType)
                        return this;
                    if (typeof(System.DateTime) == conversionType)
                        return DateTime;
                    throw new InvalidCastException($"Conversion to a {conversionType.Name} is not supported.");
                case TypeCode.SByte:
                    return ToSByte(provider);
                case TypeCode.Single:
                    return ToSingle(provider);
                case TypeCode.String:
                    return ToString(provider);
                case TypeCode.UInt16:
                    return ToUInt16(provider);
                case TypeCode.UInt32:
                    return ToUInt32(provider);
                case TypeCode.UInt64:
                    return ToUInt64(provider);
                case TypeCode.DBNull:
                    break;
                case TypeCode.Empty:
                    break;
                default:
                    throw new InvalidCastException($"Conversion to {conversionType.Name} is not supported.");
            }

            throw new InvalidCastException();
        }

        public ushort ToUInt16(IFormatProvider? provider)
        {
            throw new InvalidCastException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public int CompareTo(PersianDateTime other)
        {
            return DateTime.CompareTo(other.DateTime);
        }

        public int CompareTo(System.DateTime other)
        {
            return DateTime.CompareTo(other);
        }

        public bool Equals(PersianDateTime other)
        {
            return DateTime.Equals(other.DateTime);
        }

        public bool Equals(System.DateTime other)
        {
            return DateTime.Equals(other);
        }
    }
}