using Microsoft.EntityFrameworkCore;
using ERPS.Core.Entities.Base;
using ERPS.Core.Entities.Base.Interface;
using ERPS.Infrastructure.Interfaces.Repositories.Base;
using System.Security.Principal;
using NetCore.Repositories;
using AutoMapper;
using ERPS.Infrastructure.Utilities;

namespace ERPS.Infrastructure.Repositories.Base
{
    public class BaseRepository<TDbContext, T> : BaseSelectRepository<TDbContext, T>, IBaseRepository<TDbContext, T>, IBaseSelectRepository<TDbContext, T> where TDbContext : DbContext where T : BaseEntity, IEntityStandard
    {

        protected string logSource;
        protected readonly IPrincipal pctx;

        public BaseRepository(TDbContext context, IPrincipal pctx)
            : base(context)
        {
            this.pctx = pctx;
            logSource = "BaseRepository<" + typeof(T).Name + ">";
        }

        public virtual T Create(T entity, bool useTransaction = false)
        {
            try
            {
                if (entity != null)
                {
                    SetInsertProperties(entity);
                    dbSet.Add(entity);

                    /// Log Success

                    if (!useTransaction) context.SaveChanges();
                }
                else
                {
                    throw new Exception("Entity not allow null");
                }
            }
            catch
            {
                /// Log Error
                throw;
            }
            return entity!;
        }

        public virtual void Create(ICollection<T> entities, bool useTransaction = false)
        {
            try
            {
                if (entities == null || entities.Count <= 0) return;

                entities.ToList().ForEach(delegate (T p)
                {
                    SetInsertProperties(p);
                });
                dbSet.AddRange(entities);

                /// Log Success

                if (!useTransaction) context.SaveChanges();
            }
            catch
            {
                /// Log Error
                throw;
            }
        }

        public virtual async Task<T> CreateAsync(T entity, bool useTransaction = false)
        {
            try
            {
                if (entity != null)
                {
                    SetInsertProperties(entity);
                    await dbSet.AddAsync(entity);

                    /// Log Success

                    if (!useTransaction) context.SaveChanges();
                }
                else
                {
                    throw new Exception("Entity not allow null");
                }
            }
            catch
            {
                /// Log Error
                throw;
            }
            return entity!;
        }

        public virtual async void CreateAsync(ICollection<T> entities, bool useTransaction = false)
        {
            try
            {
                if (entities == null || entities.Count <= 0) return;

                entities.ToList().ForEach(delegate (T p)
                {
                    SetInsertProperties(p);
                });

                await dbSet.AddRangeAsync(entities);

                /// Log Success

                if (!useTransaction) context.SaveChanges();
            }
            catch
            {
                /// Log Error
                throw;
            }
        }

        public T Update(string id, T entity, bool useTransaction = false)
        {
            try
            {
                var exists = base.GetById(id);
                if (exists == null) throw new Exception("Data not found");
                //if (exists.RowVersion != entity.RowVersion) throw new Exception("Invalid Row Version");
                entity = Update(entity, useTransaction);
            }
            catch
            {
                throw;
            }
            return entity;
        }

        public T Update(T entity, bool useTransaction = false)
        {
            var exists = base.GetById(entity.Id);
            try
            {
                if (exists == null) throw new Exception("Data not found");
                //if (exists.RowVersion != entity.RowVersion) throw new Exception("Invalid Row Version");
                SetUpdateProperties(entity);
                SetAutoMapperUpdate(entity);

                //context.Entry(exists).CurrentValues.SetValues(entity);

                /// Log Success

                if (!useTransaction) context.SaveChanges();
            }
            catch
            {
                /// Log Error
                throw;
            }
            return exists;
        }

        public virtual void Update(ICollection<T> entities, bool useTransaction = false)
        {
            foreach (T entity in entities) Update(entity, useTransaction);
        }

