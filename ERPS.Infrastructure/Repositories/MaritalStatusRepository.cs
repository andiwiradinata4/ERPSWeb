using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
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
    }
}