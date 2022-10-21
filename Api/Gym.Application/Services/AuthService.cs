using Gym.Application.Services.Repositories;
using Gym.DataAccess.Request;
using Gym.DataAccess.Response;
using Gym.Entities;
using Gym.Exceptions;
using Gym.Gonfigs;
using Gym.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Gym.Application.Services
{
    internal class AuthService : IAuthService
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
            var user = _authRepository.GetUserByEmail(request.Email);
            if (user == null) throw new AppException(HttpStatusCode.BadRequest, "Email or password is wrong.");

            var (verified, needsUpgrade) = _passwordHasherService.Check(user.Password, request.Password);
            if (!verified) throw new AppException(HttpStatusCode.BadRequest, "Email or password is wrong.");

            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(ipAddress, user.Id);

            _authRepository.CreateRefreshToken(refreshToken);
            _authRepository.SaveChanges();

            return new AuthResponse(jwtToken, refreshToken.Token);
        }

        private string GenerateJwtToken(User user)
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

                Expires = DateTime.UtcNow.AddMinutes(_authConfigs.JwtMinutesToExpire),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress, int userId)
        {
            var number = RandomNumberGenerator.Create();
            var randomBytes = new byte[64];
            number.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddMinutes(_authConfigs.RefreshTokenMinutesToExpire),
                CreatedAt = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserId = userId
            };
        }

        public AuthResponse RefreshToken(string refreshToken, string ipAddress)
        {
            var user = _authRepository.GetUserByToken(refreshToken);
            if (user == null) throw new AppException(HttpStatusCode.BadRequest, "Invalid token");

            RefreshToken? foundedToken = null;
            if (user.RefreshTokens is not null)
                foundedToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken);

            if (foundedToken is null || !foundedToken.IsActive) throw new AppException(HttpStatusCode.BadRequest, "Invalid token");

            var newRefreshToken = GenerateRefreshToken(ipAddress, user.Id);
            UpdateRefreshToken(foundedToken, newRefreshToken, ipAddress);

            _authRepository.CreateRefreshToken(newRefreshToken);

            var jwtToken = GenerateJwtToken(user);
            _authRepository.SaveChanges();

            return new AuthResponse(jwtToken, newRefreshToken.Token);
        }

        private void UpdateRefreshToken(RefreshToken? refreshToken, RefreshToken newRefreshToken, string ipAddress)
        {
            if (refreshToken == null) return;

            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;

            _authRepository.UpdateRefreshToken(refreshToken);
        }
    }
}
