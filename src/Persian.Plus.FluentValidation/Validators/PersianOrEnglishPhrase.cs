using FluentValidation;
using FluentValidation.Validators;
using Persian.Plus.Extensions;

namespace Persian.Plus.FluentValidation.Validators
{
    public class PersianOrEnglishPhrase<T> : PropertyValidator<T, string>
    {
        public override string Name => "PersianOrEnglishPhrase";

        public override bool IsValid(ValidationContext<T> context, string value) {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            return value.ContainsOnlyPersianOrEnglishPhrase();
        }
    }
}