        public virtual async Task<T> UpdateAsync(string id, T entity, bool useTransaction = false)
        {
            try
            {
                var exists = await base.GetByIDAsync(id);
                if (exists == null) throw new Exception("Data not found");
                //if (exists.RowVersion != entity.RowVersion) throw new Exception("Invalid Row Version");
                entity = await UpdateAsync(entity, useTransaction);
            }
            catch
            {
                throw;
            }
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity, bool useTransaction = false)
        {
            try
            {
                var exists = await base.GetByIDAsync(entity.Id);
                if (exists == null) throw new Exception("Data not found");
                //if (exists.RowVersion != entity.RowVersion) throw new Exception("Invalid Row Version");

                SetUpdateProperties(entity);

                /// Log Success

                if (!useTransaction) context.SaveChanges();
            }
            catch
            {
                /// Log Error
                throw;
            }
            return entity;
        }

        public virtual async void UpdateAsync(ICollection<T> entities, bool useTransaction = false)
        {
            foreach (T entity in entities) await UpdateAsync(entity, useTransaction);
        }

        public virtual T Delete(string id, bool useTransaction = false)
        {
            var entity = GetById(id);
            if (entity == null) throw new Exception("Entity not allow null");
            Delete(entity, useTransaction);
            return entity;
        }

        public virtual T Delete(T entity, bool useTransaction = false)
        {
            try
            {
                if (entity != null)
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    dbSet.Remove(entity);

                    /// Log Success

                    if (!useTransaction) context.SaveChanges();
                }
                else
                {
                    throw new Exception("Entity not allow null");
                }
            }
            catch
            {
                /// Log Error
                throw;
            }
            return entity!;
        }

        public virtual void Delete(ICollection<T> entities, bool useTransaction = false)
        {
            try
            {
                if (entities == null || entities.Count <= 0) return;

                dbSet.RemoveRange(entities);
                context.Entry(entities).State = EntityState.Deleted;

                /// Log Success
                if (!useTransaction) context.SaveChanges();
            }
            catch
            {
                /// Log Error
                throw;
            }
        }

        public virtual T Disable(string id, bool useTransaction = false)
        {
            try
            {
                var entity = base.GetById(id);
                if (entity == null) throw new Exception($"Entity not found with Id {id}");
                entity = Disable(entity, useTransaction);
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public virtual T Disable(T entity, bool useTransaction = false)
        {
            try
            {
                entity.Disabled = true;
                entity = Update(entity, useTransaction);
            }
            catch
            {
                throw;
            }
            return entity;
        }

        public virtual void Disable(ICollection<T> entities, bool useTransaction = false)
        {
            try
            {
                foreach (T entity in entities) Update(entity, useTransaction);
            }
            catch
            {
                throw;
            }
        }

        protected virtual void SetInsertProperties(T entity)
        {
            Helper.setPostData(entity, pctx);
        }

        protected virtual void SetUpdateProperties(T entity)
        {
            Helper.setPutData(entity, pctx);
        }

        public T SetAutoMapperUpdate(T entity)
        {
            T? destination = base.GetById(entity.Id);
            MapperConfiguration configurationProvider = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<T, T>().ForMember((T des) => des.Id, delegate (IMemberConfigurationExpression<T, T, string> opt)
                {
                    opt.Ignore();
                }).ForMember((T des) => des.RowVersion, delegate (IMemberConfigurationExpression<T, T, byte[]> opt)
                {
                    opt.Ignore();
                }).ForMember((T des) => des.CreatedBy, delegate (IMemberConfigurationExpression<T, T, string> opt)
                {
                    opt.Ignore();
                }).ForMember((T des) => des.CreatedByUserDisplayName, delegate (IMemberConfigurationExpression<T, T, string> opt)
                {
                    opt.Ignore();
                }).ForMember((T des) => des.CreatedDate, delegate (IMemberConfigurationExpression<T, T, DateTime> opt)
                {
                    opt.Ignore();
                }).ForMember((T des) => des.CreatedDateUTC, delegate (IMemberConfigurationExpression<T, T, DateTime> opt)
                {
                    opt.Ignore();
                });

                //cfg.ForAllPropertyMaps((PropertyMap map) => FilterICollectionAndBaseEntityMembersForCascadeOff(map), delegate (PropertyMap map, IMemberConfigurationExpression options)
                //{
                //    options.Ignore();
                //});
            });
            IMapper mapper = new Mapper(configurationProvider);
            entity.LogInc = destination!.LogInc + 1;
            return mapper.Map(entity, destination);
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }

        TDbContext IBaseRepository<TDbContext, T>.GetDbContext() => context;
    }
}