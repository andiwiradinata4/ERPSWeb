using ERPS.Core.Entities.Base;
using System.Numerics;
namespace ERPS.Infrastructure.Interfaces.Services
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAllAsync(QueryObject query);
        Task<BigInteger> GetTotalPageAsync(QueryObject query);
        Task<T> GetByIDAsync(dynamic id);
        Task<T> DeleteAsync(dynamic id);
        Task<T> CreateAsync(T entity, string userId);
        Task<T> UpdateAsync(dynamic id, T entity, string userId);
    }
}