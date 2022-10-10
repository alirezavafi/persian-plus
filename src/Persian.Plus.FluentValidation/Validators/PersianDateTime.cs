using FluentValidation;
using FluentValidation.Validators;
using Persian.Plus.DateTime;

namespace Persian.Plus.FluentValidation.Validators
{
    public class PersianDateTime<T> : PropertyValidator<T, string>
    {
        public override string Name => "PersianDateTime";

        public override bool IsValid(ValidationContext<T> context, string value) {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            return PersianDateTime.TryParse(value, out PersianDateTime temp);
        }
    }
}