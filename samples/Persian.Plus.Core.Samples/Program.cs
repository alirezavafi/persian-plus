using System;
using System.Linq;
using Persian.Plus.Core.DateTime;

namespace Persian.Plus.Core.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var pd = new PersianDateTime(System.DateTime.Now);
            Console.WriteLine($"Today is {pd:yyyy-MM-dd}");
            var events = new PersianDateTime(1400, 1, 1).GetEventsTill(new PersianDateTime(1400, 12, 29));
            var holidays = events.Where(x => x.EventType.HasFlag(EventType.Holiday));

            foreach (var eventDay in holidays)
            {
                Console.WriteLine($"Holiday {new PersianDateTime(eventDay.DateTime):yyyy-MM-dd} {eventDay.Description}");
            }
        }
    }
}