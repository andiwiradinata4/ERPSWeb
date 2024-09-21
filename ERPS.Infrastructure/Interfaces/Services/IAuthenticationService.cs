using ERPS.Application.DTOs.v1.Authentication;
using ERPS.Core.Entities;
using NetCore.Models.dto.Account;

namespace ERPS.Infrastructure.Interfaces.Services
{
    public interface IAuthenticationService : IBaseService<AppUser>
    {
        Task<TokenDTO> Register(RegisterDTO user);
        Token? GetToken(string token);
        TokenDTO CreateJWTToken(AppUser user);
        string GenerateCode(AppUser user, string tokenType, string token);
        Task<TokenDTO> Login(LoginDTO dto);
        Task<TokenDTO> RefreshToken(string refreshToken);
        Task<AppUser> GetDetailUser(string userId);
        Task<VerifyTokenDTO> EmailConfirmationToken(string userId);
        Task<bool> VerifyEmailConfirmationToken(string userId, VerifyTokenDTO dto);
        Task<VerifyTokenDTO> ChangeEmailToken(string userId, string newEmail);
        Task<bool> ChangeEmail(string userId, ChangeEmailDTO dto);
        Task<VerifyTokenDTO> ChangePhoneNumberToken(string userId, string newPhoneNumber);
        Task<bool> ChangePhoneNumber(string userId, ChangePhoneNumberDTO dto);
        Task<VerifyTokenDTO> ResetPasswordToken(ResetPasswordTokenDTO dto);
        Task<bool> ResetPassword(ResetPasswordDTO dto);
        Task<bool> ChangePassword(string userId, ChangePasswordDTO dto);

    }
}