using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
{
    public class ReligionRepository : BaseRepository<Religion>, IReligionRepository
    {
        private readonly AppDBContext _context;

        public ReligionRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Religion> CreateAsync(Religion data)
        {
            await new ReferencesRepository(_context).IsExistsStatusID(data.StatusID);
            await _context.Religions.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<Religion> UpdateAsync(int id, Religion data)
        {
            var dataExists = await _context.Religions.FirstOrDefaultAsync(a => a.ID == id);
            if (dataExists == null) throw new AppException("Data Not Found");
            dataExists.Description = data.Description;
            dataExists.StatusID = data.StatusID;
            dataExists.Remarks = data.Remarks;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
