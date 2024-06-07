using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
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
    }
}
