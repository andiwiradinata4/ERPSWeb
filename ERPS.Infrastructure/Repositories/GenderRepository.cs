using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Entities;

namespace ERPS.Infrastructure.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        private readonly AppDBContext _context;

        public GenderRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
