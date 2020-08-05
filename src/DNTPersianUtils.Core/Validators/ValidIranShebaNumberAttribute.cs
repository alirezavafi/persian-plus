using System;
using System.ComponentModel.DataAnnotations;

namespace DNTPersianUtils.Core
{
    /// <summary>
    /// Determines whether the specified value of the object is a valid IranShebaNumber.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class ValidIranShebaNumberAttribute : ValidationAttribute
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
            return value.ToString().IsValidIranShebaNumber();
        }
    }
}