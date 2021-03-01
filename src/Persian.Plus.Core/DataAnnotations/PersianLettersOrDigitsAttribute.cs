using System;
using System.ComponentModel.DataAnnotations;

namespace Persian.Plus.Core.DataAnnotations
{
    /// <summary>
    /// Determines whether the specified value of the object is a valid Persian letter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class PersianLettersOrDigitsAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        public override bool IsValid(object value)
        {
            if (string.IsNullOrWhiteSpace(value as string))
            {
                return true; // returning false, makes this field required.
            }
            return value.ToString().ContainsFarsi();
        }
    }
}