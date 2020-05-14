using SchoolLocker.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Core.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FromValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(validationContext.ObjectInstance is Booking booking))
            {
                throw new ArgumentException("Das zu validierende Objekt ist nicht vom Type Booking!");
            }

            if (booking.From < DateTime.Today)
            {
                return new ValidationResult("From-Date darf nicht in der Vergangenheit liegen");
            }

            return ValidationResult.Success;
        }
    }
}
