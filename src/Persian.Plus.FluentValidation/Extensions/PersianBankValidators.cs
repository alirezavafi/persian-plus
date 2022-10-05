using FluentValidation;
using Persian.Plus.FluentValidation.Validators;

namespace Persian.Plus.FluentValidation.Extensions
{
    public static class PersianBankValidators
    {
        public static IRuleBuilderOptions<T, string> IranianIbanNumber<T>(this IRuleBuilder<T, string> ruleBuilder,
            params string[] bankCodes)
        {
            return ruleBuilder.SetValidator(new IranianIbanNumber<T>() {AllowedBankCodes = bankCodes});
        }

        public static IRuleBuilderOptions<T, string> IranianShetabCardNumber<T>(this IRuleBuilder<T, string> ruleBuilder, params string[] cardBins)
        {
            return ruleBuilder.SetValidator(new IranianShetabCardNumber<T>() {AllowedCardBins = cardBins});
        }
    }
}