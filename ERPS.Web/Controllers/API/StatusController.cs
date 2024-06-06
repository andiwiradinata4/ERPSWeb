using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Models;
using ERPS.Application.Interfaces;
using ERPS.Core.Exceptions;
using ERPS.Core.Response;

namespace ERPS.Web.Controllers.API
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : BaseController<Status>
    {

        private readonly IStatusService _svc;

        public StatusController(IStatusService svc) : base(svc)
        {
            _svc = svc;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Status RequestDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Status model = RequestDto;
                var data = await _svc.CreateAsync(model);
                return Created("", new AppResponse(true, "Save Data Success", new { data.ID }));
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

        //[HttpPut]
        //[Route("{id}")]
        //public async Task<IActionResult> Update([FromRoute] byte id, [FromBody] CreateOrUpdateDto RequestDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest(ModelState);
        //        Status dataFromDto = RequestDto.FromCreateOrUpdateStatusDto();
        //        var data = await _svc.UpdateAsync(id, dataFromDto);
        //        if (data == null) return NotFound();
        //        return Ok(new AppResponse(true, "Save Data Success", new { id }));
        //    }
        //    catch (AppException ex)
        //    {
        //        return BadRequest(new AppResponse(false, ex.Message, null));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new AppResponse(false, ex.InnerException, null));
        //    }
        //}
    }
}
