using NUnit.Framework;
using Persian.Plus.Extensions;
using Persian.Plus.Extensions.Normalizer;

namespace Persian.Plus.Tests
{
    public class IranianPhoneNumberExtensionsTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ContainsOnlyPersianOrEnglishLetters_Must_Match_Valid_Value()
        {
            var c1 = "علیرضا وفی";
            var c2 = "Alireza Vafi";
            var c3 = "علیرضا وفی Alireza Vafi";

            Assert.IsTrue(c1.ContainsOnlyPersianOrEnglishLetters());
            Assert.IsTrue(c2.ContainsOnlyPersianOrEnglishLetters());
            Assert.IsTrue(c3.ContainsOnlyPersianOrEnglishLetters());
        }

        [Test]
        public void ContainsOnlyPersianOrEnglishLetters_Must_Not_Match_Invalid_Value()
        {
            var c1 = "علیرضا وفی 123";
            var c2 = "Alireza Vafi !=%";
            var c3 = "+ 1 علیرضا وفی Alireza Vafi";

            Assert.IsFalse(c1.ContainsOnlyPersianOrEnglishLetters());
            Assert.IsFalse(c2.ContainsOnlyPersianOrEnglishLetters());
            Assert.IsFalse(c3.ContainsOnlyPersianOrEnglishLetters());
        }
        
        [Test]
        public void ContainsOnlyPersianOrEnglishLettersOrDigits_Must_Match_Valid_Value()
        {
            var c1 = "123 علیرضا وفی";
            var c2 = "Alireza Vafi";
            var c3 = "علیرضا وفی Alireza Vafi";
            var c4= "123";

            Assert.IsTrue(c1.ContainsOnlyPersianOrEnglishLettersOrDigits());
            Assert.IsTrue(c2.ContainsOnlyPersianOrEnglishLettersOrDigits());
            Assert.IsTrue(c3.ContainsOnlyPersianOrEnglishLettersOrDigits());
            Assert.IsTrue(c4.ContainsOnlyPersianOrEnglishLettersOrDigits());
        }

        [Test]
        public void ContainsOnlyPersianOrEnglishLettersOrDigits_Must_Not_Match_Invalid_Value()
        {
            var c1 = "!=% علیرضا وفی 123";
            var c2 = "Alireza Vafi !=%";
            var c3 = "+ 1 علیرضا وفی Alireza Vafi";

            Assert.IsFalse(c1.ContainsOnlyPersianOrEnglishLettersOrDigits());
            Assert.IsFalse(c2.ContainsOnlyPersianOrEnglishLettersOrDigits());
            Assert.IsFalse(c3.ContainsOnlyPersianOrEnglishLettersOrDigits());
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

