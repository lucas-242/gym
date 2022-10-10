namespace Gym.Authentication.Domain.Entities
{
    public sealed class AuthConfigs
    {
        /// <summary>Secret utilizado ao gerar o token JWT</summary>
        public string JwtSecret { get; set; }

        /// <summary>Número de iterações no momento de efetuar o hasher da senha</summary>
        public int PasswordHashIterations { get; set; }

        public int PasswordSaltSize { get; set; }

        public int PasswordKeySize { get; set; }
    }
}
