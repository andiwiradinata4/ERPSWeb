using ERPS.Core.Entities.Base;
using ERPS.Core.Entities.Base.Interface;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
namespace ERPS.Core.Interfaces.v1
{
    public interface IBaseRepository<TDbContext, T> : IBaseSelectRepository<TDbContext, T> where TDbContext : DbContext where T : IEntityStandard
	{
		T Create(T entity, bool useTransaction = false);
		void Create(ICollection<T> entities, bool useTransaction = false);
		Task<T> CreateAsync(T entity, bool useTransaction = false);
		void CreateAsync(ICollection<T> entities, bool useTransaction = false);
		T Update(string id, T entity, bool useTransaction = false);
		void Update(ICollection<T> entities, bool useTransaction = false);
		Task<T> UpdateAsync(string id, T entity, bool useTransaction = false);
		void UpdateAsync(ICollection<T> entities, bool useTransaction = false);
		Task<T> UpdateAsync(T entity, bool useTransaction = false);
		T Disable(string id, bool useTransaction = false);
		T Disable(T entity, bool useTransaction = false);
		void Disable(ICollection<T> entities, bool useTransaction = false);
		T Delete(string id, bool useTransaction = false);
		T Delete(T entity, bool useTransaction = false);
		void Delete(ICollection<T> entities, bool useTransaction = false);
		void SaveChanges();
		void Dispose();
		TDbContext GetDbContext();
	}
}