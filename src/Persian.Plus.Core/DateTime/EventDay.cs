using System;

namespace Persian.Plus.Core.DateTime
{
    public class EventDay
    {
        public string Description { get; init; }
        public SpecialDay SpecialDay { get; init; } 
        public System.DateTime DateTime { get; init; }
        public CalenderType CalenderType { get; init; }
        public EventType EventType { get; init; }
        public int? OriginYear { get; init; }

        public EventDay()
        {
        }

        public EventDay(int year, int month, int day, CalenderType calenderType, EventType eventType,
            string description, SpecialDay specialDay = SpecialDay.None) : this(null, year, month, day, calenderType, eventType, description, specialDay)
        { }

        public EventDay(int? originYear, int year, int month, int day, CalenderType calenderType, EventType eventType, string description, SpecialDay specialDay = SpecialDay.None)
        {
            switch (calenderType)
            {
                case CalenderType.PersianCalendar:
                    this.DateTime = new PersianDate(year, month, day);
                    break;
                case CalenderType.HijriCalendar:
                    this.DateTime = new HijriDate(year, month, day);
                    break;
                case CalenderType.GregorianCalendar:
                    this.DateTime = new System.DateTime(year, month, day);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(calenderType), calenderType, null);
            }
            
            this.CalenderType = calenderType;
            this.EventType = eventType;
            this.Description = description;
            this.SpecialDay = specialDay;
            this.OriginYear = originYear;
        }
    }
}