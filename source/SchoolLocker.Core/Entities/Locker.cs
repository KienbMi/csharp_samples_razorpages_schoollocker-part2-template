using SmartSchool.Core.Entities;
using System.Collections.Generic;

namespace SchoolLocker.Core.Entities
{
    public class Locker : EntityObject
    {
        public int Number { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Locker()
        {
            Bookings = new List<Booking>();
        }

    }
}
