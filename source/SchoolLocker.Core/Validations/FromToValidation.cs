using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Core.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class FromToValidation : ValidationAttribute
    {
        //TODO: Validierung(en) implementieren
    }
}
