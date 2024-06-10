using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using ERPS.Core.Interfaces.v1;

namespace ERPS.Infrastructure.Repositories.v1
{
    public class NationalityRepository : BaseRepository<Nationality>, INationalityRepository
    {
        private readonly AppDBContext _context;

        public NationalityRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
