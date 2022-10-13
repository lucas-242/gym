using Gym.Entities;

namespace Gym.Application.Services.Repositories
{
    public interface IAuthRepository
    {
        public User? Get(string email);
        void CreateRefreshToken(RefreshToken model);
    }
}
