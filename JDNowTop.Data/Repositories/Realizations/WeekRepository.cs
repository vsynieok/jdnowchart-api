using JDNowTop.Data.Database;
using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace JDNowTop.Data.Repositories.Realizations
{
    public class WeekRepository : IRepository<Week, int>
    {
        private readonly DatabaseContext _dbContext;

        public WeekRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckExists(int _id)
        {
            return await _dbContext.Weeks.AnyAsync(w => w.Id == _id);
        }

        public async Task<Week> CreateAsync(Week _week)
        {
            var trackedEntity = await _dbContext.Weeks.AddAsync(_week);
            await _dbContext.SaveChangesAsync();
            return trackedEntity.Entity;
        }

        public async Task DeleteAsync(int _id)
        {
            var entityToDelete = await _dbContext.Weeks.FirstAsync(w => w.Id == _id);
            _dbContext.Weeks.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Week>> GetAllAsync()
        {
            return await _dbContext.Weeks.Include(w => w.Positions).ToListAsync();
        }

        public async Task<IEnumerable<Week>> GetAnyAsync(Expression<Func<Week, bool>> _predicate)
        {
            return await _dbContext.Weeks.Where(_predicate).ToListAsync();
        }

        public async Task<Week?> GetAsync(int _id)
        {
            return await _dbContext.Weeks.Include(w => w.Positions).FirstOrDefaultAsync(w => w.Id == _id);
        }

        public Task<Week?> GetIfAsync(Expression<Func<Week, bool>> _predicate)
        {
            return _dbContext.Weeks.FirstOrDefaultAsync(_predicate);
        }

        public async Task<Week> UpdateAsync(Week _entity)
        {
            var entityToUpdate = await _dbContext.Weeks.FirstAsync(e => e.Id == _entity.Id);

            entityToUpdate.UpdatedAt = _entity.UpdatedAt;
            entityToUpdate.Positions = _entity.Positions;

            _dbContext.Weeks.Update(entityToUpdate);
            await _dbContext.SaveChangesAsync();

            return entityToUpdate;
        }
    }
}
