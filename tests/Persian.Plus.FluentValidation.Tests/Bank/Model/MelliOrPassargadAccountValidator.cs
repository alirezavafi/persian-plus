using FluentValidation;

namespace Persian.Plus.FluentValidation.Tests.Bank.Model
{
    public class MelliOrPassargadAccountValidator : AbstractValidator<BankAccountInfo>
    {
        public MelliOrPassargadAccountValidator()
        {
            RuleFor(x => x.IbanNumber)
                .IranianIbanNumber(IranBankConstants.BankCodes.Melli, IranBankConstants.BankCodes.Passargad);
            RuleFor(x => x.ShetabCardNumber)
                .IranianShetabCardNumber(IranBankConstants.BankCardBins.Melli, IranBankConstants.BankCardBins.Passargad);
        }
    }
}