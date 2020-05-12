using SmartSchool.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Core.Entities
{
    public class Pupil : EntityObject
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Name => $"{LastName} {FirstName}";


    }
}
