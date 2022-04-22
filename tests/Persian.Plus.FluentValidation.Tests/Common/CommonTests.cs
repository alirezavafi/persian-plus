using NUnit.Framework;
using Persian.Plus.FluentValidation.Tests.Common.Model;

namespace Persian.Plus.FluentValidation.Tests.Common
{
    public class CommonTests
    {
        private PersonInfoValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PersonInfoValidator();
        }

        [Test]
        public void Validator_Validate_Valid_Persian_Letters_Only()
        {
            var c = new PersonInfo() { Name = "علیرضا وفی" };

            var res = _validator.Validate(c);
            
            Assert.IsTrue(res.IsValid);
        }
        
        [Test]
        public void Validator_Validate_NotValid_Persian_Letters_Only()
        {
            var c1 = new PersonInfo() { Name = "علیرضا وفی 123" };
            var c2 = new PersonInfo() { Name = "علیرضا وفی Alireza Vafi" };
            var c3 = new PersonInfo() { Name = "Alireza Vafi" };

            var res1 = _validator.Validate(c1);
            var res2 = _validator.Validate(c2);
            var res3 = _validator.Validate(c3);
            
            Assert.IsFalse(res1.IsValid);
            Assert.IsFalse(res2.IsValid);
            Assert.IsFalse(res3.IsValid);
        }

        [Test]
        public void Validator_Validate_Valid_IranianNationalCodeNumber()
        {
            var c = new PersonInfo()
            {
                NationalCode = "0791210804"
            };

            var results = _validator.Validate(c);
            
            Assert.IsTrue(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_NotValid_IranianNationalCodeNumber()
        {
            var c = new PersonInfo()
            {
                NationalCode = "0791210803"
            };

            var results = _validator.Validate(c);
            
            Assert.IsFalse(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_Valid_IranianNationalLegalCodeNumber()
        {
            var c = new PersonInfo()
            {
                NationalLegalCode = "14008071029"
            };

            var results = _validator.Validate(c);
            
            Assert.IsTrue(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_NotValid_IranianNationalLegalCodeNumber()
        {
            var c = new PersonInfo()
            {
                NationalLegalCode = "14008071128"
            };

            var results = _validator.Validate(c);
            
            Assert.IsFalse(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_Valid_IranianPostalCode()
        {
            var c = new PersonInfo()
            {
                PostalCode = "3149813475"
            };

            var results = _validator.Validate(c);
            
            Assert.IsTrue(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_NotValid_IranianPostalCode()
        {
            var c1 = new PersonInfo() { PostalCode = "1234324" };
            var c2 = new PersonInfo() { PostalCode = "3145435123" };

            var result1 = _validator.Validate(c1);
            var result2 = _validator.Validate(c2);
            
            Assert.IsFalse(result1.IsValid);
            Assert.IsFalse(result2.IsValid);
        }
        
        [Test]
        public void Validator_Validate_Valid_IranianMobileNumber()
        {
            var c1 = new PersonInfo() { MobileNumber = "09361234567" };
            var c2 = new PersonInfo() { MobileNumber = "989121234567" };
            var c3 = new PersonInfo() { MobileNumber = "+989121234567" };
            var c4 = new PersonInfo() { MobileNumber = "9809121234567" };
            var c5 = new PersonInfo() { MobileNumber = "00989121234567" };
            var c6 = new PersonInfo() { MobileNumber = "9121234567" };
            var c7 = new PersonInfo() { MobileNumber = "9021234567" };

            var res1 = _validator.Validate(c1);
            var res2 = _validator.Validate(c2);
            var res3 = _validator.Validate(c3);
            var res4 = _validator.Validate(c4);
            var res5 = _validator.Validate(c5);
            var res6 = _validator.Validate(c6);
            var res7 = _validator.Validate(c7);
            
            Assert.IsTrue(res1.IsValid);
            Assert.IsTrue(res2.IsValid);
            Assert.IsTrue(res3.IsValid);
            Assert.IsTrue(res4.IsValid);
            Assert.IsTrue(res5.IsValid);
            Assert.IsTrue(res6.IsValid);
            Assert.IsTrue(res7.IsValid);
        }
        
        [Test]
        public void Validator_Validate_NotValid_IranianMobileNumber()
        {
            var c1 = new PersonInfo() { MobileNumber = "8021234567" };
            var c2 = new PersonInfo() { MobileNumber = "988021234567" };
            var c3 = new PersonInfo() { MobileNumber = "+988021234567" };
            var c4 = new PersonInfo() { MobileNumber = "008021234567" };

            var res1 = _validator.Validate(c1);
            var res2 = _validator.Validate(c2);
            var res3 = _validator.Validate(c3);
            var res4 = _validator.Validate(c4);
            
            Assert.IsFalse(res1.IsValid);
            Assert.IsFalse(res2.IsValid);
            Assert.IsFalse(res3.IsValid);
            Assert.IsFalse(res4.IsValid);
        }
    }
}

