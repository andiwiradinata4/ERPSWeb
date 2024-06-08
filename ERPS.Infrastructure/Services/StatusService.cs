using ERPS.Core.Entities;
using ERPS.Core.Interfaces;
using ERPS.Application.Interfaces;

namespace ERPS.Application.UseCases
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repo;
        public StatusService(IStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Status>> GetAllAsync(string[] includes)
        {
            return await _repo.GetAllAsync(includes);
        }

        public async Task<Status> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<Status> CreateAsync(Status data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }

        public async Task<Status> UpdateAsync(dynamic id, Status data)
        {
            return await _repo.UpdateAsync(id, data);
        }

        public async Task<Status> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
