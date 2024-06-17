using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/gender")]
    [ApiController]
    public class GenderController : BaseController<Gender>
    {

        private readonly IGenderService _svc;
        public GenderController(IGenderService svc) : base(svc)
        {
            _svc = svc;
        }

    }
}
