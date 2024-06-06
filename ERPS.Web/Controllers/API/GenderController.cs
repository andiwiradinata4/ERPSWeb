using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Models;
using ERPS.Application.Interfaces;
using ERPS.Core.Exceptions;
using ERPS.Core.Response;

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

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] BaseMasterCreateOrUpdateDto Requestdto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest(ModelState);
        //        Gender model = Requestdto.FromCreateOrUpdateGenderDto();
        //        model = await _svc.CreateAsync(model);
        //        return CreatedAtAction(nameof(GetByID), new { id = model.ID }, model.ToDto());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BaseMasterCreateOrUpdateDto Requestdto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest(ModelState);
        //        Gender data = Requestdto.FromCreateOrUpdateGenderDto();
        //        data = await _svc.UpdateAsync(id, data);
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
