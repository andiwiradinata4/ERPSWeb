using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;

namespace ERPS.Infrastructure.Services.v1
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IMaritalStatusRepository _repo;

        public MaritalStatusService(IMaritalStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MaritalStatus>> GetAllAsync(string[] includes)
        {
            return await _repo.GetAllAsync(includes);
        }

        public async Task<MaritalStatus> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<MaritalStatus> CreateAsync(MaritalStatus data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }

        public async Task<MaritalStatus> UpdateAsync(dynamic id, MaritalStatus data)
        {
            return await _repo.UpdateAsync(id, data);
        }

        public async Task<MaritalStatus> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
