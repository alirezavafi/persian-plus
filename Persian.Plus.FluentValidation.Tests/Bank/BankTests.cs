using NUnit.Framework;
using Persian.Plus.FluentValidation.Tests.Bank.Model;

namespace Persian.Plus.FluentValidation.Tests.Bank
{
    public class BankTests
    {
        private BankAccountInfoValidator _validator;
        private MelliOrPassargadAccountValidator _melliOrPassargadValidator;

        [SetUp]
        public void Setup()
        {
            _validator = new BankAccountInfoValidator();
            _melliOrPassargadValidator = new MelliOrPassargadAccountValidator();
        }

        [Test]
        public void Validator_Validate_Valid_IbanNumber()
        {
            var c = new BankAccountInfo()
            {
                IbanNumber = "IR930150000001351800087201" 
            };

            var results = _validator.Validate(c);
            
            Assert.IsTrue(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_NotValid_IbanNumber()
        {
            var c = new BankAccountInfo()
            {
                IbanNumber = "IR930150000001351800087200" 
            };

            var results = _validator.Validate(c);
            
            Assert.IsFalse(results.IsValid);
        }

        [Test]
        public void Validator_Validate_Valid_IbanNumber_For_Melli_Passargad()
        {
            var melli = new BankAccountInfo() { IbanNumber = "IR180170000000205511280008" };
            var passargad = new BankAccountInfo() { IbanNumber = "IR050570035381011322983101" };
            var sepah = new BankAccountInfo() { IbanNumber = "IR930150000001351800087201" };
            var melliResult = _melliOrPassargadValidator.Validate(melli);
            var passargadResult = _melliOrPassargadValidator.Validate(passargad);
            var sepahResult = _melliOrPassargadValidator.Validate(sepah);
            
            Assert.IsTrue(melliResult.IsValid);
            Assert.IsTrue(passargadResult.IsValid);
            Assert.IsFalse(sepahResult.IsValid);
        }

        [Test]
        public void Validator_Validate_Valid_ShetabCardNumber()
        {
            var c = new BankAccountInfo()
            {
                ShetabCardNumber = "6037991199500590"
            };

            var results = _validator.Validate(c);
            
            Assert.IsTrue(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_NotValid_ShetabCardNumber()
        {
            var c = new BankAccountInfo()
            {
                ShetabCardNumber = "6037991199500591" 
            };

            var results = _validator.Validate(c);
            
            Assert.IsFalse(results.IsValid);
        }
        
        [Test]
        public void Validator_Validate_Valid_ShetabCardNumber_For_Melli_Passargad()
        {
            var melli = new BankAccountInfo() { ShetabCardNumber = "6037991199500590" };
            var passargad = new BankAccountInfo() { ShetabCardNumber = "5022297000154406" };
            var eghtesadNovin = new BankAccountInfo() { ShetabCardNumber = "6274121940067465" };
            var melliResult = _melliOrPassargadValidator.Validate(melli);
            var passargadResult = _melliOrPassargadValidator.Validate(passargad);
            var eghtesadNovinResult = _melliOrPassargadValidator.Validate(eghtesadNovin);
            
            Assert.IsTrue(melliResult.IsValid);
            Assert.IsTrue(passargadResult.IsValid);
            Assert.IsFalse(eghtesadNovinResult.IsValid);
        }
    }
}