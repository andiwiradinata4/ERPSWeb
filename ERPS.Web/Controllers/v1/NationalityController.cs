using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/nationality")]
    public class NationalityController : BaseController<Nationality>
    {
        private readonly INationalityService _svc;
        public NationalityController(INationalityService svc) : base(svc)
        {
            _svc = svc;
        }

    }
}
