using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Infrastructure.Repositories.v1;
using System.Numerics;
using ERPS.Core.Entities.Base;
using ERPS.Infrastructure.Interfaces.Services;

namespace ERPS.Infrastructure.Services.v1
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repo;
        public BaseService(IBaseRepository<T> repo)
        {
            _repo = repo;
        }

        public virtual async Task<List<T>> GetAllAsync(QueryObject query)
        {
            var list = await _repo.GetAllAsync(query);
            return list;
        }

        public virtual async Task<T> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public virtual async Task<T> CreateAsync(T entity, string userId)
        {
            return await _repo.CreateAsync(entity, false);
        }

        public virtual async Task<T> UpdateAsync(dynamic id, T entity, string userId)
        {
            return await _repo.UpdateAsync(id, entity);
        }

        public virtual async Task<T> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id, true);
        }

        public virtual async Task<BigInteger> GetTotalPageAsync(QueryObject query)
        {
            return await _repo.GetTotalPageAsync(query);
        }
    }
}