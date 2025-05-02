using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.League;
using scoreoracle_backend.Models;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly LeagueService _leagueService;
        public LeagueController(LeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeagues()
        {
            var leagues = await _leagueService.GetAllLeagues();
            return Ok(leagues);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeagueById(Guid id)
        {
            var league = await _leagueService.GetLeagueById(id);
            return league is null ? NotFound() : Ok(league);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetLeagueByName(string name)
        {
            var league = await _leagueService.GetLeagueByName(name);
            return league is null ? NotFound() : Ok(league);
        }

        [HttpGet("sport/{sportId}")]
        public async Task<IActionResult> GetLeaguesBySportId(Guid sportId)
        {
            var leagues = await _leagueService.GetLeaguesBySportId(sportId);
            return Ok(leagues);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeague([FromBody] LeagueRequestDto dto)
        {
            var created = await _leagueService.CreateLeague(dto);
            return CreatedAtAction(nameof(GetLeagueById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateLeague(Guid id, [FromBody] UpdateLeagueDto dto)
        {
            var updated = await _leagueService.UpdateLeague(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(Guid id)
        {
            var deleted = await _leagueService.DeleteLeague(id);
            return deleted ? NoContent() : NotFound();
        }


    }
}