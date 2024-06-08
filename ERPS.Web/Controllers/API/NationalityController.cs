using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces;

namespace ERPS.Web.Controllers.API
{
    [Route("api/nationality")]
    public class NationalityController : BaseController<Nationality>
    {
        private readonly INationalityService _svc;
        public NationalityController(INationalityService svc) : base(svc)
        {
            _svc = svc;
        }

    }
}
