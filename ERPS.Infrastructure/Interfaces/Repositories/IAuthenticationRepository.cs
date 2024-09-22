using ERPS.Core.DTOs.Authentication;
using ERPS.Core.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Infrastructure.Interfaces.Repositories
{
    public interface IAuthenticationRepository
	{
        Token? GetToken(string token);
        Task<Token?> GetTokenByUserIDAsync(string userID);
        bool SaveToken(Token token);
        bool ChangeEmail(ChangeEmailDTO dto);
        void SaveChanges();
    }
}
