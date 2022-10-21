namespace Gym.DataAccess.Response
{
    public class AuthResponse
    {
        public string AuthenticationToken { get; set; }
        public string RefreshToken { get; set; }

        public AuthResponse(string authenticationToken, string refreshToken)
        {
            AuthenticationToken = authenticationToken;
            RefreshToken = refreshToken;
        }

    }
}
