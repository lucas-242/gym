using Gym.Entities;

namespace Gym.Application.Services.Repositories
{
    public interface IAuthRepository
    {
        public User? GetUserByEmail(string email);
        public User? GetUserByToken(string token);
        void UpdateRefreshToken(RefreshToken model);
        void CreateRefreshToken(RefreshToken model);
        void SaveChanges();
    }
}
