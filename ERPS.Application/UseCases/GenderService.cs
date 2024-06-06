using NetCore.Models;
using NetCore.Repositories.Interfaces;
using NetCore.Services.Interfaces;

namespace ERPS.Application.UseCases
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repo;

        public GenderService(IGenderRepository repo) 
        {
            _repo = repo;
        }

        public async Task<List<Gender>> GetAllAsync(string[] includes)
        {
            return await _repo.GetAllAsync(includes);
        }

        public async Task<Gender> GetByIDAsync(int id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<Gender> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<Gender> UpdateAsync(int id, Gender data)
        {
            return await _repo.UpdateAsync(id, data);
        }

        public async Task<Gender> CreateAsync(Gender data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }

    }
}
