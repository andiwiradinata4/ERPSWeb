using ERPS.Core.Entities.Base;
using ERPS.Core.Entities.Base.Interface;
using ERPS.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPS.Web.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseSelectController<TDbContext, T> : ControllerBase where TDbContext : DbContext where T : BaseEntity, IEntityStandard
    {
        protected IBaseService<TDbContext, T> svc;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BaseSelectController()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public BaseSelectController(IBaseService<TDbContext, T> svc)
        {
            this.svc = svc;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(svc.GetAll());
        }

        //[HttpGet]
        //[EnableQuery]
        //public virtual IActionResult Get(ODataQueryOptions<T> queryOptions)
        //{
        //    return Ok(svc.GetByODataQuery(queryOptions));
        //}

        [HttpGet("{id}")]
        public virtual IActionResult Get(string id)
        {
            T? data = svc.GetById(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet("columns")]
        public virtual IActionResult GetColumns()
        {
            var data = svc.GetColumnSet();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost("page")]
        public virtual IActionResult PostPageList(QueryObject query)
        {
            return Ok(svc.GetAll(query));
        }
    }
}
