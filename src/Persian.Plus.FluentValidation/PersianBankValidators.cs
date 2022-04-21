using System.Linq;
using FluentValidation;
using Persian.Plus.Extensions;

namespace Persian.Plus.FluentValidation
{
    public static class PersianBankValidators
    {
        public static IRuleBuilderOptions<T, string> IranianIbanNumber<T>(this IRuleBuilder<T, string> ruleBuilder,
            params string[][] bankCodes)
        {
            return ruleBuilder.Must(str =>
                {
                    if (string.IsNullOrWhiteSpace(str))
                        return true;
                    var isValidIban = str.IsValidIranianIbanNumber();
                    if (bankCodes == null || bankCodes.Length == 0)
                        return isValidIban;

                    var allBankCodes = bankCodes.SelectMany(x => x);
                    return allBankCodes.Any(x => str.IsIbanMatchesBankCode(x));
                })
                .WithMessage("Iban is not valid");
        }

        public static IRuleBuilderOptions<T, string> IranianShetabCardNumber<T>(this IRuleBuilder<T, string> ruleBuilder, params string[][] cardBins)
        {
            return ruleBuilder.Must(str =>
                {
                    if (string.IsNullOrWhiteSpace(str))
                        return true;
                    var isValidCardNumber = str.IsValidIranianShetabCardNumber();
                    if (cardBins == null || cardBins.Length == 0)
                        return isValidCardNumber;

                    var allCardBins = cardBins.SelectMany(x => x);
                    return allCardBins.Any(x => str.IsIranianShetabCardNumberMatchesCardBin(x));
                })
                .WithMessage("Shetab card number is not valid");
        }
    }
}