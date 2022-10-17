using JDNowTop.Data.Models;

namespace JDNowTop.Logic.Services.Abstractions
{
    public interface ISongService : IService<Song>
    {
        public Task<bool> DeleteByMapNameAsync(string mapName);
        public Task<Song?> GetByMapNameAsync(string mapName);
        public Task<Song?> UpdateAsync(Song song);
    }
}
