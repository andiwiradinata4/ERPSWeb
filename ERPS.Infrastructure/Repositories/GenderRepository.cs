using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        private readonly AppDBContext _context;

        public GenderRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Gender> CreateAsync(Gender data)
        {
            await new ReferencesRepository(_context).IsExistsStatusID(data.StatusID);
            await _context.Genders.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<Gender> UpdateAsync(int id, Gender data)
        {
            var dataExists = await _context.Genders.FirstOrDefaultAsync(a => a.ID == id);
            if (dataExists == null) throw new AppException("Data Not Found");
            dataExists.Description = data.Description;
            dataExists.StatusID = data.StatusID;
            dataExists.Remarks = data.Remarks;
            await _context.SaveChangesAsync();
            return dataExists;
        }

    }
}
