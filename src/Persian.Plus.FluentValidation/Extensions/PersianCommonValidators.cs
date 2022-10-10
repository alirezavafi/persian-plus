using FluentValidation;
using Persian.Plus.FluentValidation.Validators;

namespace Persian.Plus.FluentValidation.Extensions
{
    public static class PersianCommonValidators {
        public static IRuleBuilderOptions<T, string> PersianOrEnglishPhrase<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new PersianOrEnglishPhrase<T>());
        }

        public static IRuleBuilderOptions<T, string> PersianPhrase<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new PersianPhrase<T>());
        }

        public static IRuleBuilderOptions<T, string> PersianDateTime<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new PersianDateTime<T>());
        }

        public static IRuleBuilderOptions<T, string> PersianLetters<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new PersianLetters<T>());
        }
        
        public static IRuleBuilderOptions<T, string> IranianNationalCode<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new IranianNationalCode<T>());
        }
       
        public static IRuleBuilderOptions<T, string> IranianNationalLegalCode<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new IranianNationalLegalCode<T>());
        }

        public static IRuleBuilderOptions<T, string> IranianPostalCode<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new IranianPostalCode<T>());
        }
        
        public static IRuleBuilderOptions<T, string> IranianMobileNumber<T>(this IRuleBuilder<T, string> ruleBuilder) {
            return ruleBuilder.SetValidator(new IranianMobileNumber<T>());
        }
    }
}