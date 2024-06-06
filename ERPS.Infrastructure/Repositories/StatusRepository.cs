using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private readonly AppDBContext _context;
        public StatusRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Status> CreateAsync(Status data)
        {
            await _context.Status.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<Status> UpdateAsync(int id, Status data)
        {
            var dataExists = await _context.Status.FirstOrDefaultAsync(a => a.ID == id);
            if (dataExists == null) throw new AppException("Data Not Found");
            dataExists.Description = data.Description;
            dataExists.IsActive = data.IsActive;
            dataExists.Remarks = data.Remarks;
            dataExists.LogDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return dataExists;
        }
    }
}