using System;
using System.ComponentModel.DataAnnotations;
using Persian.Plus.Core.Extensions;

namespace Persian.Plus.Core.DataAnnotations
{
    /// <summary>
    /// Determines whether the specified value of the object is a valid IranianNationalCode.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class NationalCodeAttribute : ValidationAttribute
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
            return value.ToString().IsNationalCode();
        }
    }
}