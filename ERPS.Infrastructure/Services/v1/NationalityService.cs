using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Infrastructure.Data.v1;

namespace ERPS.Infrastructure.Services.v1
{
    public class NationalityService : BaseService<Nationality>, INationalityService
    {
        private readonly INationalityRepository _repo;
        private readonly AppDBContext _context;

        public NationalityService(INationalityRepository repo, AppDBContext context) : base(repo)
        {
            _repo = repo;
            _context = context;
        }

        //public async Task<List<Nationality>> GetAllAsync(QueryObject query)
        //{
        //    return await _repo.GetAllAsync(query);
        //}

        //public async Task<Nationality> GetByIDAsync(dynamic id)
        //{
        //    return await _repo.GetByIDAsync(id);
        //}

        //public async Task<Nationality> CreateAsync(Nationality data, string userId)
        //{
        //    using (var transaction = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            data.ID = await _repo.GetMaxID();
        //            var result = await _repo.CreateAsync(data);
        //            await transaction.CommitAsync();
        //            return result;
        //        }
        //        catch (Exception)
        //        {
        //            await transaction.RollbackAsync();
        //            throw;
        //        }
        //    }
        //}

        //public async Task<Nationality> UpdateAsync(dynamic id, Nationality data, string userId)
        //{
        //    return await _repo.UpdateAsync(id, data, true);
        //}

        //public async Task<Nationality> DeleteAsync(dynamic id)
        //{
        //    return await _repo.DeleteAsync(id, true);
        //}

        //public async Task<BigInteger> GetTotalPageAsync(QueryObject query)
        //{
        //    return await _repo.GetTotalPageAsync(query);
        //}
    }
}
