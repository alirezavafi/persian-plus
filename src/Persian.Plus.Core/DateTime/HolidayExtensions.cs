using System.Collections.Generic;

namespace Persian.Plus.Core.DateTime
{
    public static class HolidayExtensions
    {
        public static IEnumerable<EventDay> GetEvents(this PersianDateTime date)
        {
            return new HoliDaysData().GetEventsByDateRange(new DateRange()
            {
                StartDate = date,
                EndDate = date,
            });
        }
        
        public static IEnumerable<EventDay> GetEventsTill(this PersianDateTime from, PersianDateTime to)
        {
            return new HoliDaysData().GetEventsByDateRange(new DateRange()
            {
                StartDate = from,
                EndDate = to,
            });
        }

    }
}