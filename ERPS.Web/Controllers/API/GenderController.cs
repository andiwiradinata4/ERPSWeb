using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Models;
using ERPS.Application.Interfaces;

namespace ERPS.Web.Controllers.API
{
    [Route("api/gender")]
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
