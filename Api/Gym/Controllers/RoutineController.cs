﻿using Gym.DataAccess.Request;
using Gym.Enums;
using Gym.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Api.Controllers
{
    [Route("api/routine")]
    [Authorize]
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
            _logger.LogInformation("Get routine number {id} started", new { id });
            var result = _routineService.Get(id);

            if (result == null)
            {
                _logger.LogInformation("Get returned none");
                return NotFound();
            }

            _logger.LogInformation("Get returned object number {id}", new { id });
            return Ok(result);
        }


        [HttpPut("{id}")]
        [Authorize(nameof(Policies.NotStudent))]
        public IActionResult CreateOrUpdate(int id, [FromBody] RoutineRequest model)
        {
            _logger.LogInformation("Create or update routine started");
            var result = _routineService.CreateOrUpdate(id, model);
            _logger.LogInformation("Routine Created or updated successfuly");

            return CreatedAtAction("Get", new { id }, result);
        }
    }
}
