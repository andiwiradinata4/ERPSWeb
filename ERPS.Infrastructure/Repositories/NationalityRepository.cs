using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
{
    public class NationalityRepository : BaseRepository<Nationality>, INationalityRepository
    {
        private readonly AppDBContext _context;

        public NationalityRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Nationality> CreateAsync(Nationality data)
        {
            await new ReferencesRepository(_context).IsExistsStatusID(data.StatusID);
            await _context.Nationality.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<Nationality> UpdateAsync(int id, Nationality data)
        {
            var dataExists = await _context.Nationality.FirstOrDefaultAsync(a => a.ID == id);
            if (dataExists == null) throw new AppException("Data Not Found");
            dataExists.Description = data.Description;
            dataExists.StatusID = data.StatusID;
            dataExists.Remarks = data.Remarks;
            await _context.SaveChangesAsync();
            return data;
        }

    }
}
