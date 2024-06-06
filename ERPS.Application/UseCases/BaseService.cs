using ERPS.Infrastructure.Repositories;
using ERPS.Application.Interfaces;

namespace ERPS.Application.UseCases
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repo;
        public BaseService(BaseRepository<T> repo)
        {
            _repo = repo;
        }

        public async Task<List<T>> GetAllAsync(string[] includes)
        {
            var list = await _repo.GetAllAsync(includes);
            return list;
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<T> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}