using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Models;
using ERPS.Application.Interfaces;

namespace ERPS.Web.Controllers.API
{
    [Route("api/status")]
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
