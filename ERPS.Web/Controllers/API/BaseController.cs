using Microsoft.AspNetCore.Mvc;
using ERPS.Application.Interfaces;
using ERPS.Core.Exceptions;
using ERPS.Core.Response;
namespace ERPS.Web.Controllers.API
{
    public class BaseController<T> : Controller where T : class
    {
        private readonly IBaseService<T> _svc;

        public BaseController(IBaseService<T> svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string[] includes)
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
        public async Task<IActionResult> GetByID([FromRoute] int id)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
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