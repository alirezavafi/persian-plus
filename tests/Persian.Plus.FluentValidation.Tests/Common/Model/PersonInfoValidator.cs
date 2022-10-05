using System.Data;
using FluentValidation;
using Persian.Plus.FluentValidation.Extensions;

namespace Persian.Plus.FluentValidation.Tests.Common.Model
{
    public class PersonInfoValidator : AbstractValidator<PersonInfo>
    {
        public PersonInfoValidator()
        {
            RuleFor(x => x.NationalCode)
                .IranianNationalCode();
            RuleFor(x => x.PostalCode)
                .IranianPostalCode();
            RuleFor(x => x.MobileNumber)
                .IranianMobileNumber();
            RuleFor(x => x.NationalLegalCode)
                .IranianNationalLegalCode();
            RuleFor(x => x.Name)
                .PersianLetters();
        }
    }
}