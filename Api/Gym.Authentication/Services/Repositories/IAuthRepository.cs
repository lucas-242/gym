using Gym.Authentication.Domain.Entities;
using Gym.Authentication.Domain.Interfaces;

namespace Gym.Authentication.Services.Repositories
{
    public interface IAuthRepository
    {
        public IUser Get(string email);
        void CreateRefreshToken(RefreshToken model);
        void UpdateRefreshToken(RefreshToken model);
    }
}
