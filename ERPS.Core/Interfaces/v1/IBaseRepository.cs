﻿using ERPS.Core.Entities;
namespace ERPS.Core.Interfaces.v1
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(QueryObject query);
        Task<T> GetByIDAsync(dynamic id);
        Task<int> GetMaxID();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(dynamic id, T entity);
        Task<T> DeleteAsync(dynamic id);
    }
}