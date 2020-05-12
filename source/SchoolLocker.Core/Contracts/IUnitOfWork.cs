using System;
using System.Threading.Tasks;

namespace SchoolLocker.Core.Contracts
{
  public interface IUnitOfWork : IDisposable
  {
    IPupilRepository PupilRepository { get; }
    IBookingRepository BookingRepository { get; }
    ILockerRepository LockerRepository { get; }

    Task<int> SaveChangesAsync();

    Task DeleteDatabaseAsync();
    Task MigrateDatabaseAsync();
  }
}
