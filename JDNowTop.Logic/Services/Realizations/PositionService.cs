using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using JDNowTop.Logic.Services.Abstractions;

namespace JDNowTop.Logic.Services.Realizations
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position, int> _repository;
        private readonly IRepository<Week, int> _weekRepository;

        public PositionService(IRepository<Position, int> repository, IRepository<Week, int> weekRepository)
        {
            _repository = repository;
            _weekRepository = weekRepository;
        }

        public async Task<Position?> CreateAsync(Position _pos)
        {
            try
            {
                return await _repository.CreateAsync(_pos);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Position?> CreateByWeekAsync(int weekId, Position position)
        {
            if (!await _weekRepository.CheckExists(weekId)) return null;

            position.WeekId = weekId;
            return await CreateAsync(position);
        }

        public async Task<bool> DeleteAsync(int _id)
        {
            if (!await _repository.CheckExists(_id)) return false;

            try
            {
                await _repository.DeleteAsync(_id);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Position?> GetAsync(int _id)
        {
            return await _repository.GetAsync(_id);
        }

        public async Task<Position?> UpdateAsync(Position _pos)
        {
            if (!await _repository.CheckExists(_pos.Id)) return null;

            try
            {
                return await _repository.UpdateAsync(_pos);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Position?> UpdateByWeekAsync(int _weekId, Position _position)
        {
            if (!await _weekRepository.CheckExists(_weekId)) return null;
            if (!await _repository.CheckExists(_position.Id)) return null;

            _position.WeekId = _weekId;

            return await UpdateAsync(_position);
        }
    }
}
