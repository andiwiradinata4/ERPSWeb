using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using ERPS.Core.Interfaces.v1;

namespace ERPS.Infrastructure.Repositories.v1
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