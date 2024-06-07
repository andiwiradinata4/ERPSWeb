using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Models;

namespace ERPS.Infrastructure.Repositories
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
