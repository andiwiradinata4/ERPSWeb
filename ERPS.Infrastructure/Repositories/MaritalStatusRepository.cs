using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
{
    public class MaritalStatusRepository : BaseRepository<MaritalStatus>, IMaritalStatusRepository
    {
        private readonly AppDBContext _context;

        public MaritalStatusRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MaritalStatus> CreateAsync(MaritalStatus data)
        {
            await new ReferencesRepository(_context).IsExistsStatusID(data.StatusID);
            await _context.MaritalStatus.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<MaritalStatus> UpdateAsync(int id, MaritalStatus data)
        {
            var dataExists = await _context.MaritalStatus.FirstOrDefaultAsync(a => a.ID == id);
            if (dataExists == null) throw new AppException("Data Not Found");
            dataExists.Description = data.Description;
            dataExists.StatusID = data.StatusID;
            dataExists.Remarks = data.Remarks;
            await _context.SaveChangesAsync();
            return dataExists;
        }
    }
}