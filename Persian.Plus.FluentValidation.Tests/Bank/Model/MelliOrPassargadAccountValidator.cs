using FluentValidation;

namespace Persian.Plus.FluentValidation.Tests.Bank.Model
{
    public class MelliOrPassargadAccountValidator : AbstractValidator<BankAccountInfo>
    {
        public MelliOrPassargadAccountValidator()
        {
            RuleFor(x => x.IbanNumber)
                .IbanNumber(IranBankConstants.BankCodes.Melli, IranBankConstants.BankCodes.Passargad);
            RuleFor(x => x.ShetabCardNumber)
                .ShetabCardNumber(IranBankConstants.BankCardBins.Melli, IranBankConstants.BankCardBins.Passargad);
        }
    }
}