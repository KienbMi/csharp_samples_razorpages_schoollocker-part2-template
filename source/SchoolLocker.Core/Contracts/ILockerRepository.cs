using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;
using System.Threading.Tasks;

namespace SchoolLocker.Core.Contracts
{
  public interface ILockerRepository
  {
    Task<SchoolLockerOverviewDto[]> GetLockersOverviewAsync();
    Task<int[]> GetLockerNumbersAsync();
    Task<Locker> GetByLockerNrAsync(int lockerNr);
  }
}
