using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces;

namespace ERPS.Web.Controllers.API
{
    [Route("api/religion")]
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
