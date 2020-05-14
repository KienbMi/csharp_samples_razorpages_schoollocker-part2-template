using SchoolLocker.Core.Entities;
using System;
using System.ComponentModel;

namespace SchoolLocker.Core.DataTransferObjects
{
  public class SchoolLockerOverviewDto
  {
    public Locker Locker { get; set; }

    [DisplayName("Bookings")]
    public int CountBookings { get; set; }

    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
  }
}
