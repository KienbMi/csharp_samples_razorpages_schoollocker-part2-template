using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolLocker.AdminConsole
{
    public static  class ConsoleValidations
    {
        public static (bool IsValid, IEnumerable<ValidationResult> ValidationResults) ValidateObject(object objectToValidate)
        {
            var context = new ValidationContext(objectToValidate, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(objectToValidate, context, results, true);

            return (isValid, results);
        }
    }
}
