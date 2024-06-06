using Microsoft.EntityFrameworkCore;
namespace ERPS.Infrastructure.Data
{
    public static class usIQueryableExtensions
    {
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> query, params string[] properties) where T : class
        {
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            return query;
        }

    }

}
