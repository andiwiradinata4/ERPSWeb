using ERPS.Application.DTOs.v1.Authentication;
using ERPS.Application.Interfaces.v1;
using ERPS.Core.Entities;
using ERPS.Core.Exceptions.v1;
using ERPS.Core.Response.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models.dto.Account;
using System.Security.Claims;

namespace ERPS.Web.Controllers.API.v1
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthenticationService _svc;

        public AuthenticationController(UserManager<AppUser> userManager, IAuthenticationService svc)
        {
            _userManager = userManager;
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
                return Ok(new AppResponse(true, "Success", new { result.Token, result.Code }));
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
                return Ok(new AppResponse(true, "Success", new { result.Token, result.Code }));
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
                return Ok(new AppResponse(true, "Success", new { result.Token, result.Code }));
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
        [Authorize]
        public async Task<IActionResult> ResetPasswordToken([FromBody] ResetPasswordTokenDTO dto)
        {
            //var tokenType = "RESET_PASSWORD";
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //var user = await _userManager.FindByEmailAsync(dto.Email);

                //if (user == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));

                //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var code = _svc.GenerateCode(user, tokenType, token);

                var result = await _svc.ResetPasswordToken(dto);
                return Ok(new AppResponse(true, "Success", new { result.Token, result.Code }));
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
        [Authorize]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            //var tokenType = "RESET_PASSWORD";
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _svc.ResetPassword(dto);
                return Ok(new AppResponse(true, "Success", null));
                //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //var user = await _userManager.FindByIdAsync(userId ?? "");
                //if (user == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));

                //var token = _svc.GetToken(dto.Token);
                //if (token == null) return Unauthorized(new AppResponse(false, "Token is not valid.", null));
                //if (token.TokenType != tokenType) return Unauthorized(new AppResponse(false, "Token is not valid.", null));
                //if (token.Code != dto.Code) return Unauthorized(new AppResponse(false, "Code is not valid.", null));
                //var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);

                //if (result.Succeeded)
                //{
                //    _svc.GenerateCode(user, tokenType, "SUCCESS");

                //    return Ok(new AppResponse(true, "Success", null));
                //}
                //else
                //{
                //    return Unauthorized(new AppResponse(false, result.Errors.First().Description, null));
                //}
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
                //var user = await _userManager.FindByIdAsync(userId ?? "");
                //if (user == null) return Unauthorized(new AppResponse(false, "User is not valid.", null));


                var result = await _svc.ChangePassword(userId, dto);
                return Ok(new AppResponse(true, "Success", null));

                //if (result.Succeeded)
                //{
                //    return Ok(new AppResponse(true, "Success", null));
                //}
                //else
                //{
                //    return Unauthorized(new AppResponse(false, result.Errors.First().Description, null));
                //}
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
