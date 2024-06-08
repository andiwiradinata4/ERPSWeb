using ERPS.Core.Interfaces;
using ERPS.Infrastructure.Data;
using ERPS.Core.Entities;

namespace ERPS.Infrastructure.Repositories
{
    public class BloodTypeRepository : BaseRepository<BloodType>, IBloodTypeRepository
    {
        private readonly AppDBContext _context;

        public BloodTypeRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
    }
}