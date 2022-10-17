using JDNowTop.Data.Database;
using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JDNowTop.Data.Repositories.Realizations
{
    public class UserRepository : IRepository<UserData, string>
    {
        private readonly DatabaseContext _database;
        public UserRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<bool> CheckExists(string id)
        {
            return await _database.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<UserData> CreateAsync(UserData entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            await _database.Users.AddAsync(entity);
            await _database.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _database.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return;

            _database.Users.Remove(user);
            await _database.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserData>> GetAllAsync()
        {
            return await _database.Users.ToListAsync();
        }

        public async Task<IEnumerable<UserData>> GetAnyAsync(Expression<Func<UserData, bool>> predicate)
        {
            return await _database.Users.Where(predicate).ToListAsync();
        }

        public async Task<UserData?> GetAsync(string id)
        {
            return await _database.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserData?> GetIfAsync(Expression<Func<UserData, bool>> predicate)
        {
            return await _database.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<UserData> UpdateAsync(UserData entity)
        {
            var trackedEntity = await _database.Users.FirstAsync(u => u.Id == entity.Id);

            trackedEntity.UserName = entity.UserName;
            trackedEntity.PasswordHash = entity.PasswordHash;
            trackedEntity.PasswordSalt = entity.PasswordSalt;
            trackedEntity.Role = entity.Role;

            _database.Users.Update(trackedEntity);
            await _database.SaveChangesAsync();
            return trackedEntity;
        }
    }
}
