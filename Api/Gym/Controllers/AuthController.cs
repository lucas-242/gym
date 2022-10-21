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
        public IActionResult AuthenticateByEmail([FromBody]AuthRequest request)
        {
            try
            {
                _logger.LogInformation("Authenticated Initiated");
                var response = _authService.AuthenticateByEmail(request, IpAddress());

                if (response == null)
                    return BadRequest(new { message = "Email ou senha incorretos" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("refreshToken")]
        public IActionResult RefreshToken([FromBody] string refreshToken)
        {
            try
            {
                _logger.LogInformation("Refresh token Initiated");
                var response = _authService.RefreshToken(refreshToken, IpAddress());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }


}
