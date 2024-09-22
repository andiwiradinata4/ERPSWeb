using ERPS.Core.Entities.Master;
using ERPS.Infrastructure.Interfaces.Services;
namespace ERPS.Infrastructure.Services.v1
{
    public class AuthenticationService :IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        private readonly IAuthenticationRepository _repo;
        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IAuthenticationRepository repo) : base(repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"] ?? ""));
            _repo = repo;
        }

        public async Task<TokenDTO> Register(RegisterDTO dto)
        {
            string errorMessage = "";

            var user = new AppUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate
            };
            var createUser = await _userManager.CreateAsync(user, dto.Password ?? "");
            if (createUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    var JWTToken = CreateJWTToken(user);
                    return JWTToken;
                }
                else
                {
                    foreach (var error in roleResult.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    if (errorMessage.Length > 0) errorMessage = errorMessage.Substring(0, errorMessage.Length - 3);
                    throw new AppException(errorMessage);
                }
            }
            else
            {
                foreach (var error in createUser.Errors)
                {
                    errorMessage += error.Description + " | ";
                }
                if (errorMessage.Length > 0) errorMessage = errorMessage.Substring(0, errorMessage.Length - 3);
                throw new AppException(errorMessage);
            }
        }

        public async Task<TokenDTO> Login(LoginDTO dto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName.ToLower());
            if (user == null) throw new AppException("Invalid Username.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) throw new AppException("Password incorrect.");

            var token = CreateJWTToken(user);

            var resultSetAuthentication = await _userManager.SetAuthenticationTokenAsync(user, token.Issuer, token.UserName, token.AccessToken);
            if (resultSetAuthentication.Succeeded)
            {
                /// Send Email Notif login success in device ____
                return token;
            }
            else
            {
                throw new AppException(resultSetAuthentication.Errors.First().Description);
            }
        }

        public async Task<TokenDTO> RefreshToken(string refreshToken)
        {
            var token = _repo.GetToken(refreshToken);
            if (token == null) throw new AppException("Invalid Refresh Token.");

            var user = await _userManager.FindByIdAsync(token.UserID);
            if (user == null) throw new AppException("User is not valid.");

            var newToken = CreateJWTToken(user);
            var resultSetAuthentication = await _userManager.SetAuthenticationTokenAsync(user, newToken.Issuer, newToken.UserName, newToken.AccessToken);
            if (resultSetAuthentication.Succeeded)
            {
                return newToken;
            }
            else
            {
                throw new AppException(resultSetAuthentication.Errors.First().Description);
            }
        }

        public async Task<AppUser> GetDetailUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new AppException("User not found.");
            return user;
        }

        public async Task<VerifyTokenDTO> EmailConfirmationToken(string userId)
        {
            var tokenType = "EMAIL_CONFIRMATION";
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new AppException("User not found.");
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var code = GenerateCode(user, tokenType, token);
            /// Send Email Notif for Verification Code
            return new VerifyTokenDTO { Code = code, AccessToken = token };
        }

        public async Task<bool> VerifyEmailConfirmationToken(string userId, VerifyTokenDTO dto)
        {
            var tokenType = "EMAIL_CONFIRMATION";
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new AppException("User not found.");
            var token = GetToken(dto.AccessToken);
            if (token == null || token.TokenType != tokenType) throw new AppException("Token is not valid.");
            if (token.Code != dto.Code) throw new AppException("Code is not valid.");
            var result = await _userManager.ConfirmEmailAsync(user, token.TokenValue);
            if (result.Succeeded)
            {
                GenerateCode(user, tokenType, "SUCCESS");
                /// Send Email Notif for Success Verified Email Address
                return true;
            }
            else
            {
                throw new AppException(result.Errors.First().Description);
            }
        }

        public async Task<VerifyTokenDTO> ChangeEmailToken(string userId, string newEmail)
        {
            var tokenType = "CHANGE_EMAIL";
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new AppException("User not found.");

            var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            var code = GenerateCode(user, tokenType, token);
            /// Send Email Notif for Verification Code
            return new VerifyTokenDTO { Code = code, AccessToken = token };
        }

        public async Task<bool> ChangeEmail(string userId, ChangeEmailDTO dto)
        {
            var tokenType = "CHANGE_EMAIL";
            var user = await _userManager.FindByIdAsync(userId ?? "");
            if (user == null) throw new AppException("User is not valid.");

            if (user.Email != dto.Email) throw new AppException("Invalid old email.");
            var token = GetToken(dto.Token);
            if (token == null) throw new AppException("Token is not valid.");
            if (token.TokenType != tokenType) throw new AppException("Token is not valid.");
            if (token.Code != dto.Code) throw new AppException("Code is not valid.");
            var result = await _userManager.ChangeEmailAsync(user, dto.NewEmail, dto.Token);
            if (result.Succeeded)
            {
                GenerateCode(user, tokenType, "SUCCESS");
                /// Send Email Notif for Success Change Email Address
                return true;
            }
            else
            {
                throw new Exception(result.Errors.First().Description);
            }
        }

        public async Task<VerifyTokenDTO> ChangePhoneNumberToken(string userId, string newPhoneNumber)
        {
            var tokenType = "CHANGE_PHONE_NUMBER";
            var user = await _userManager.FindByIdAsync(userId ?? "");
            if (user == null) throw new AppException("User is not valid.");
            var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, newPhoneNumber);
            var code = GenerateCode(user, tokenType, token);
            /// Send Email Notif for Verification Code
            return new VerifyTokenDTO { Code = code, AccessToken = token };
        }

        public async Task<bool> ChangePhoneNumber(string userId, ChangePhoneNumberDTO dto)
        {
            var tokenType = "CHANGE_PHONE_NUMBER";
            var user = await _userManager.FindByIdAsync(userId ?? "");
            if (user == null) throw new AppException("User is not valid.");

            if (user.PhoneNumber != null && user.PhoneNumber != dto.PhoneNumber) throw new AppException("Invalid old Phone Number.");
            var token = GetToken(dto.Token);
            if (token == null) throw new AppException("Token is not valid.");
            if (token.TokenType != tokenType) throw new AppException("Token is not valid.");
            if (token.Code != dto.Code) throw new AppException("Code is not valid.");
            var result = await _userManager.ChangePhoneNumberAsync(user, dto.NewPhoneNumber, dto.Token);
            if (result.Succeeded)
            {
                GenerateCode(user, tokenType, "SUCCESS");
                /// Send Email Notif for Success Change Phone Number
                return true;
            }
            else
            {
                throw new AppException(result.Errors.First().Description);
            }
        }

        public async Task<VerifyTokenDTO> ResetPasswordToken(ResetPasswordTokenDTO dto)
        {
            var tokenType = "RESET_PASSWORD";
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) throw new AppException($"Email {dto.Email} not found.");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var code = GenerateCode(user, tokenType, token);
            /// Send Email Notif for Verification Code
            return new VerifyTokenDTO { Code = code, AccessToken = token };
        }

        public async Task<bool> ResetPassword(ResetPasswordDTO dto)
        {
            var tokenType = "RESET_PASSWORD";
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) throw new AppException($"Email {dto.Email} not found.");

            var token = GetToken(dto.Token);
            if (token == null) throw new AppException("Token is not valid.");
            if (token.TokenType != tokenType) throw new AppException("Token is not valid.");
            if (token.Code != dto.Code) throw new AppException("Code is not valid.");
            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            if (result.Succeeded)
            {
                GenerateCode(user, tokenType, "SUCCESS");
                /// Send Email Notif for Success Reset Password
                return true;
            }
            else
            {
                throw new AppException(result.Errors.First().Description);
            }
        }

        public async Task<bool> ChangePassword(string userId, ChangePasswordDTO dto)
        {
            var user = await _userManager.FindByIdAsync(userId ?? "");
            if (user == null) throw new AppException("User is not valid.");
            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (result.Succeeded)
            {
                /// Send Email Notif for Success Change Password
                return true;
            }
            else
            {
                throw new AppException(result.Errors.First().Description);
            }
        }
        public TokenDTO CreateJWTToken(AppUser user)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                //new Claim(JwtRegisteredClaimNames.GivenName, user.UserName ?? "")
            };

            var expires = _configuration["JWT:Expires"];
            double.TryParse(expires ?? "10", out double doubleExpires);


            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(doubleExpires),
                SigningCredentials = creds,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var resultToken = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            TokenDTO usToken = new()
            {
                UserName = user.UserName ?? "",
                Email = user.Email ?? "",
                AccessToken = resultToken,
                ValidFrom = token.ValidFrom,
                ValidTo = token.ValidTo,
                RefreshToken = refreshToken,
                Issuer = _configuration["JWT:Issuer"] ?? "",
                Audience = _configuration["JWT:Audience"] ?? ""
            };

            if (user.Id == null) throw new Exception("User ID not Valid!");

            bool bolRefresToken = _repo.SaveToken(new Token()
            {
                UserID = user.Id,
                TokenType = "REFRESH_TOKEN",
                TokenValue = refreshToken,
                ValidFrom = DateTime.Today,
                ValidTo = DateTime.Today.AddYears(100),
            });

            if (!bolRefresToken) throw new Exception("Error when generate fefresh token!");

            return usToken;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public Token? GetToken(string token)
        {
            return _repo.GetToken(token);
        }

        public string GenerateCode(AppUser user, string tokenType, string token)
        {
            string code = "";
            Random rdm = new Random();
            for (int i = 0; i < 6; i++)
            {
                code += rdm.Next(0, 9).ToString();
            }

            bool bolSuccess = _repo.SaveToken(new Token()
            {
                UserID = user.Id,
                TokenType = tokenType,
                TokenValue = token,
                Code = code,
                ValidFrom = DateTime.Today,
                ValidTo = DateTime.Today.AddYears(100),
            });

            if (!bolSuccess) throw new Exception("Error Save Token.");
            return code;
        }

        //public async Task<List<AppUser>> GetAllAsync(QueryObject query)
        //{
        //    return await _repo.GetAllAsync(query);
        //}

        //public async Task<BigInteger> GetTotalPageAsync(QueryObject query)
        //{
        //    return await _repo.GetTotalPageAsync(query);
        //}

        //public async Task<AppUser> GetByIDAsync(dynamic id)
        //{
        //    return await _repo.GetByIDAsync(id);
        //}

        //public async Task<AppUser> DeleteAsync(dynamic id)
        //{
        //    return await _repo.DeleteAsync(id);
        //}

        //public Task<AppUser> CreateAsync(AppUser entity, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<AppUser> UpdateAsync(dynamic id, AppUser entity, string userId)
        //{
        //    return await _repo.UpdateAsync(id, entity, true);
        //}
    }
}
