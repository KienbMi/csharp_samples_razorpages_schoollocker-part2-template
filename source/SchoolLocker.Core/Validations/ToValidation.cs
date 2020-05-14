using SchoolLocker.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Core.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ToValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(validationContext.ObjectInstance is Booking booking))
            {
                throw new ArgumentException("Das zu validierende Objekt ist nicht vom Type Booking!");
            }

            if (booking.To != null && booking.To <= booking.From)
            {
                return new ValidationResult("To-Date muss hinter From-Date liegen!");
            }
            return ValidationResult.Success;
        }
    }
}
