using AutoMapper;
using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using JDNowTop.Logic.Services.Abstractions;

namespace JDNowTop.Logic.Services.Realizations
{
    public class WeekService : IWeekService
    {
        private readonly IRepository<Week, int> _repository;

        public WeekService(IRepository<Week, int> repository)
        {
            _repository = repository;
        }

        public async Task<Week?> CreateAsync(Week _entity)
        {
            try
            {
                return await _repository.CreateAsync(_entity);
            }
            catch
            {
                return null;
            }
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

        public async Task<IEnumerable<Week>> GetAllAsync()
        {
            var weeks = await _repository.GetAllAsync();
            return weeks;
        }

        public async Task<Week?> GetAsync(int _id)
        {
            return await _repository.GetAsync(_id);
        }

        public async Task<Week?> UpdateAsync(Week _entity, int _id)
        {
            if (!await _repository.CheckExists(_id)) return null;

            try
            {
                var updatedEntity = await _repository.UpdateAsync(_entity);
                return updatedEntity;
            }
            catch
            {
                return null;
            }
        }
    }
}
