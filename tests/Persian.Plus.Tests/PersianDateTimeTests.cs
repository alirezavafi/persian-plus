using System;
using System.Linq;
using NUnit.Framework;
using Persian.Plus.DateTime;

namespace Persian.Plus.Tests
{
    public class PersianDateTimeTests
    {
        [Test]
        public void Ctor_FromParts_Must_Set_Expected_Fields()
        {
            var pd = new PersianDateTime(1404, 1, 15, 10, 20, 30);

            Assert.AreEqual(1404, pd.Year);
            Assert.AreEqual(1, pd.Month);
            Assert.AreEqual(15, pd.Day);
            Assert.AreEqual(10, pd.TimeOfDay.Hours);
            Assert.AreEqual(20, pd.TimeOfDay.Minutes);
            Assert.AreEqual(30, pd.TimeOfDay.Seconds);
        }

        [Test]
        public void Ctor_FromDateTime_Must_Read_PersianDateParts()
        {
            var gregorian = new System.DateTime(2025, 3, 20, 8, 0, 0);
            var pd = new PersianDateTime(gregorian);

            Assert.AreEqual(1403, pd.Year);
            Assert.AreEqual(12, pd.Month);
            Assert.AreEqual(30, pd.Day);
        }

        [Test]
        public void Parse_Must_Support_EightDigitJalali()
        {
            var pd = PersianDateTime.Parse("14040102");

            Assert.AreEqual(1404, pd.Year);
            Assert.AreEqual(1, pd.Month);
            Assert.AreEqual(2, pd.Day);
            Assert.AreEqual("1404/01/02", pd.ToString("yyyy/MM/dd", null));
        }

        [Test]
        public void Parse_Must_Support_FourteenDigitJalaliDateTime()
        {
            var pd = PersianDateTime.Parse("14040102112233");

            Assert.AreEqual("1404/01/02 11:22:33", pd.ToString("yyyy/MM/dd HH:mm:ss", null));
        }

        [Test]
        public void Parse_Must_Support_UnixSeconds()
        {
            const long seconds = 1711900800;
            var expectedDateTime = DateTimeOffset.FromUnixTimeSeconds(seconds).LocalDateTime;

            var pd = PersianDateTime.Parse(seconds.ToString());

            Assert.AreEqual(expectedDateTime, pd.DateTime);
        }

        [Test]
        public void Parse_Must_Support_UnixMilliseconds()
        {
            const long milliseconds = 1711900800000;
            var expectedDateTime = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).LocalDateTime;

            var pd = PersianDateTime.Parse(milliseconds.ToString());

            Assert.AreEqual(expectedDateTime, pd.DateTime);
        }

        [Test]
        public void Parse_Must_Throw_FormatException_When_InvalidString()
        {
            Assert.Throws<FormatException>(() => PersianDateTime.Parse("invalid-date"));
        }

        [Test]
        public void TryParse_Must_ReturnFalse_And_Null_When_InvalidString()
        {
            var isValid = PersianDateTime.TryParse("invalid-date", out var pd);

            Assert.IsFalse(isValid);
            Assert.IsNull(pd);
        }

        [Test]
        public void AddMethods_Must_Return_Expected_Results()
        {
            var pd = new PersianDateTime(1404, 1, 1);

            Assert.AreEqual("1404/01/11", pd.AddDays(10).ToString("yyyy/MM/dd", null));
            Assert.AreEqual("1404/02/01", pd.AddMonths(1).ToString("yyyy/MM/dd", null));
            Assert.AreEqual("1405/01/01", pd.AddYears(1).ToString("yyyy/MM/dd", null));
        }

        [Test]
        public void Operators_ComparisonAndDifference_Must_Work()
        {
            var a = new PersianDateTime(1404, 1, 1);
            var b = new PersianDateTime(1404, 1, 2);

            Assert.IsTrue(a < b);
            Assert.IsTrue(b > a);
            Assert.IsTrue(a <= b);
            Assert.IsTrue(b >= a);
            Assert.AreEqual(TimeSpan.FromDays(1), b - a);
            Assert.AreEqual("1404/01/06", (a + TimeSpan.FromDays(5)).ToString("yyyy/MM/dd", null));
        }

        [Test]
        public void Operators_Equality_Must_Work()
        {
            var a = new PersianDateTime(1404, 1, 1);
            var b = new PersianDateTime(1404, 1, 1);
            var c = new PersianDateTime(1404, 1, 2);

            Assert.IsTrue(a == b);
            Assert.IsTrue(a != c);
        }

        [Test]
        public void ImplicitConversions_Must_Work_BothWays()
        {
            PersianDateTime pd = new System.DateTime(2025, 3, 21);
            System.DateTime dt = pd;
            PersianDateTime back = dt;

            Assert.AreEqual(dt, back.DateTime);
        }

        [Test]
        public void CompareAndEquals_Must_Work()
        {
            var a = new PersianDateTime(1404, 1, 1);
            var b = new PersianDateTime(1404, 1, 2);

            Assert.Less(a.CompareTo(b), 0);
            Assert.Greater(b.CompareTo(a), 0);
            Assert.IsTrue(a.Equals(new PersianDateTime(1404, 1, 1)));
            Assert.IsFalse(a.Equals(b));
        }

        [Test]
        public void ToString_WithPersianMonthName_Must_Work()
        {
            var pd = new PersianDateTime(1404, 1, 1);

            Assert.AreEqual("فروردین 1404", pd.ToString("MMMM yyyy", null));
        }

        [Test]
        public void HolidayExtensions_GetEventsTill_Must_Return_EventsInRange()
        {
            var from = new PersianDateTime(1404, 1, 1);
            var to = new PersianDateTime(1404, 1, 3);

            var events = from.GetEventsTill(to).ToList();

            Assert.IsNotNull(events);
            Assert.IsTrue(events.Count > 0);
            Assert.IsTrue(events.All(e => e.DateTime >= from.DateTime && e.DateTime <= to.DateTime));
        }
    }
}
