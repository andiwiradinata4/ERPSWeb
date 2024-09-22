using ERPS.Core.Entities.Base;
using ERPS.Core.Entities.Base.Interface;
using ERPS.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
namespace ERPS.Infrastructure.Interfaces.Services
{
    public interface IBaseService<TDbContext, T> where TDbContext : DbContext where T : IEntityStandard
    {
        ICollection<T> GetAll();
        object GetAll(QueryObject query);
        Task<List<T>> GetAllAsync(QueryObject query);
        T? GetById(string Id);
        Task<T?> GetByIDAsync(string Id);
        bool Exists(string id);
        bool ExistsInDb(Func<T, bool> predicate);
        MessageObject<T> Create(T entity);
        Task<MessageObject<T>> CreateAsync(T entity);
        MessageObject<T> Update(string id, T entity);
        Task<MessageObject<T>> UpdateAsync(string id, T entity);
        MessageObject<T> Disable(string id);
        MessageObject<T> Disable(string id, T entity);
        MessageObject<T> Delete(string id);
        MessageObject<T> Delete(T entity);
        object GetColumnSet();
    }
}