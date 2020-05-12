using SchoolLocker.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Persistence.Validations
{
    public class OverlappingBookingValidation : ValidationAttribute
    {
        private readonly IUnitOfWork _unitOfWork;

        //TODO: Validierung implementieren
    }
}
