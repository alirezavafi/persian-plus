using NUnit.Framework;
using Persian.Plus.Extensions;

namespace Persian.Plus.Tests
{
    public class IranianPhoneNumberExtensionsTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MobileNumber_Must_Coerce()
        {
            var c1 = "09121234567";
            var c2 = "989121234567";
            var c3 = "+989121234567";
            var c4 = "9809121234567";
            var c5 = "00989121234567";
            var c6 = "9121234567";

            var expectedValue = "9121234567";
            
            Assert.AreEqual(expectedValue, c1.CoerceIranianMobileNumber());
            Assert.AreEqual(expectedValue, c2.CoerceIranianMobileNumber());
            Assert.AreEqual(expectedValue, c3.CoerceIranianMobileNumber());
            Assert.AreEqual(expectedValue, c4.CoerceIranianMobileNumber());
            Assert.AreEqual(expectedValue, c5.CoerceIranianMobileNumber());
            Assert.AreEqual(expectedValue, c6.CoerceIranianMobileNumber());
        }
        
        [Test]
        public void MobileNumber_Must_Validate()
        {
            var c1 = "09121234567";
            var c2 = "989121234567";
            var c3 = "+989121234567";
            var c4 = "9809121234567";
            var c5 = "00989121234567";
            var c6 = "9121234567";

            Assert.IsTrue(c1.IsValidIranianMobileNumber());
            Assert.IsTrue(c2.IsValidIranianMobileNumber());
            Assert.IsTrue(c3.IsValidIranianMobileNumber());
            Assert.IsTrue(c4.IsValidIranianMobileNumber());
            Assert.IsTrue(c5.IsValidIranianMobileNumber());
            Assert.IsTrue(c6.IsValidIranianMobileNumber());
        }
    }
}

