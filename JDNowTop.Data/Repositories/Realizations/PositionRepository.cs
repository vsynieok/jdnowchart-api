using JDNowTop.Data.Database;
using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace JDNowTop.Data.Repositories.Realizations
{
    public class PositionRepository : IRepository<Position, int>
    {
        private readonly DatabaseContext _dbContext;

        public PositionRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckExists(int _id)
        {
            return await _dbContext.Positions.AnyAsync(p => p.Id == _id);
        }

        public async Task<Position> CreateAsync(Position _pos)
        {
            var trackedEntity = await _dbContext.Positions.AddAsync(_pos);
            await _dbContext.SaveChangesAsync();

            return trackedEntity.Entity;
        }

        public async Task DeleteAsync(int _id)
        {
            var entityToRemove = await _dbContext.Positions.FirstAsync(p => p.Id == _id);
            _dbContext.Positions.Remove(entityToRemove);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _dbContext.Positions.ToListAsync();
        }

        public async Task<Position?> GetAsync(int _id)
        {
            return await _dbContext.Positions.FirstOrDefaultAsync(p => p.Id == _id);
        }

        public async Task<Position?> GetIfAsync(Expression<Func<Position, bool>> _predicate)
        {
            return await _dbContext.Positions.FirstOrDefaultAsync(_predicate);
        }

        public async Task<IEnumerable<Position>> GetAnyAsync(Expression<Func<Position, bool>> _predicate)
        {
            return await _dbContext.Positions.Where(_predicate).ToListAsync();
        }

        public async Task<Position> UpdateAsync(Position entity)
        {
            var entityToUpdate = await _dbContext.Positions.FirstAsync(p => p.Id == entity.Id);

            entityToUpdate.Pos = entity.Pos;
            entityToUpdate.WeekId = entity.WeekId;
            entityToUpdate.Song = entity.Song;

            _dbContext.Positions.Update(entityToUpdate);
            await _dbContext.SaveChangesAsync();

            return entityToUpdate;
        }
    }
}
