using SchoolLocker.Core.Entities;
using System.Threading.Tasks;

namespace SchoolLocker.Core.Contracts
{
  public interface IPupilRepository
  {
    Task AddAsync(Pupil pupil);
    Task<Pupil[]> GetAllAsync();
    Task<Pupil> GetByIdAsync(int id);
    void Delete(Pupil pupil);
  }
}
