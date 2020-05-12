using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolLocker.Persistence
{
  internal class PupilRepository : IPupilRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public PupilRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<Pupil[]> GetAllAsync()
     => await _dbContext
            .Pupils
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ToArrayAsync();


    public async Task AddAsync(Pupil pupil)
      => await _dbContext.Pupils
            .AddAsync(pupil);

    public async Task<Pupil> GetByIdAsync(int id)
     => await _dbContext
          .Pupils
          .FindAsync(id);

    public void Delete(Pupil pupil)
    {
      _dbContext
          .Pupils
          .Remove(pupil);
    }
  }
}