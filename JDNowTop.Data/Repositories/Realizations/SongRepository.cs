using JDNowTop.Data.Database;
using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JDNowTop.Data.Repositories.Realizations
{
    public class SongRepository : IRepository<Song, string>
    {
        private readonly DatabaseContext _dbContext;

        public SongRepository(DatabaseContext context) { _dbContext = context; }

        public async Task<Song> CreateAsync(Song _song)
        {
            await _dbContext.Songs.AddAsync(_song);
            await _dbContext.SaveChangesAsync();
            return _song;
        }

        public async Task<Song> UpdateAsync(Song _song)
        {
            var entityToUpdate = await _dbContext.Songs.FirstAsync(s => s.MapName == _song.MapName);

            entityToUpdate.Mode = _song.Mode;
            entityToUpdate.GameVersion = _song.GameVersion;

            _dbContext.Songs.Update(entityToUpdate);
            await _dbContext.SaveChangesAsync();

            return entityToUpdate;
        }

        public async Task DeleteAsync(string _mapName)
        {
            var entityToRemove = await _dbContext.Songs.FirstAsync(s => s.MapName == _mapName);
            _dbContext.Songs.Remove(entityToRemove);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Song?> GetAsync(string _mapName)
        {
            return await _dbContext.Songs.Include(s => s.Positions).FirstOrDefaultAsync(s => s.MapName == _mapName);
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            var songs = _dbContext.Songs.Include(s => s.Positions);
            return await songs.ToListAsync();
        }

        public async Task<bool> CheckExists(string _mapName)
        {
            return await _dbContext.Songs.AnyAsync(s => s.MapName == _mapName);
        }

        public async Task<Song?> GetIfAsync(Expression<Func<Song, bool>> _predicate)
        {
            return await _dbContext.Songs.FirstOrDefaultAsync(_predicate);
        }

        public async Task<IEnumerable<Song>> GetAnyAsync(Expression<Func<Song, bool>> _predicate)
        {
            return await _dbContext.Songs.Where(_predicate).ToListAsync();
        }
    }
}
