using System;
using System.Globalization;
using System.Linq;

namespace Persian.Plus.Core.DateTime
{
    public class HijriDate
    {
        private HijriDate()
        {
        }
        
        public HijriDate(System.DateTime dateTime) : this()
        {
            DateTime = dateTime;
            this.Year = Calendar.GetYear(dateTime);
            this.Month = Calendar.GetMonth(dateTime);
            this.Day = Calendar.GetDayOfMonth(dateTime);
        }

        public HijriDate(int year, int month, int day) : this()
        {
            this.DateTime =  Calendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
        
        public HijriCalendar Calendar { get; } = new HijriCalendar();
        public CultureInfo CultureInfo { get; }
        public System.DateTime DateTime { get; }
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public HijriDate AddYears(int years)
        {
            return new HijriDate(Calendar.AddYears(this.DateTime, years));
        }
        public HijriDate AddMonths(int months)
        {
            return new HijriDate(Calendar.AddMonths(this.DateTime, months));
        }
        public HijriDate AddDays(int days)
        {
            return new HijriDate(Calendar.AddDays(this.DateTime, days));
        }

        public static HijriDate Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new FormatException();
            }

            var parts = s.Split(new[] {'/', '-', ','});
            var temp = 0;
            if (parts.Length != 3 || parts.Any(x => int.TryParse((string?) x, out temp)))
            {
                throw new FormatException();
            }

            var parsedParts = parts.Select(int.Parse).ToList();
            return new HijriDate(parsedParts[0], parsedParts[1], parsedParts[2]);
        }

        public static bool TryParse(string s, out HijriDate pd)
        {
            try
            {
                pd = HijriDate.Parse(s);
                return true;
            }
            catch (Exception e)
            {
                pd = null;
                return false;
            }
        }
        
        public static HijriDate Now => new HijriDate(System.DateTime.Now);
        public static implicit operator System.DateTime(HijriDate d) => d.DateTime;
        public static implicit operator HijriDate(System.DateTime d) => new HijriDate(d);
    }
}