using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using JDNowTop.Logic.Services.Abstractions;
using System.Linq;

namespace JDNowTop.Logic.Services.Realizations
{
    public class SongService: ISongService
    {
        private readonly IRepository<Song, string> _repository;
        private readonly IRepository<Week, int> _weekRepository;
        private readonly IRepository<Position, int> _positionRepository;

        public SongService(IRepository<Song, string> repository, IRepository<Week, int> weekRepository, IRepository<Position, int> positionRepository)
        {
            _repository = repository;
            _weekRepository = weekRepository;
            _positionRepository = positionRepository;
        }

        public async Task<Song?> CreateAsync(Song _song)
        {
            if (await _repository.CheckExists(_song.MapName)) return null;

            try
            {
                return await _repository.CreateAsync(_song);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Song?> UpdateAsync(Song _song)
        {
            if (!await _repository.CheckExists(_song.MapName)) return null;

            try
            {
                return await _repository.UpdateAsync(_song);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteByMapNameAsync(string _mapName)
        {
            if (!await _repository.CheckExists(_mapName)) return false;

            try
            {
                await _repository.DeleteAsync(_mapName);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<Song?> GetByMapNameAsync(string _mapName)
        {
            return await _repository.GetAsync(_mapName);
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
