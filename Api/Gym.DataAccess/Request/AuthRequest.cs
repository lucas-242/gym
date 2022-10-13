﻿using System.ComponentModel.DataAnnotations;

namespace Gym.DataAccess.Request
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
