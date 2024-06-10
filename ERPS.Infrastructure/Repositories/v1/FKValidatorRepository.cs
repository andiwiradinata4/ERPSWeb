using ERPS.Core.Exceptions.v1;
using ERPS.Infrastructure.Data.v1;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ERPS.Infrastructure.Repositories.v1
{
    public class FKValidatorRepository
    {
        private readonly AppDBContext _context;
        public FKValidatorRepository(AppDBContext context)
        {
            _context = context;
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        public dynamic GetDbSetByName(string typeName)
        {
            var type = Type.GetType($"ERPS.Core.Models.{typeName}, ERPS.Core");
            if (type == null) throw new AppException($"Type {typeName} not found.");

            var dbSetProperty = _context.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                p.PropertyType.GetGenericArguments().First() == type);
            if (dbSetProperty == null) throw new AppException($"dbSet for type {typeName} not found in context.");

            var method = typeof(FKValidatorRepository).GetMethod(nameof(GetDbSet), BindingFlags.Instance | BindingFlags.Public);
            if (method == null) throw new AppException("method is null when GetDbSetByName");

            var genericMethod = method.MakeGenericMethod(type);
            var dbSet = genericMethod.Invoke(this, null);

            if (dbSet == null) throw new AppException("dbSet is null when GetDbSetByName");

            return dbSet;
        }

        public async Task ValidateFKAsync(object entity)
        {
            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                var foreignKeyAttributes = property.GetCustomAttributes<ForeignKeyAttribute>();

                foreach (var foreignKeyAttribute in foreignKeyAttributes)
                {
                    var foreignKeyValue = property.GetValue(entity);
                    dynamic dbSetFK = GetDbSetByName(foreignKeyAttribute.Name);
                    var exists = await dbSetFK.FindAsync(foreignKeyValue);
                    if (exists == null) throw new AppException($"{property.Name} with ID {foreignKeyValue} does not exist.");
                }
            }
        }
    }
}
