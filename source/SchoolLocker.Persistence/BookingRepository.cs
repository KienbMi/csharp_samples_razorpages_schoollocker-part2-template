using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolLocker.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddRangeAsync(Booking[] bookings)
          => await _dbContext.Bookings.AddRangeAsync(bookings);

        public async Task AddAsync(Booking booking)
          => await _dbContext.Bookings.AddAsync(booking);

        public async Task<Booking> GetOverlappingBookingAsync(Booking booking)
        {
            DateTime end = booking.To ?? DateTime.MaxValue;

            return await _dbContext.Bookings
                      .FirstOrDefaultAsync(b =>
                            b.Id != booking.Id && booking.LockerId == b.LockerId && (
                                (b.From >= booking.From && b.From <= end) //True if b.From is in range of booking
                                || (b.To >= booking.From && b.To <= end) //True if b.To is in range of booking
                                || (b.From < booking.From && b.To > end) //True if booking is completely inside b
                            ));
        }

        public async Task<Booking[]> GetOverlappingBookingsAsync(int lockerNumber, DateTime @from, DateTime? to)
        {
            if (to == null)
            {
                to = DateTime.MaxValue;
            }
            var bookings = await _dbContext
                .Bookings
                .Where(b => b.LockerId == lockerNumber &&
                           (b.From >= @from && b.From <= to ||
                             b.To >= @from && (b.To != null && b.To <= to))
                ).ToArrayAsync();
            return bookings;
        }
    }
}