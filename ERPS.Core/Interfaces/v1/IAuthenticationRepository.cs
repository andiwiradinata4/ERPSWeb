using ERPS.Core.Entities;

namespace ERPS.Core.Interfaces.v1
{
    public interface IAuthenticationRepository : IBaseRepository<AppUser>
    {
        Token? GetToken(string token);
        Task<Token?> GetTokenByUserIDAsync(string userID);
        bool SaveToken(Token token);
    }
}
