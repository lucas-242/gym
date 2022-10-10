namespace Gym.Authentication.Domain.Entities
{
    public class AuthResponse
    {
        public int Expires { get; set; }
        public string AuthenticationToken { get; set; }
        public string RefreshToken { get; set; }

        public AuthResponse(string authenticationToken, string refreshToken, int expires = 900)
        {
            Expires = expires;
            AuthenticationToken = authenticationToken;
            RefreshToken = refreshToken;
        }
    }
}
