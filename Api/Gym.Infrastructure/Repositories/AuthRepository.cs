using Gym.Application.Persistence;
using Gym.Application.Services.Repositories;
using Gym.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym.EntityFramework.Repositories
{
    internal class AuthRepository : IAuthRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AuthRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public User? GetUserByEmail(string email)
        {

            var result = _applicationDbContext.Users
                .Where(x => x.Email.ToLower() == email.ToLower())
                .SingleOrDefault();

            return result;
        }

        public User? GetUserByToken(string token)
        {

            var result = _applicationDbContext.Users
                .Include(u => u.RefreshTokens)
                .Where(u => u.RefreshTokens.Select(rt => rt.Token).Contains(token))
                .SingleOrDefault();

            return result;
        }

        public void CreateRefreshToken(RefreshToken model)
        {
            _applicationDbContext.RefreshTokens.Add(model);
        }

        public void UpdateRefreshToken(RefreshToken model)
        {
            _applicationDbContext.RefreshTokens.Update(model);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
