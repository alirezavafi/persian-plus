using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using Persian.Plus.Extensions;

namespace Persian.Plus.FluentValidation.Validators
{
    public class IranianShetabCardNumber<T> : PropertyValidator<T, string>
    {
        public override string Name => "IranianShetabCardNumber";
        public string[] AllowedCardBins { get; set; }

        public override bool IsValid(ValidationContext<T> context, string value) {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            var isValidIban = value.IsValidIranianShetabCardNumber();
            if (AllowedCardBins == null || AllowedCardBins.Length == 0)
                return isValidIban;

            return AllowedCardBins.Any(value.IsIranianShetabCardNumberMatchesCardBin);
        }
    }
}