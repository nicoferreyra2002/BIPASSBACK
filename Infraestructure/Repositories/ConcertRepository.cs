using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ConcertRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Concert> AddAsync(Concert concert)
        {
            _dbContext.Concerts.Add(concert);
            await _dbContext.SaveChangesAsync();
            return concert;
        }

        public async Task<IEnumerable<Concert>> GetAllAsync()
        {
            return await _dbContext.Concerts.AsNoTracking().ToListAsync();
        }
    }
}