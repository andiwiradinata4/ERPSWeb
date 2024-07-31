using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Infrastructure.Data.v1;

namespace ERPS.Infrastructure.Services.v1
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repo;
        private readonly AppDBContext _context;

        public GenderService(IGenderRepository repo, AppDBContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<List<Gender>> GetAllAsync(QueryObject query)
        {
            return await _repo.GetAllAsync(query);
        }

        public async Task<Gender> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<Gender> CreateAsync(Gender data, string userId)
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

        public async Task<Gender> UpdateAsync(dynamic id, Gender data, string userId)
        {
            data.LogBy = userId;
            return await _repo.UpdateAsync(id, data, true);
        }

        public async Task<Gender> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id, true);
        }

    }
}
