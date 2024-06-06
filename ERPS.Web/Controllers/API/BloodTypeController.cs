﻿using Microsoft.AspNetCore.Mvc;
using ERPS.Core.Models;
using ERPS.Application.Interfaces;
using ERPS.Core.Exceptions;
using ERPS.Core.Response;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BloodType Requestdto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                BloodType data = Requestdto;
                data = await _svc.CreateAsync(data);
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BaseMasterCreateOrUpdateDto Requestdto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest(ModelState);
        //        BloodType data = Requestdto.FromCreateOrUpdateBloodTypeDto();
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