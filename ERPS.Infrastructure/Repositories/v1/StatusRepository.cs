using ERPS.Infrastructure.Repositories.Base;
using ERPS.Core.DbContext.v1;
using ERPS.Infrastructure.Interfaces.Repositories;
using System.Security.Principal;
using ERPS.Core.Entities.Master;

namespace ERPS.Infrastructure.Repositories.v1
{
    public class StatusRepository : BaseRepository<AppDBContext, Status>, IStatusRepository
    {
        private readonly AppDBContext _context;
        private IPrincipal _principal;
        public StatusRepository(AppDBContext context, IPrincipal pctx) : base(context, pctx)
        {
            _context = context;
            _principal = pctx;
        }
    }
}