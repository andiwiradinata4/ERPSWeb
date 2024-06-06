using NetCore.Models;
using NetCore.Repositories.Interfaces;
using NetCore.Services.Interfaces;

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

        public async Task<Nationality> GetByIDAsync(int id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<Nationality> DeleteAsync(int id)
        {   
            return await _repo.DeleteAsync(id);
        }

        public async Task<Nationality> UpdateAsync(int id, Nationality data)
        {
            return await _repo.UpdateAsync(id, data);
        }

        public async Task<Nationality> CreateAsync(Nationality data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }
    }
}
