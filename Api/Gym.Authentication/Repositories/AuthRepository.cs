using Gym.Authentication.Domain.Entities;
using Gym.Authentication.Domain.Interfaces;
using Gym.Authentication.Services.Repositories;

namespace Gym.Authentication.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public static IUser? Get(string email, string password)
        {
            var users = new List<IUser>
            {
                new User { Id = 1, Name = "batman", Email = "batman@email.com", Password = "batman", Role = "manager" },
                new User { Id = 2, Name = "robin", Email = "robin@email.com", Password = "robin", Role = "employee" }
            };
            return users.Where(x => x.Email.ToLower() == email.ToLower() && x.Password == x.Password).FirstOrDefault();
        }

        public void CreateRefreshToken(RefreshToken model)
        {
            throw new NotImplementedException();
        }

        public IUser Get(string email)
        {
            throw new NotImplementedException();
        }

        public void UpdateRefreshToken(RefreshToken model)
        {
            throw new NotImplementedException();
        }
    }
}
