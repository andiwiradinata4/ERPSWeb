using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
{
    public class BloodTypeRepository : BaseRepository<BloodType>, IBloodTypeRepository
    {
        private readonly AppDBContext _context;

        public BloodTypeRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BloodType>> GetAllWithIncludes(string[] includes)
        {
            return await _context.BloodTypes.Include("Status").ToListAsync();
            //return await _context.Set<T>().ToListAsync();
        }

        public async Task<BloodType> CreateAsync(BloodType data)
        {
            await new ReferencesRepository(_context).IsExistsStatusID(data.StatusID);
            await _context.BloodTypes.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<BloodType> UpdateAsync(int id, BloodType data)
        {
            await new ReferencesRepository(_context).IsExistsStatusID(data.StatusID);
            var dataExists = await _context.BloodTypes.FirstOrDefaultAsync(a => a.ID == id);
            if (dataExists == null) throw new AppException("Data Not Found");
            dataExists.Description = data.Description;
            dataExists.StatusID = data.StatusID;
            dataExists.Remarks = data.Remarks;
            await _context.SaveChangesAsync();
            return data;
        }

    }
}