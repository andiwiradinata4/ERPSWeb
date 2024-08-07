using ERPS.Core.Entities;
using System.Numerics;
namespace ERPS.Core.Interfaces.v1
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(QueryObject query);
        Task<BigInteger> GetTotalPageAsync(QueryObject query);
        Task<T> GetByIDAsync(dynamic id);
        Task<int> GetMaxID();
        Task<T> CreateAsync(T entity, bool useTransaction = false);
        Task<T> UpdateAsync(dynamic id, T entity, bool useTransaction = false);
        Task<T> DeleteAsync(dynamic id, bool useTransaction = false);
    }
}