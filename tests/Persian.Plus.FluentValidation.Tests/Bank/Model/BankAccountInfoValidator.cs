using FluentValidation;
using Persian.Plus.FluentValidation.Extensions;

namespace Persian.Plus.FluentValidation.Tests.Bank.Model
{
    public class BankAccountInfoValidator : AbstractValidator<BankAccountInfo>
    {
        public BankAccountInfoValidator()
        {
            RuleFor(x => x.IbanNumber)
                .IranianIbanNumber();
            RuleFor(x => x.ShetabCardNumber)
                .IranianShetabCardNumber();
        }
    }
}