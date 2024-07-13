using ERPS.Core.Entities;
namespace ERPS.Application.Interfaces.v1
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAllAsync(QueryObject query);
        Task<T> GetByIDAsync(dynamic id);
        Task<T> DeleteAsync(dynamic id);
        Task<T> CreateAsync(T entity, string userId);
        Task<T> UpdateAsync(dynamic id, T entity, string userId);
    }
}