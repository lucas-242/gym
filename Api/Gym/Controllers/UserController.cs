﻿using Gym.Domain.Entities;
using Gym.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<AuthController> logger, IUserService authService)
        {
            _logger = logger;
            _userService = authService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User request)
        {
            try
            {
                _logger.LogInformation("Create user initiated");
                var response = _userService.Create(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
