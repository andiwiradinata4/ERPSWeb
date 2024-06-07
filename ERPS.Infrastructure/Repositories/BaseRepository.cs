﻿using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;

namespace ERPS.Infrastructure.Repositories
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

        public async Task<List<T>> GetAllAsync(string[] includes)
        {
            return await _context.SetWithIncludes<T>(includes).ToListAsync();
            //return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(dynamic id)
        {
            int intID = 0;
            int.TryParse(id.ToString(), out intID);
            var idValue = (intID <= 0) ? id : intID;
            var data = await _context.Set<T>().FindAsync(idValue);
            return data ?? throw new AppException("Data Not Found");
        }

        public async Task<int> GetMaxID()
        {
            var ids = await _context.Set<T>().Select(e => EF.Property<int>(e, "ID")).ToListAsync();
            return ids.Any() ? ids.Max() + 1 : 1;
        }

        public async Task<T> DeleteAsync(dynamic id)
        {
            int intID = 0;
            int.TryParse(id.ToString(), out intID);
            var idValue = (intID <= 0) ? id : intID;
            var data = await _context.Set<T>().FindAsync(idValue) ?? throw new AppException("Data not found");
            _context.Set<T>().Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _FKValidatorRepository.ValidateFKAsync(entity);
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(dynamic id, T entity)
        {
            await _FKValidatorRepository.ValidateFKAsync(entity);

            int intID = 0;
            int.TryParse(id.ToString(), out intID);
            var idValue = (intID <= 0) ? id : intID;
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
            await _context.SaveChangesAsync();
            return entity;
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