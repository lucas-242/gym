using Gym.Authentication.Domain.Entities;
using Gym.Authentication.Domain.Interfaces;
using Gym.Authentication.Domain.Services;
using Gym.Authentication.Services.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace Gym.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthConfigs _authConfigs;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IAuthRepository _authRepository;

        public AuthService(IOptions<AuthConfigs> authConfigs, IPasswordHasherService passwordHasherService, IAuthRepository authRepository)
        {
            _passwordHasherService = passwordHasherService;
            _authRepository = authRepository;
            _authConfigs = authConfigs.Value;
        }

        public AuthResponse AuthenticateByEmail(AuthRequest request, string ipAddress)
        {
            var user = _authRepository.Get(request.Email);
            if (user == null) throw new Exception("No user found");

            var (verified, needsUpgrade) = _passwordHasherService.Check(user.Password, request.Password);

            if (!verified) throw new Exception("No user found"); ;

            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(ipAddress, user.Id);

            _authRepository.CreateRefreshToken(refreshToken);

            return new AuthResponse(jwtToken, refreshToken.Token);
        }

        private string GenerateJwtToken(IUser user, DateTime? expiresIn = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authConfigs.JwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),

                Expires = expiresIn ?? DateTime.UtcNow.AddMinutes(35),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static RefreshToken GenerateRefreshToken(string ipAddress, int userId, DateTime? expiresIn = null)
        {
            var number = RandomNumberGenerator.Create();
            var randomBytes = new byte[64];
            number.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = expiresIn ?? DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserId = userId
            };
        }


        //public AuthResponse RefreshToken(string token, string ipAddress)
        //{
        //    var user = _userRepository.Get(new UserFilters(null, token)).FirstOrDefault();

        //    if (user == null) return null;

        //    var refreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == token);

        //    if (!refreshToken.IsActive) return null;

        //    var newRefreshToken = GenerateRefreshToken(ipAddress, user.Id);
        //    refreshToken.Revoked = DateTime.UtcNow;
        //    refreshToken.RevokedByIp = ipAddress;
        //    refreshToken.ReplacedByToken = newRefreshToken.Token;

        //    using var ts = new TransactionScope();
        //    _userRepository.UpdateRefreshToken(refreshToken);

        //    user.RefreshTokens.Add(newRefreshToken);
        //    _userRepository.CreateRefreshToken(newRefreshToken);
        //    ts.Complete();


        //    var jwtToken = GenerateToken(user);

        //    return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        //}

        //public bool RevokeToken(string token, string ipAddress)
        //{
        //    var user = _userRepository.Get(new UserFilters(null, token)).FirstOrDefault();

        //    if (user == null) return false;

        //    var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        //    if (!refreshToken.IsActive) return false;

        //    refreshToken.Revoked = DateTime.UtcNow;
        //    refreshToken.RevokedByIp = ipAddress;
        //    _userRepository.UpdateRefreshToken(refreshToken);

        //    return true;
        //}


      

       
    }
}
