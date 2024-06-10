using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using ERPS.Core.Interfaces.v1;

namespace ERPS.Infrastructure.Repositories.v1
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
