using Gym.Application.Repositories;
using Gym.Entities;
using Gym.Exceptions;
using Gym.Services;
using System.Net;

namespace Gym.Application.Services
{
    internal class UserService : IUserService
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
            var userExist = _userRepository.Get(model.Email) != null;
            if (userExist) throw new AppException(HttpStatusCode.BadRequest, "There is an user with this email");

            model.Password = _passwordHasherService.Hash(model.Password);
            var result = _userRepository.Create(model);
            _userRepository.SaveChanges();
            result.Password = null!;
            return result;


        }
    }
}
