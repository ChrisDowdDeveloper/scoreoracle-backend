using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.Sport;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportController : ControllerBase
    {
        private readonly SportService _sportService;
        public SportController(SportService sportService)
        {
            _sportService = sportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSports()
        {
            var sports = await _sportService.GetAllSports();
            return Ok(sports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSportById(Guid id)
        {
            var sport = await _sportService.GetSportById(id);
            return sport is null ? NotFound() : Ok(sport);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetSportByName(string name)
        {
            var sport = await _sportService.GetSportByName(name);
            return sport is null ? NotFound() : Ok(sport);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSport([FromBody] SportRequestDto dto)
        {
            var created = await _sportService.CreateSport(dto);
            return CreatedAtAction(nameof(GetSportById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSport(Guid id, [FromBody] UpdateSportDto dto)
        {
            var updated = await _sportService.UpdateSport(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSport(Guid id)
        {
            var deleted = await _sportService.DeleteSport(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}