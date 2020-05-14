using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SchoolLocker.Core.Contracts
{
  public interface IBookingRepository
  {
    Task AddAsync(Booking booking);
    Task AddRangeAsync(Booking[] bookings);

    Task<Booking> GetOverlappingBookingAsync(Booking booking);
    Task<BookingDto[]> GetOverlappingBookingsAsync(int lockerNumber, DateTime @from, DateTime? to);
  }
}
