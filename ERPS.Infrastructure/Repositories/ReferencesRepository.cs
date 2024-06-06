using Microsoft.EntityFrameworkCore;
using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Exceptions;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
{
    public class ReferencesRepository
    {
        private readonly AppDBContext _context;

        public ReferencesRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExistsStatusID(int id)
        {
            Status? data = await _context.Status.FindAsync(id);
            return data == null ? throw new AppException($"Status ID {id} not found") : true;
        }

    }
}
