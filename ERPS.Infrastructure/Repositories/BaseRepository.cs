using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;

namespace ERPS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync(string[] includes)
        {
            return await _context.SetWithIncludes<T>(includes).ToListAsync();
            //return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            var data =  await _context.Set<T>().FindAsync(id);
            return data ?? throw new AppException("Data Not Found");
        }

        public async Task<int> GetMaxID()
        {
            var ids = await _context.Set<T>().Select(e => EF.Property<int>(e, "ID")).ToListAsync();
            return ids.Any() ? ids.Max() + 1 : 1;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var data = await _context.Set<T>().FindAsync(id) ?? throw new AppException("Data not found");
            _context.Set<T>().Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}