using ERPS.Infrastructure.Interfaces.Services;
using ERPS.Core.Entities.Master;
using ERPS.Core.DbContext.v1;
using ERPS.Infrastructure.Interfaces.Repositories.Base;
using ERPS.Infrastructure.Interfaces.Repositories;
using ERPS.Infrastructure.Services.Base;

namespace ERPS.Infrastructure.Services.v1
{
    public class StatusService : BaseService<AppDBContext, Status>, IStatusService
    {
        private readonly IBaseRepository<AppDBContext, Status> _baseRepo;
        private readonly IStatusRepository _repo;
        public StatusService(IStatusRepository repo, IBaseRepository<AppDBContext, Status> baseRepo) : base(repo)
        {
            _repo = repo;
            _baseRepo = baseRepo;
        }
    }
}
