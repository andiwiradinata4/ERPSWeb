using ERPS.Core.Entities;
using ERPS.Core.Entities.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
namespace ERPS.Core.DbContext.v1
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Status> Status { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Status>().Property(e => e.RowVersion).IsRowVersion();

            //modelBuilder.Entity<Status>().ToTable("QMS_mstStatus");
            //modelBuilder.Entity<BloodType>().ToTable("QMS_mstBloodType");
            //modelBuilder.Entity<Gender>().ToTable("QMS_mstGender");
            //modelBuilder.Entity<MaritalStatus>().ToTable("QMS_mstMaritalStatus");
            //modelBuilder.Entity<Nationality>().ToTable("QMS_mstNationality");
            //modelBuilder.Entity<Religion>().ToTable("QMS_mstReligion");
            //modelBuilder.Entity<Driver>().ToTable("QMS_mstDriver");

            // Register Role for Using JWT
            //List<IdentityRole> roles = new()
            //{
            //    new IdentityRole
            //    {
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new IdentityRole
            //    {
            //        Name = "User",
            //        NormalizedName = "USER"
            //    }
            //};
            //modelBuilder.Entity<IdentityRole>().HasData(roles);

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<T> SetQuery<T>(QueryObject query) where T : class
        {
            IQueryable<T> queries = Set<T>();

            // Apply Filtering
            foreach (var filterParam in query.FilterParams)
            {
                if (filterParam != null)
                {
                    //Console.WriteLine($"{filterParam.Value}: {filterParam.Value.GetType()}");
                    //var propertyType = typeof(T).GetProperties(filterParam.Value).PropertyType;

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
            if (allSortBy != "") queries = queries.OrderBy(allSortBy);

            // Apply Pagination
            if (query.Page > 0) queries = queries.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);

            // Apply Includes
            var allIncludes = query.Includes.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();
            allIncludes.ForEach(e =>
            {
                queries = queries.Include(e);
            });

            return queries;
        }

        public IQueryable<T> SetQueryTotalPage<T>(QueryObject query) where T : class
        {
            IQueryable<T> queries = Set<T>();

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
            return queries;
        }

        public IQueryable<T> SetWithIncludes<T>(params string[] includes) where T : class
        {
            IQueryable<T> queries = Set<T>();
            if (includes != null)
            {
                queries = queries.IncludeProperties(includes);
            }
            return queries;
        }

    }
}
