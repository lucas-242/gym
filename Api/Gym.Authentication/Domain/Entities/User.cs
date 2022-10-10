using Gym.Authentication.Domain.Interfaces;

namespace Gym.Authentication.Domain.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
    }
}
