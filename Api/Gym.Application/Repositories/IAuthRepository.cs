using Gym.Domain.Entities;
using Gym.Domain.Models;

namespace Gym.Application.Services.Repositories
{
    public interface IAuthRepository
    {
        public User? Get(string email);
        void CreateRefreshToken(RefreshToken model);
        void UpdateRefreshToken(RefreshToken model);
    }
}
