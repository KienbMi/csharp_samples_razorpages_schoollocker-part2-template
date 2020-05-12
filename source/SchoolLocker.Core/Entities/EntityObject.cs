using SmartSchool.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Core.Entities
{
    public class EntityObject : IEntityObject
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Version
        {
            get;
            set;
        }
    }
}
