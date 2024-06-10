using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using ERPS.Core.Interfaces.v1;

namespace ERPS.Infrastructure.Repositories.v1
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private readonly AppDBContext _context;
        public StatusRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
    }
}