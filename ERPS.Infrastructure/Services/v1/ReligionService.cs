using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Infrastructure.Data.v1;
using System.Numerics;

namespace ERPS.Infrastructure.Services.v1
{
    public class ReligionService : IReligionService
    {
        private readonly IReligionRepository _repo;
        private readonly AppDBContext _context;

        public ReligionService(IReligionRepository repo, AppDBContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<List<Religion>> GetAllAsync(QueryObject query)
        {
            return await _repo.GetAllAsync(query);
        }

        public async Task<Religion> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<Religion> CreateAsync(Religion data, string userId)
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

        public async Task<Religion> UpdateAsync(dynamic id, Religion data, string userId)
        {
            return await _repo.UpdateAsync(id, data, true);
        }

        public async Task<Religion> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id, true);
        }

        public async Task<BigInteger> GetTotalPageAsync(QueryObject query)
        {
            return await _repo.GetTotalPageAsync(query);
        }
    }
}
