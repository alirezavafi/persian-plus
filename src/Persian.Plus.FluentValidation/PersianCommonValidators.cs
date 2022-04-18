using FluentValidation;
using Persian.Plus.Extensions;

namespace Persian.Plus.FluentValidation
{
    public static class PersianCommonValidators {
        public static IRuleBuilderOptions<T, string> IranianNationalCode<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.Must(str =>
                {
                    if (string.IsNullOrWhiteSpace(str))
                        return true;
                    
                    return str.IsValidIranianNationalCode();
                })
                .WithMessage("National code is not valid");
        }
    }
}