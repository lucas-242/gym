using Gym.Entities;
using Gym.Enums;
using Gym.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Api.Controllers
{
    [Route("api/user")]
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
        [Authorize(nameof(Policies.NotStudent))]
        public IActionResult Create([FromBody] User request)
        {
            _logger.LogInformation("Create user started");
            var response = _userService.Create(request);
            _logger.LogInformation("User created");

            return Created($"user/{response.Id}", response);
        }
    }
}
