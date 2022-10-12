using Gym.Application.Repositories;
using Gym.Domain.Entities;
using Gym.Infrastructure.Interfaces;

namespace Gym.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public UserRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public User Create(User model)
        {
            _applicationDbContext.Users.Add(model);
            _applicationDbContext.SaveChanges();
            return model;
        }

        public User? Get(string email)
        {
            var response = _applicationDbContext.Users.Where(u => u.Email == email).SingleOrDefault();
            return response;

        }
    }
}
