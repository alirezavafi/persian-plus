using System;
using System.ComponentModel.DataAnnotations;
using Persian.Plus.Extensions.Normalizer;

namespace Persian.Plus.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class PersianLettersAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (string.IsNullOrWhiteSpace(value as string))
            {
                return true; // returning false, makes this field required.
            }
            return value.ToString().ContainsOnlyPersianLetters();
        }
    }
}