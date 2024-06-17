using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces.v1;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/blood-type")]
    [ApiController]
    public class BloodTypeController : BaseController<BloodType>
    {
        private readonly IBloodTypeService _svc;
        public BloodTypeController(IBloodTypeService svc) : base(svc)
        {
            _svc = svc;
        }

        //using (var sqlTrans = _context.Database.BeginTransaction())
        //{
        //    sqlTrans.Commit();
        //    sqlTrans.Rollback();
        //}

    }
}
