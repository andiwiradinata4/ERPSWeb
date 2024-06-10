using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using ERPS.Core.Interfaces.v1;

namespace ERPS.Infrastructure.Repositories.v1
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