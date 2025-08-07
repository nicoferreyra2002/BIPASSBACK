using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IConcertRepository
    {
        Task<Concert> AddAsync(Concert concert);
        Task<IEnumerable<Concert>> GetAllAsync();
    }
}