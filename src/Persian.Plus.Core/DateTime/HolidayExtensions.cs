using System.Collections.Generic;

namespace Persian.Plus.Core.DateTime
{
    public static class HolidayExtensions
    {
        public static IEnumerable<EventDay> GetEvents(this System.DateTime date)
        {
            return new HoliDaysData().GetEventsByDateRange(new DateRange()
            {
                StartDate = date,
                EndDate = date,
            });
        }
    }
}