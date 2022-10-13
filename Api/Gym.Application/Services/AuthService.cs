using Gym.Application.Services.Repositories;
using Gym.DataAccess.Request;
using Gym.DataAccess.Response;
using Gym.Domain.Entities;
using Gym.Domain.Helpers;
using Gym.Domain.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Gym.Application.Services
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

        private string GenerateJwtToken(User user, DateTime? expiresIn = null)
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
    }
}
