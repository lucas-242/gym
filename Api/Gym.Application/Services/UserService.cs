using Gym.Application.Repositories;
using Gym.Domain.Entities;
using Gym.Domain.Services;

namespace Gym.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IUserRepository _userRepository;

        public UserService(IPasswordHasherService passwordHasherService, IUserRepository userRepository)
        {
            _passwordHasherService = passwordHasherService;
            _userRepository = userRepository;
        }

        public User Create(User model)
        {
            try
            {
                model.Password = _passwordHasherService.Hash(model.Password);
                var result = _userRepository.Create(model);
                result.Password = null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("There is an user with this email");
            }

        }
    }
}
