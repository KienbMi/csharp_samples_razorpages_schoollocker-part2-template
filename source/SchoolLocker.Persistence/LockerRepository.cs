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
     => await _dbContext.Lockers
          .Select(locker => new SchoolLockerOverviewDto()
          {
            Locker = locker,
            CountBookings = locker.Bookings.Count(),
            From = locker.Bookings.OrderByDescending(b => b.From).Select(b => b.From).FirstOrDefault(),
            To = locker.Bookings.OrderByDescending(b => b.From).Select(b => b.To).FirstOrDefault(),
          })
          .OrderBy(dto => dto.Locker.Number)
          .ThenByDescending(dto => dto.From)
          .ToArrayAsync();
  }
}