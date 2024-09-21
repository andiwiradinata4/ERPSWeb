using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;
using ERPS.Infrastructure.Interfaces.Services;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/status")]
    [ApiController]
    public class StatusController : BaseController<Status>
    {

        private readonly IStatusService _svc;

        public StatusController(IStatusService svc) : base(svc)
        {
            _svc = svc;
        }

    }
}
