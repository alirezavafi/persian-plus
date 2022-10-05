using System;
using System.Linq;
using FluentValidation;
using Persian.Plus.FluentValidation.Extensions;

namespace Persian.Plus.FluentValidation.Tests.Bank.Model
{
    public class MelliOrPassargadAccountValidator : AbstractValidator<BankAccountInfo>
    {
        public MelliOrPassargadAccountValidator()
        {
            RuleFor(x => x.IbanNumber)
                .IranianIbanNumber((new []{IranBankConstants.BankCodes.Melli, IranBankConstants.BankCodes.Passargad}).SelectMany(x => x).ToArray());
            RuleFor(x => x.ShetabCardNumber)
                .IranianShetabCardNumber((new []{IranBankConstants.BankCardBins.Melli, IranBankConstants.BankCardBins.Passargad}).SelectMany(x => x).ToArray());
        }
    }
}