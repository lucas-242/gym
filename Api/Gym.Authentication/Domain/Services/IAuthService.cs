using Gym.Authentication.Domain.Entities;

namespace Gym.Authentication.Domain.Services
{
    public interface IAuthService
    {
        public abstract AuthResponse AuthenticateByEmail(AuthRequest authRequest, string ipAddress);

    }
}
