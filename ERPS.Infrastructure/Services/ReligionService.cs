using ERPS.Core.Models;
using ERPS.Core.Interfaces;
using ERPS.Application.Interfaces;

namespace ERPS.Application.UseCases
{
    public class ReligionService : IReligionService
    {
        private readonly IReligionRepository _repo;

        public ReligionService(IReligionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Religion>> GetAllAsync(string[] includes)
        {
            return await _repo.GetAllAsync(includes);
        }

        public async Task<Religion> GetByIDAsync(int id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<Religion> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<Religion> UpdateAsync(int id, Religion data)
        {
            return await _repo.UpdateAsync(id, data);
        }

        public async Task<Religion> CreateAsync(Religion data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }
    }
}
