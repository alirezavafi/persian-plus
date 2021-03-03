using System;
using System.ComponentModel.DataAnnotations;

namespace Persian.Plus.Core.DateTime.DataAnnotations
{
    /// <summary>
    /// Determines whether the specified value of the object is a valid PersianDateTime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class PersianDateTimeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        public override bool IsValid(object value)
        {
            if (string.IsNullOrWhiteSpace(value as string))
            {
                return true; 
            }

            PersianDate temp;
            bool isDateParsed = PersianDate.TryParse(value.ToString(), out temp);
            return isDateParsed;
        }
    }
}