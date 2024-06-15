using ERPS.Application.DTOs.v1.Authentication;
using ERPS.Core.Entities;

namespace ERPS.Application.Interfaces.v1
{
    public interface IAuthenticationService
    {
        Task<TokenDTO> Register(RegisterDTO user);
        Token? GetTokenAsync(string token);
        TokenDTO CreateJWTToken(AppUser user);
        string GenerateCode(AppUser user, string tokenType, string token);
        Task<TokenDTO> Login(LoginDTO dto);
        Task<TokenDTO> RefreshToken(string refreshToken);
        Task<AppUser> GetDetailUser(string userId);
        Task<VerifyConfirmEmailDTO> EmailConfirmationToken(string userId);
        Task<bool> VerifyEmailConfirmationToken(string userId, VerifyConfirmEmailDTO dto);
        Task<VerifyConfirmEmailDTO> ChangeEmailToken(string userId, string newEmail);
        Task<bool> ChangeEmail(string userId, ChangeEmailDTO dto);
    }
}