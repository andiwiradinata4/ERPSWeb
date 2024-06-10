using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using ERPS.Core.Interfaces.v1;

namespace ERPS.Infrastructure.Repositories.v1
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
