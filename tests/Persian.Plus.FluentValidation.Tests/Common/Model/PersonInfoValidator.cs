using FluentValidation;

namespace Persian.Plus.FluentValidation.Tests.Common.Model
{
    public class PersonInfoValidator : AbstractValidator<PersonInfo>
    {
        public PersonInfoValidator()
        {
            RuleFor(x => x.NationalCode)
                .IranianNationalCode();
        }
    }
}