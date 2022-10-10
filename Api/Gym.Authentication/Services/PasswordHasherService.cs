using Gym.Authentication.Domain.Entities;
using Gym.Authentication.Domain.Services;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Gym.Authentication.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {

        private readonly AuthConfigs _authConfigs;

        public PasswordHasherService(IOptions<AuthConfigs> configs)
        {
            _authConfigs = configs.Value;
        }

        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format. " +
                  "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            var needsUpgrade = iterations != _authConfigs.PasswordHashIterations;

            using var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              iterations,
              HashAlgorithmName.SHA256);

            var keyToCheck = algorithm.GetBytes(_authConfigs.PasswordKeySize);
            var verified = keyToCheck.SequenceEqual(key);

            return (verified, needsUpgrade);
        }

        public string Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
              password,
              _authConfigs.PasswordSaltSize,
              _authConfigs.PasswordHashIterations,
              HashAlgorithmName.SHA256);

            var key = Convert.ToBase64String(algorithm.GetBytes(_authConfigs.PasswordKeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{_authConfigs.PasswordHashIterations}.{salt}.{key}";
        }
    }
}
