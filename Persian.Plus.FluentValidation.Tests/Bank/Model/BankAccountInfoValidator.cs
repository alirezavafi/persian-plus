using FluentValidation;

namespace Persian.Plus.FluentValidation.Tests.Bank.Model
{
    public class BankAccountInfoValidator : AbstractValidator<BankAccountInfo>
    {
        public BankAccountInfoValidator()
        {
            RuleFor(x => x.IbanNumber)
                .IbanNumber();
            RuleFor(x => x.ShetabCardNumber)
                .ShetabCardNumber();
        }
    }
}