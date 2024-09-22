using ERPS.Core.Entities.Base.Interface;
using ERPS.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ERPS.Infrastructure.Interfaces.Repositories.Base
{
    public interface IBaseSelectRepository<TDbContext, T> where TDbContext : DbContext where T : IEntityStandard
    {
        ICollection<T> GetAll();
        object GetAll(QueryObject query);
        Task<List<T>> GetAllAsync(QueryObject query);
        T? GetById(string Id);
        Task<T?> GetByIDAsync(string Id);
        //IQueryable GetByODataQuery(ODataQueryOptions<T> queryOptions);
        IQueryable<T> GetByConditionAsQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetByConditionAsQueryableWithDisabledRecord(Expression<Func<T, bool>> predicate);
        bool ExistsInDb(Func<T, bool> predicate);
        int CountByCondition(Expression<Func<T, bool>> predicate);
        Task<int> CountByConditionAsync(Expression<Func<T, bool>> predicate);
        object GetColumnSet();
    }
}
