using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Infrastructure.Repositories.v1;
using System.Numerics;

namespace ERPS.Infrastructure.Services.v1
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repo;
        public BaseService(BaseRepository<T> repo)
        {
            _repo = repo;
        }

        public async Task<List<T>> GetAllAsync(QueryObject query)
        {
            var list = await _repo.GetAllAsync(query);
            return list;
        }

        public async Task<T> GetByIDAsync(dynamic id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<T> CreateAsync(T entity, string userId)
        {
            return await _repo.CreateAsync(entity, true);
        }

        public async Task<T> UpdateAsync(dynamic id, T entity, string userId)
        {
            return await _repo.UpdateAsync(id, entity, true);
        }

        public async Task<T> DeleteAsync(dynamic id)
        {
            return await _repo.DeleteAsync(id, true);
        }

        public async Task<BigInteger> GetTotalPageAsync(QueryObject query)
        {
            return await _repo.GetTotalPageAsync(query);
        }
    }
}