using ERPS.Core.Interfaces.v1;
using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using Microsoft.EntityFrameworkCore;

namespace ERPS.Infrastructure.Repositories.v1
{
    public class AuthenticationRepository : BaseRepository<AppUser>, IAuthenticationRepository
    {
        private readonly AppDBContext _context;
        public AuthenticationRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        Token? IAuthenticationRepository.GetToken(string tokenValue)
        {
            return _context.Tokens.FirstOrDefault(d => d.TokenValue == tokenValue);
        }

        async Task<Token?> IAuthenticationRepository.GetTokenByUserIDAsync(string userID)
        {
            return await _context.Tokens.FirstOrDefaultAsync(d => d.UserID == userID);
        }

        bool IAuthenticationRepository.SaveToken(Token token)
        {
            var dataExists = _context.Tokens.FirstOrDefault(t => t.UserID == token.UserID && t.TokenType == token.TokenType);
            if (dataExists != null) _context.Tokens.Remove(dataExists);

            _context.Tokens.Add(token);
            _context.SaveChanges();
            return true;
        }
    }
}
