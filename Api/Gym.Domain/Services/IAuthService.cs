using Gym.Domain.Models;

namespace Gym.Domain.Services
{
    public interface IAuthService
    {
        public abstract AuthResponse AuthenticateByEmail(AuthRequest authRequest, string ipAddress);

    }
}
