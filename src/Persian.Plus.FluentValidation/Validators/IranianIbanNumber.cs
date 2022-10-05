using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using Persian.Plus.Extensions;

namespace Persian.Plus.FluentValidation.Validators
{
    public class IranianIbanNumber<T> : PropertyValidator<T, string>
    {
        public override string Name => "IranianIbanNumber";
        public string[] AllowedBankCodes { get; set; }

        public override bool IsValid(ValidationContext<T> context, string value) {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            var isValidIban = value.IsValidIranianIbanNumber();
            if (AllowedBankCodes == null || AllowedBankCodes.Length == 0)
                return isValidIban;

            return AllowedBankCodes.Any(value.IsIbanMatchesBankCode);
        }
    }
}