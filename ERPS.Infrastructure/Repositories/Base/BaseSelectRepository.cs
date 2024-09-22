using Microsoft.EntityFrameworkCore;
using NetCore.Models;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ERPS.Infrastructure.Interfaces.Repositories.Base;
using ERPS.Core.Entities.Base;
using ERPS.Core.Entities.Base.Interface;
using System.Numerics;

namespace NetCore.Repositories
{
    public class BaseSelectRepository<TDbContext, T> : IBaseSelectRepository<TDbContext, T> where TDbContext : DbContext where T : BaseEntity, IEntityStandard
    {
        protected TDbContext context;
        protected DbSet<T> dbSet;

        public BaseSelectRepository(TDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual bool ExistsInDb(Func<T, bool> predicate)
        {
            return dbSet.Where((T c) => !c.Disabled).Any(predicate);
        }

        public virtual ICollection<T> GetAll()
        {
            return (from s in dbSet.AsNoTracking()
                    where !s.Disabled
                    select s into m
                    orderby m.CreatedDate descending
                    select m).ToList();
        }

        public virtual object GetAll(QueryObject query)
        {
            var queries = this.SetQuery(query, (e => e.Disabled == false));

            BigInteger count = queries.Count();
            BigInteger totalPage = 1;
            if (count == 0) totalPage = 0;
            if (count > 0 && query.PageSize > 0) totalPage = (int)Math.Ceiling((double)count / query.PageSize);

            // Apply Pagination
            if (query.Page > 0) queries = queries.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);

            // Apply Includes
            var allIncludes = query.Includes.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();
            allIncludes.ForEach(e =>
            {
                queries = queries.Include(e);
            });

            return new { Count = count, TotalPage = totalPage, DataSet = queries.ToList() };
            //return dbSet.Where(e => e.Disabled == false).SetQuery(query).ToList();
            //return context.Set<T>().Where(e => e.Disabled == false).SetQuery(query).ToList();
            //return SetQuery(query).Where(s => s.Disabled == false).OrderByDescending(e => e.Id).ToList();
            //return (from s in dbSet.AsNoTracking()
            //        where !s.Disabled
            //        select s into m
            //        orderby m.Id descending
            //        select m).ToList();
        }

        public virtual async Task<List<T>> GetAllAsync(QueryObject query)
        {
            return await (from s in dbSet.AsNoTracking()
                          where !s.Disabled
                          select s into m
                          orderby m.CreatedDate descending
                          select m).ToListAsync();
        }

        public virtual IQueryable<T> GetByConditionAsQueryable(Expression<Func<T, bool>> predicate)
        {
            return from c in dbSet.Where(predicate)
                   where !c.Disabled
                   select c;
        }

        public virtual IQueryable<T> GetByConditionAsQueryableWithDisabledRecord(Expression<Func<T, bool>> predicate)
        {
            return dbSet.IgnoreQueryFilters().Where(predicate);
        }

        public virtual T? GetById(string Id)
        {
            return dbSet.Find(Id);
        }

        public virtual async Task<T?> GetByIDAsync(string Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public virtual int CountByCondition(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).Count();
        }

