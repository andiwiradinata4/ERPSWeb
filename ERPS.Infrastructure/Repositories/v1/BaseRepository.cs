using Microsoft.EntityFrameworkCore;
using ERPS.Core.Exceptions.v1;
using ERPS.Infrastructure.Data.v1;
using ERPS.Core.Interfaces.v1;
using ERPS.Core.Entities;
using System.Numerics;

namespace ERPS.Infrastructure.Repositories.v1
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly FKValidatorRepository _FKValidatorRepository;
        public BaseRepository(AppDBContext context)
        {
            _context = context;
            _FKValidatorRepository = new FKValidatorRepository(context);
        }

        public async Task<List<T>> GetAllAsync(QueryObject query)
        {
            return await _context.SetQuery<T>(query).ToListAsync();
        }

        public async Task<BigInteger> GetTotalPageAsync(QueryObject query)
        {
            var data = await _context.SetQueryTotalPage<T>(query).ToListAsync();
            if (data == null) return 0;
            return data.Count;
        }

        public async Task<T> GetByIDAsync(dynamic id)
        {
            int intID = 0;
            int.TryParse(id.ToString(), out intID);
            var idValue = intID <= 0 ? id : intID;
            var data = await _context.Set<T>().FindAsync(idValue);
            return data ?? throw new AppException("Data Not Found");
        }

        public async Task<int> GetMaxID()
        {
            var ids = await _context.Set<T>().Select(e => EF.Property<int>(e, "ID")).ToListAsync();
            return ids.Any() ? ids.Max() + 1 : 1;
        }

        public async Task<T> CreateAsync(T entity, bool useTransaction = false)
        {
            await _FKValidatorRepository.ValidateFKAsync(entity);
            await _context.Set<T>().AddAsync(entity);
            if (!useTransaction) await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(dynamic id, T entity, bool useTransaction = false)
        {
            await _FKValidatorRepository.ValidateFKAsync(entity);

            int intID = 0;
            int.TryParse(id.ToString(), out intID);
            var idValue = intID <= 0 ? id : intID;
            var dataExists = await _context.Set<T>().FindAsync(idValue);

            if (dataExists == null) throw new AppException("Data Not Found");

            var propertiesEntity = entity.GetType().GetProperties();
            var propertiesExists = typeof(T).GetProperties();
            foreach (var propertyExists in propertiesExists)
            {
                var propertyExistsName = propertyExists.Name;
                var propertyExistsValue = propertyExists.GetValue(dataExists);
                foreach (var propertyEntity in propertiesEntity)
                {
                    if (propertyExistsName == propertyEntity.Name && NeedReplace(propertyEntity.Name)) propertyEntity.SetValue(entity, propertyExistsValue);
                }
            }

            _context.Entry(dataExists).CurrentValues.SetValues(entity);
            if (!useTransaction) await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(dynamic id, bool useTransaction = false)
        {
            int intID = 0;
            int.TryParse(id.ToString(), out intID);
            var idValue = intID <= 0 ? id : intID;
            var data = await _context.Set<T>().FindAsync(idValue) ?? throw new AppException("Data not found");
            _context.Set<T>().Remove(data);
            if (!useTransaction) await _context.SaveChangesAsync();
            return data;
        }

        private bool NeedReplace(string propertyName)
        {
            if (propertyName == "ID") return true;
            if (propertyName == "CreatedBy") return true;
            if (propertyName == "CreatedDate") return true;
            return false;
        }
    }
}