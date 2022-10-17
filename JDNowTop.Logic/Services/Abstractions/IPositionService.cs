using JDNowTop.Data.Models;

namespace JDNowTop.Logic.Services.Abstractions
{
    public interface IPositionService : IService<Position>
    {
        public Task<bool> DeleteAsync(int id);
        public Task<Position?> GetAsync(int id);
        public Task<Position?> CreateByWeekAsync(int weekId, Position position);
        public Task<Position?> UpdateByWeekAsync(int weekId, Position position);
    }
}
