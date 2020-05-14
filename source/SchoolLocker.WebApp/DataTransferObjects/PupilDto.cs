using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Web.DataTransferObjects
{
    public class PupilDto
    {
        public int Id { get; set; }
        public byte[] Version { get; set; }
        [MinLength(2, ErrorMessage = "The first name must be at least two characters long")]
        public string FirstName { get; set; }
        [MinLength(2, ErrorMessage = "The last name must be at least two characters long")]
        public string LastName { get; set; }
        public string Name => $"{LastName} {FirstName}";
    }
}
