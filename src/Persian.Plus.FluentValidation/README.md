# Persian.Plus.FluentValidation

FluentValidation extensions for Persian/Iranian domain validation rules.

## Install

```bash
dotnet add package Persian.Plus.FluentValidation
```

## Available validators

- `PersianPhrase()`
- `PersianOrEnglishPhrase()`
- `PersianLetters()`
- `PersianDateTime()`
- `IranianNationalCode()`
- `IranianNationalLegalCode()`
- `IranianPostalCode()`
- `IranianMobileNumber()`
- `IranianIbanNumber(params string[] bankCodes)`
- `IranianShetabCardNumber(params string[] cardBins)`

## Usage sample

```csharp
using FluentValidation;
using Persian.Plus;
using Persian.Plus.FluentValidation.Extensions;

public class BankAccountInfo
{
    public string IbanNumber { get; set; }
    public string ShetabCardNumber { get; set; }
}

public class BankAccountInfoValidator : AbstractValidator<BankAccountInfo>
{
    public BankAccountInfoValidator()
    {
        RuleFor(x => x.IbanNumber)
            .IranianIbanNumber(IranBankConstants.BankCodes.Melli);

        RuleFor(x => x.ShetabCardNumber)
            .IranianShetabCardNumber(IranBankConstants.BankCardBins.Melli);
    }
}
```
