using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Infrastructure.Data.v1;

namespace ERPS.Infrastructure.Services.v1
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IMaritalStatusRepository _repo;
        private readonly AppDBContext _context;

        public MaritalStatusService(IMaritalStatusRepository repo, AppDBContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<List<MaritalStatus>> GetAllAsync(QueryObject query)
        {
            return await _repo.GetAllAsync(query);
        }

        public async Task<MaritalStatus> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<MaritalStatus> CreateAsync(MaritalStatus data, string userId)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    data.ID = await _repo.GetMaxID();
                    var result = await _repo.CreateAsync(data);
                    await transaction.CommitAsync();
                    return result;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<MaritalStatus> UpdateAsync(dynamic id, MaritalStatus data, string userId)
        {
            return await _repo.UpdateAsync(id, data, true);
        }

        public async Task<MaritalStatus> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id, true);
        }

    }
}
