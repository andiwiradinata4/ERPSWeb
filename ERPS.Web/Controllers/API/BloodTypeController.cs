using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Entities;
using ERPS.Application.Interfaces;

namespace ERPS.Web.Controllers.API
{
    [Route("api/blood-type")]
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
