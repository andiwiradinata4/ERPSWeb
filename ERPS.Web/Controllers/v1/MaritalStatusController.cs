using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/marital-status")]
    [ApiController]
    public class MaritalStatusController : BaseController<MaritalStatus>
    {
        private readonly IMaritalStatusService _svc;
        public MaritalStatusController(IMaritalStatusService svc) : base(svc)
        {
            _svc = svc;
        }

    }
}
