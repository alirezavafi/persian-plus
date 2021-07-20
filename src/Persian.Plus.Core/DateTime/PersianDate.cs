using System;

namespace Persian.Plus.Core.DateTime
{
    [Obsolete]
    public class PersianDate : PersianDateTime
    {
        public PersianDate(System.DateTime dateTime) : base(dateTime)
        {
        }

        public PersianDate(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int milisecond = 0) : base(year, month, day, hour, minute, second, milisecond)
        {
        }
    }
}