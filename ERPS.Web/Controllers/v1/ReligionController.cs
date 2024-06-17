using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/religion")]
    [ApiController]
    public class ReligionController : BaseController<Religion>
    {
        private readonly IReligionService _svc;
        public ReligionController(IReligionService svc) : base(svc)
        {
            _svc = svc;
        }

    }
}
