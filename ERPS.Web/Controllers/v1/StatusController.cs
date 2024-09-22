using Microsoft.AspNetCore.Mvc;
using ERPS.Infrastructure.Interfaces.Services;
using ERPS.Core.Entities.Master;
using ERPS.Core.DbContext.v1;
using ERPS.Web.Controllers.Base;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/status")]
    [ApiController]
    public class StatusController : BaseController<AppDBContext, Status>
    {
        public StatusController(IBaseService<AppDBContext, Status> svc) : base(svc) { }
    }
}
