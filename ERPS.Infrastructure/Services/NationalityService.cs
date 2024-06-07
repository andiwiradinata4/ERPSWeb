using ERPS.Core.Models;
using ERPS.Core.Interfaces;
using ERPS.Application.Interfaces;

namespace ERPS.Application.UseCases
{
    public class NationalityService : INationalityService
    {
        private readonly INationalityRepository _repo;

        public NationalityService(INationalityRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Nationality>> GetAllAsync(string[] includes)
        {
            return await _repo.GetAllAsync(includes);
        }

        public async Task<Nationality> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<Nationality> CreateAsync(Nationality data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }

        public async Task<Nationality> UpdateAsync(dynamic id, Nationality data)
        {
            return await _repo.UpdateAsync(id, data);
        }

        public async Task<Nationality> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
