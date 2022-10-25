using Gym.Api.Utils;
using Gym.DataAccess.Request;
using Gym.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("authenticateByEmail")]
        public IActionResult AuthenticateByEmail([FromBody] AuthRequest request)
        {
            _logger.LogInformation("Authenticate by email started");
            var response = _authService.AuthenticateByEmail(request);
            _logger.LogInformation("Authenticated by email successfuly");

            return Ok(response);
        }

        [HttpPost("refreshToken")]
        public IActionResult RefreshToken([FromBody] string refreshToken)
        {
            _logger.LogInformation("Refresh token started");
            var response = _authService.RefreshToken(refreshToken);
            _logger.LogInformation("Token Refreshed successfuly");

            return Ok(response);
        }
    }


}
