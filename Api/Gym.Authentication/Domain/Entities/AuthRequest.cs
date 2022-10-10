using System.ComponentModel.DataAnnotations;

namespace Gym.Authentication.Domain.Entities
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
