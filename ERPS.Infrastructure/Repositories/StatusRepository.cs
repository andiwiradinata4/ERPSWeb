using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Entities;

namespace ERPS.Infrastructure.Repositories
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