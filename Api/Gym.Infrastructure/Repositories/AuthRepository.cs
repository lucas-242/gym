using Gym.Application.Persistence;
using Gym.Application.Services.Repositories;
using Gym.Entities;

namespace Gym.EntityFramework.Repositories
{
    internal class AuthRepository : IAuthRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AuthRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public User? Get(string email)
        {

            var result = _applicationDbContext.Users
                .Where(x => x.Email.ToLower() == email.ToLower())
                .SingleOrDefault();

            return result;
        }

        public void CreateRefreshToken(RefreshToken model)
        {
            _applicationDbContext.RefreshTokens.Add(model);
            _applicationDbContext.SaveChanges();
        }
    }
}
