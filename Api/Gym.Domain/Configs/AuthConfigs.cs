namespace Gym.Gonfigs
{
    public sealed class AuthConfigs
    {
        public string JwtSecret { get; set; }

        public int PasswordHashIterations { get; set; }

        public int PasswordSaltSize { get; set; }

        public int PasswordKeySize { get; set; }
    }
}
