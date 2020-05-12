using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolLocker.Persistence
{
    internal class LockerRepository : ILockerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LockerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int[]> GetLockerNumbersAsync()
         => await _dbContext
                .Lockers
                .Select(locker => locker.Number)
                .OrderBy(nr => nr)
                .ToArrayAsync();

        public async Task<Locker> GetByLockerNrAsync(int lockerNr)
         => await _dbContext
                .Lockers
                .SingleOrDefaultAsync(l => l.Number == lockerNr);

        public async Task<SchoolLockerOverviewDto[]> GetLockersOverviewAsync()
        {
            var groupedBookings = await _dbContext.Bookings
                .OrderByDescending(b => b.From)
                .GroupBy(b => b.Locker)
                .Select(group => new { Locker = group.Key, Count = group.Count(), group.First().From, group.First().To })
                .ToListAsync();

            return groupedBookings
                .Select(b => new SchoolLockerOverviewDto()
                {
                    Locker = b.Locker,
                    CountBookings = b.Count,
                    From = b.From,
                    To = b.To
                })
                .OrderBy(dto => dto.Locker.Number)
                .ToArray();
        }
    }
}