using ERPS.Core.DTOs.Authentication;
using ERPS.Core.Entities.Master;
using ERPS.Infrastructure.Utilities;

namespace ERPS.Infrastructure.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<MessageObject<TokenDTO>> Register(RegisterDTO user);
        Token? GetTokenAsync(string token);
        TokenDTO CreateJWTToken(AppUser user);
        string GenerateCode(AppUser user, string tokenType, string token);
        Task<MessageObject<TokenDTO>> Login(LoginDTO dto);
        Task<MessageObject<TokenDTO>> RefreshToken(string refreshToken);
        Task<MessageObject<AppUser>> GetDetailUser(string userId);
        Task<MessageObject<VerifyConfirmEmailDTO>> EmailConfirmationToken(string userId);
        Task<MessageObject<bool>> VerifyEmailConfirmationToken(string userId, VerifyConfirmEmailDTO dto);
        Task<MessageObject<VerifyConfirmEmailDTO>> ChangeEmailToken(string userId, string newEmail);
        Task<MessageObject<bool>> ChangeEmail(string userId, ChangeEmailDTO dto);
        Task<MessageObject<VerifyTokenDTO>> ChangePhoneNumberToken(string userId, string newPhoneNumber);
        Task<bool> ChangePhoneNumber(string userId, ChangePhoneNumberDTO dto);
        Task<MessageObject<VerifyTokenDTO>> ResetPasswordToken(ResetPasswordTokenDTO dto);
        Task<bool> ResetPassword(ResetPasswordDTO dto);
        Task<bool> ChangePassword(string userId, ChangePasswordDTO dto);
    }
}