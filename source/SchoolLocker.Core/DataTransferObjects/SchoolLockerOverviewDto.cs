using SchoolLocker.Core.Entities;
using System;

namespace SchoolLocker.Core.DataTransferObjects
{
    public class SchoolLockerOverviewDto
    {
        public Locker Locker { get; set; }
        public int CountBookings { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
    }
}
