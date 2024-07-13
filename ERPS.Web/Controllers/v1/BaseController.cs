using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Response.v1;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Exceptions.v1;
using Microsoft.AspNetCore.Authorization;
using ERPS.Core.Entities;
using System.Security.Claims;

namespace ERPS.Web.Controllers.API.v1
{
    public abstract class BaseController<T> : Controller where T : class
    {
        private readonly IBaseService<T> _svc;

        public BaseController(IBaseService<T> svc)
        {
            _svc = svc;
        }

        [HttpPost]
        [Authorize]
        public virtual async Task<IActionResult> GetAll([FromBody] QueryObject query)
        {
            try
            {
                return Ok(new AppResponse(true, "Get All Data Success", await _svc.GetAllAsync(query)));
            }
            catch (AppException ex)
            {
                return BadRequest(new AppResponse(false, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new AppResponse(false, ex, null));
            }
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(new AppResponse(true, "Get All Data Success", await _svc.GetAllAsync(new QueryObject())));
            }
            catch (AppException ex)
            {
                return BadRequest(new AppResponse(false, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new AppResponse(false, ex, null));
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public virtual async Task<IActionResult> GetByID([FromRoute] int id)
        {
            try
            {
                return Ok(new AppResponse(true, "Get Data Success", await _svc.GetByIDAsync(id)));
            }
            catch (AppException ex)
            {
                return BadRequest(new AppResponse(false, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new AppResponse(false, ex, null));
            }
        }

        [HttpPost("create")]
        [Authorize]
        public virtual async Task<IActionResult> Create([FromBody] T entity)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                dynamic data = await _svc.CreateAsync(entity, userId);
                return Ok(new AppResponse(true,
                                          "Create Data Success",
                                          new { data.ID }));
            }
            catch (AppException ex)
            {
                return BadRequest(new AppResponse(false, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new AppResponse(false, ex, null));
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public virtual async Task<IActionResult> Update([FromRoute] string id, [FromBody] T entity)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                var data = await _svc.UpdateAsync(id, entity, userId);
                return Ok(new AppResponse(true,
                                          "Update Data Success",
                                          new { id }));
            }
            catch (AppException ex)
            {
                return BadRequest(new AppResponse(false, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new AppResponse(false, ex, null));
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var data = await _svc.DeleteAsync(id);
                return Ok(new AppResponse(true, "Delete Data Success", null));
            }
            catch (AppException ex)
            {
                return BadRequest(new AppResponse(false, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new AppResponse(false, ex, null));
            }

        }
    }
}