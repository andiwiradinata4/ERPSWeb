using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Models;
using ERPS.Application.Interfaces;

namespace ERPS.Web.Controllers.API
{
    [Route("api/marital-status")]
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
