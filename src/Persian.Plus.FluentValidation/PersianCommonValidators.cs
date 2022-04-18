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
        
        public static IRuleBuilderOptions<T, string> IranianPostalCode<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.Must(str =>
                {
                    if (string.IsNullOrWhiteSpace(str))
                        return true;
                    
                    return str.IsValidIranianPostalCode();
                })
                .WithMessage("Postal code is not valid");
        }
        
        public static IRuleBuilderOptions<T, string> IranianMobileNumber<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.Must(str =>
                {
                    if (string.IsNullOrWhiteSpace(str))
                        return true;
                    
                    return str.IsValidIranianMobileNumber();
                })
                .WithMessage("Mobile Number is not valid");
        }
    }
}