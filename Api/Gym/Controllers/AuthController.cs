using Gym.Authentication.Domain.Entities;
using Gym.Authentication.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost(Name = "AuthenticateByEmail")]
        public IActionResult AuthenticateByEmail([FromBody]AuthRequest request)
        {
            try
            {
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

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }


}