        public virtual async Task<int> CountByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).CountAsync();
        }

        public object GetColumnSet()
        {
            string? fullName = typeof(T).FullName;

            var entityType = context.Model.FindEntityType(fullName ?? "");

            var columns = entityType?.GetProperties().Where(e => e.ClrType.Name.ToLower() == "string");
            ICollection<ColumnSet> allColumns = new List<ColumnSet>();

            if (columns == null) return allColumns;

            allColumns = columns.Select((e) => new ColumnSet() { Name = e.Name, Type = e.GetColumnType(), Size = e.GetMaxLength() ?? 0 }).ToList();

            //foreach (var c in columns)
            //{
            //    var ftm = c.FindTypeMapping();
            //    var length = c.GetMaxLength();
            //    Console.WriteLine(c.GetMaxLength());
            //    allColumns.Add(new ColumnSet() { Name = c.Name, Type = c.GetColumnType(), Size = c.GetMaxLength()});
            //    Console.WriteLine(c.Name + " - " + length.ToString());
            //}
            return allColumns;
        }

        private IQueryable<T> SetQuery(QueryObject query, Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> queries = context.Set<T>().Where(predicate);            

            // Apply Filtering
            foreach (var filterParam in query.FilterParams)
            {
                if (filterParam != null)
                {
                    if (filterParam.Option == FilterParams.Options.orEqual)
                    {
                        var values = ((string)filterParam.Value).ToString().Split(",").Select(c => c.Trim()).ToList() ?? new List<string>();
                        var parameter = Expression.Parameter(typeof(T), "e");
                        var property = Expression.Property(parameter, filterParam.Key);
                        Expression? orExpression = null;

                        foreach (var value in values)
                        {
                            ConstantExpression constant;
                            if (DateTime.TryParse(value.ToString(), out var dtValue))
                            {
                                constant = Expression.Constant(dtValue);
                            }
                            else if (int.TryParse(value, out var iValue))
                            {
                                constant = Expression.Constant(iValue);
                            }
                            else if (double.TryParse(value, out var doValue))
                            {
                                constant = Expression.Constant(doValue);
                            }
                            else
                            {
                                constant = Expression.Constant(value);
                            }
                            var equality = Expression.Equal(property, constant);
                            orExpression = orExpression == null ? equality : Expression.OrElse(orExpression, equality);
                        }

                        if (orExpression != null)
                        {
                            var lamda = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
                            queries = queries.Where(lamda);
                        }
                    }
                    else
                    {
                        if (DateTime.TryParse(filterParam.Value.ToString(), out var dtmValue))
                        {
                            if (filterParam.Option == FilterParams.Options.eq) queries = queries.Where(e => EF.Property<DateTime>(e, filterParam.Key).Equals(dtmValue));
                            if (filterParam.Option == FilterParams.Options.min) queries = queries = queries.Where(e => EF.Property<DateTime>(e, filterParam.Key) > dtmValue);
                            if (filterParam.Option == FilterParams.Options.minEqual) queries = queries = queries.Where(e => EF.Property<DateTime>(e, filterParam.Key) >= dtmValue);
                            if (filterParam.Option == FilterParams.Options.max) queries = queries = queries.Where(e => EF.Property<DateTime>(e, filterParam.Key) < dtmValue);
                            if (filterParam.Option == FilterParams.Options.maxEqual) queries = queries = queries.Where(e => EF.Property<DateTime>(e, filterParam.Key) <= dtmValue);
                        }
                        else if (double.TryParse(filterParam.Value.ToString(), out var doubleValue))
                        {
                            if (filterParam.Option == FilterParams.Options.eq) queries = queries.Where(e => EF.Property<double>(e, filterParam.Key).Equals(doubleValue));
                            if (filterParam.Option == FilterParams.Options.min) queries = queries.Where(e => EF.Property<double>(e, filterParam.Key) > doubleValue);
                            if (filterParam.Option == FilterParams.Options.minEqual) queries = queries.Where(e => EF.Property<double>(e, filterParam.Key) >= doubleValue);
                            if (filterParam.Option == FilterParams.Options.max) queries = queries.Where(e => EF.Property<double>(e, filterParam.Key) < doubleValue);
                            if (filterParam.Option == FilterParams.Options.maxEqual) queries = queries.Where(e => EF.Property<double>(e, filterParam.Key) <= doubleValue);
                        }
                        else if (int.TryParse(filterParam.Value.ToString(), out var intValue))
                        {
                            if (filterParam.Option == FilterParams.Options.eq) queries = queries.Where(e => EF.Property<int>(e, filterParam.Key).Equals(intValue));
                            if (filterParam.Option == FilterParams.Options.min) queries = queries.Where(e => EF.Property<int>(e, filterParam.Key) > intValue);
                            if (filterParam.Option == FilterParams.Options.minEqual) queries = queries.Where(e => EF.Property<int>(e, filterParam.Key) >= intValue);
                            if (filterParam.Option == FilterParams.Options.max) queries = queries.Where(e => EF.Property<int>(e, filterParam.Key) < intValue);
                            if (filterParam.Option == FilterParams.Options.maxEqual) queries = queries.Where(e => EF.Property<int>(e, filterParam.Key) <= intValue);
                        }
                        else if (bool.TryParse(filterParam.Value.ToString(), out var bolValue))
                        {
                            if (filterParam.Option == FilterParams.Options.eq) queries = queries.Where(e => EF.Property<bool>(e, filterParam.Key).Equals(bolValue));
                        }
                        else
                        {
                            if (filterParam.Option == FilterParams.Options.eq) queries = queries.Where(e => EF.Property<string>(e, filterParam.Key).Equals((string)filterParam.Value));
                            if (filterParam.Option == FilterParams.Options.contains) queries = queries.Where(e => EF.Property<string>(e, filterParam.Key).Contains((string)filterParam.Value));
                            if (filterParam.Option == FilterParams.Options.startWith) queries = queries.Where(e => EF.Property<string>(e, filterParam.Key).StartsWith((string)filterParam.Value));
                            if (filterParam.Option == FilterParams.Options.endtWith) queries = queries.Where(e => EF.Property<string>(e, filterParam.Key).EndsWith((string)filterParam.Value));
                        }
                    }
                }
            }

            // Apply Sorting
            string allSortBy = string.Join(",", query.SortParams.Select(sort =>
            {
                string sortDirection = sort?.Option == SortParams.Options.ASC ? "ascending" : "descending";
                return $"{sort?.Column} {sortDirection}";
            }));
            if (allSortBy != "")
            {
                queries = queries.OrderBy(allSortBy);
            }

            return queries;
        }

    }
}
