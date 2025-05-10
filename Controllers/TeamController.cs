using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.Team;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {

        private readonly TeamService _teamService;
        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams() 
        {
            var teams = await _teamService.GetAllTeams();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(Guid id)
        {
            var team = await _teamService.GetTeamById(id);
            return team is null ? NotFound() : Ok(team);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTeamsByName(string name)
        {
            var teams = await _teamService.GetTeamByName(name);
            return Ok(teams);
        }

        [HttpGet("city/{cityName}")]
        public async Task<IActionResult> GetTeamByCityName(string cityName)
        {
            var teams = await _teamService.GetTeamsByCityName(cityName);
            return Ok(teams);
        }

        [HttpGet("sport/{sportId}")]
        public async Task<IActionResult> GetTeamsBySportId(Guid sportId)
        {
            var teams = await _teamService.GetTeamsBySportId(sportId);
            return Ok(teams);
        }

        [HttpGet("league/{leagueId}")]
        public async Task<IActionResult> GetTeamsByLeagueId(Guid leagueId)
        {
            var teams = await _teamService.GetTeamsByLeagueId(leagueId);
            return Ok(teams);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] TeamRequestDto dto)
        {
            var created = await _teamService.CreateTeam(dto);
            return CreatedAtAction(nameof(GetTeamById), new { id = created.Id }, created);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTeam(Guid id, [FromBody] UpdateTeamDto dto)
        {
            var updated = await _teamService.UpdateTeam(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            var deleted = await _teamService.DeleteTeam(id);
            return deleted ? NoContent() : NotFound();
        }

    }
}