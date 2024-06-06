using ERPS.Core.Models;
using ERPS.Core.Interfaces;
using ERPS.Application.Interfaces;

namespace ERPS.Application.UseCases
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly IBloodTypeRepository _repo;

        public BloodTypeService(IBloodTypeRepository repo) 
        {
            _repo = repo;
        }

        public async Task<List<BloodType>> GetAllAsync(string[] includes)
        {
            return await _repo.GetAllAsync(includes);
        }
        
        public async Task<List<BloodType>> GetAllWithIncludes(string[] includes)
        {
            return await _repo.GetAllWithIncludes(includes);
        }

        public async Task<BloodType> GetByIDAsync(int id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<BloodType> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<BloodType> CreateAsync(BloodType data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }

        public async Task<BloodType> UpdateAsync(int id, BloodType data)
        {
            return await _repo.UpdateAsync(id, data);
        }

    }
}
