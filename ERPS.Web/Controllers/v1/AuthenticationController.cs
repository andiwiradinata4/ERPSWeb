﻿using ERPS.Application.DTOs.v1.Authentication;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Exceptions.v1;
using ERPS.Core.Response.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models.dto.Account;
using System.Security.Claims;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly IAuthenticationService _svc;

        public AuthenticationController(IAuthenticationService svc)
        {
            _svc = svc;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(new AppResponse(true, "User Created", await _svc.Register(registerDTO)));
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(new AppResponse(true, "Login Successfully", await _svc.Login(dto)));
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

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                string? refreshToken = HttpContext.Request.Headers["RefreshToken"];
                if (refreshToken == null) return Unauthorized(new AppResponse(false, "Refresh Token needed to access this endpoint", null));
                return Ok(new AppResponse(true, "Success", await _svc.RefreshToken(refreshToken)));
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

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Ok(new AppResponse(true, "Success", await _svc.GetDetailUser(userId ?? "")));
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

        [HttpPost("email-confirmation-token")]
        [Authorize]
        public async Task<IActionResult> EmailConfirmationToken()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));

                var result = await _svc.EmailConfirmationToken(userId);
                return Ok(new AppResponse(true, "Success", new { result.AccessToken, result.Code }));
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

        [HttpPost("verify-email-confirmation-token")]
        [Authorize]
        public async Task<IActionResult> VerifyEmailConfirmationToken([FromBody] VerifyTokenDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));
                return Ok(new AppResponse(true, "Success", await _svc.VerifyEmailConfirmationToken(userId, dto) == true ? null : false));
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

        [HttpPost("change-email-token")]
        [Authorize]
        public async Task<IActionResult> ChangeEmailToken([FromBody] ChangeEmailTokenDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));

                var result = await _svc.ChangeEmailToken(userId, dto.NewEmail);
                return Ok(new AppResponse(true, "Success", new { result.AccessToken, result.Code }));
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

        [HttpPost("change-email")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));

                var result = await _svc.ChangeEmail(userId, dto);
                return Ok(new AppResponse(true, "Success", null));
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

        [HttpPost("change-phone-number-token")]
        [Authorize]
        public async Task<IActionResult> ChangePhoneNumberToken([FromBody] ChangePhoneNumberTokenDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));
                var result = await _svc.ChangePhoneNumberToken(userId, dto.NewPhoneNumber);
                return Ok(new AppResponse(true, "Success", new { result.AccessToken, result.Code }));
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

        [HttpPost("change-phone-number")]
        [Authorize]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] ChangePhoneNumberDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));
                var result = await _svc.ChangePhoneNumber(userId, dto);
                return Ok(new AppResponse(true, "Success", null));
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

        [HttpPost("reset-password-token")]
        public async Task<IActionResult> ResetPasswordToken([FromBody] ResetPasswordTokenDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _svc.ResetPasswordToken(dto);
                return Ok(new AppResponse(true, "Success", new { result.AccessToken, result.Code }));
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

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _svc.ResetPassword(dto);
                return Ok(new AppResponse(true, "Success", null));
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

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));
                var result = await _svc.ChangePassword(userId, dto);
                return Ok(new AppResponse(true, "Success", null));
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
