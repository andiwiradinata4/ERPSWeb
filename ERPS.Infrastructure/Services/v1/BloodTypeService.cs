using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Infrastructure.Data.v1;

namespace ERPS.Infrastructure.Services.v1
{
    public class BloodTypeService : BaseService<BloodType>, IBloodTypeService
    {
        private readonly IBloodTypeRepository _repo;
        private readonly AppDBContext _context;

        public BloodTypeService(IBloodTypeRepository repo, AppDBContext context): base(repo) 
        {
            _repo = repo;
            _context = context;
        }


        //public BloodTypeService(IBloodTypeRepository repo, AppDBContext context)
        //{
        //    _repo = repo;
        //    _context = context;
        //}

        //public async Task<List<BloodType>> GetAllAsync(QueryObject query)
        //{
        //    return await _repo.GetAllAsync(query);
        //}

        //public async Task<BloodType> GetByIDAsync(dynamic id)
        //{
        //    return await _repo.GetByIDAsync(id);
        //}

        //public async Task<BloodType> CreateAsync(BloodType data, string userId)
        //{
        //    using (var transaction = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            data.ID = await _repo.GetMaxID();
        //            var result =  await _repo.CreateAsync(data);
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

        //public async Task<BloodType> UpdateAsync(dynamic id, BloodType data, string userId)
        //{
        //    return await _repo.UpdateAsync(id, data, true);
        //}

        //public async Task<BloodType> DeleteAsync(dynamic id)
        //{
        //    return await _repo.DeleteAsync(id, true);
        //}

        //public async Task<BigInteger> GetTotalPageAsync(QueryObject query)
        //{
        //    return await _repo.GetTotalPageAsync(query);
        //}

    }
}
