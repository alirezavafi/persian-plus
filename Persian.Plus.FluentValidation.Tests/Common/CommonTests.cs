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
    }
}

