using Gym.DataAccess.Request;
using Gym.Entities;
using Gym.Enums;
using Gym.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Gym.Api.Utils;

namespace Gym.Api.Controllers
{
    [Route("api/routine")]
    [Authorize(nameof(Policies.NotStudent))]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly ILogger<RoutineController> _logger;
        private readonly IRoutineService _routineService;

        public RoutineController(ILogger<RoutineController> logger, IRoutineService routineService)
        {
            _logger = logger;
            _routineService = routineService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //_logger.LogInformation("Update routine started");
            //var result = _routineService.CreateOrUpdate(id, model);
            //_logger.LogInformation("Routine updated successfuly");

            //return Created(HttpContext.GetUrl($"routine/{result.Id}"), result);
            //return Created(HttpContext.GetUrl($"routine/{result.Id}"), result);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult CreateOrUpdate(int id, [FromBody] RoutineRequest model)
        {
            _logger.LogInformation("Update routine started");
            var result = _routineService.CreateOrUpdate(id, model);
            _logger.LogInformation("Routine updated successfuly");

            return CreatedAtAction("Get", new { id = id }, result);
        }
    }
}
