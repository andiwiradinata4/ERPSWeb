using Microsoft.AspNetCore.Mvc;
using ERPS.Application.Interfaces;
using ERPS.Core.Exceptions;
using ERPS.Core.Response;
namespace ERPS.Web.Controllers.API
{
    public abstract class BaseController<T> : Controller where T : class
    {
        private readonly IBaseService<T> _svc;

        public BaseController(IBaseService<T> svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll([FromQuery] string[] includes)
        {
            try
            {
                return Ok(new AppResponse(true, "Get All Data Success", await _svc.GetAllAsync(includes)));
            }
            catch (AppException ex)
            {
                return BadRequest(new AppResponse(false, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new AppResponse(false, ex.InnerException, null));
            }
        }

        [HttpGet("{id}")]
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
                return BadRequest(new AppResponse(false, ex.InnerException, null));
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T entity)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                dynamic data = await _svc.CreateAsync(entity);
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
        public virtual async Task<IActionResult> Update([FromRoute] string id, [FromBody] T entity)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var data = await _svc.UpdateAsync(id, entity);
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
                return BadRequest(new AppResponse(false, ex.InnerException, null));
            }

        }
    }
}