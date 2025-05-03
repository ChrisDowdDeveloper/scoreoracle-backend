using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scoreoracle_backend.DTOs.Game;
using scoreoracle_backend.Services;

namespace scoreoracle_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGames();
            return Ok(games);
        }

        [HttpGet("team/{teamId}")]
        public async Task<IActionResult> GetAllGamesByTeamId(Guid teamId)
        {
            var games = await _gameService.GetAllGamesByTeamId(teamId);
            return Ok(games);
        }

        [HttpGet("sport/{sportId}")]
        public async Task<IActionResult> GetAllGamesBySportId(Guid sportId)
        {
            var games = await _gameService.GetAllGamesBySportId(sportId);
            return Ok(games);
        }

        [HttpGet("league/{leagueId}")]
        public async Task<IActionResult> GetAllGamesByLeagueId(Guid leagueId)
        {
            var games = await _gameService.GetAllGamesByLeagueId(leagueId);
            return Ok(games);
        }

        [HttpGet("league/{leagueId}/date")]
        public async Task<IActionResult> GetAllGamesByLeagueIdAndDate(Guid leagueId, [FromQuery] DateOnly date)
        {
            var games = await _gameService.GetAllGamesByLeagueIdAndDate(leagueId, date);
            return Ok(games);
        }

        [HttpGet("range")]
        public async Task<IActionResult> GetGamesByDateRange([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
        {
            var games = await _gameService.GetGamesByDateRange(startDate, endDate);
            return Ok(games);
        }

        [HttpGet("team/{teamId}/date")]
        public async Task<IActionResult> GetGamesByTeamIdAndDate(Guid teamId, DateOnly date)
        {
            var games = await _gameService.GetGamesByTeamIdAndDate(teamId, date);
            return Ok(games);
        }

        [HttpGet("team/home/{homeTeamId}")]
        public async Task<IActionResult> GetGamesByHomeTeam(Guid homeTeamId)
        {
            var games = await _gameService.GetGamesByHomeTeam(homeTeamId);
            return Ok(games);
        }

        [HttpGet("team/away/{awayTeamId}")]
        public async Task<IActionResult> GetGamesByAwayTeam(Guid awayTeamId)
        {
            var games = await _gameService.GetGamesByAwayTeam(awayTeamId);
            return Ok(games);
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingGames()
        {
            var games = await _gameService.GetUpcomingGames();
            return Ok(games);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedGames()
        {
            var games = await _gameService.GetCompletedGames();
            return Ok(games);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetGamesPaged([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var games = await _gameService.GetGames(pageNumber, pageSize);
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(Guid id)
        {
            var game = await _gameService.GetGameById(id);
            return game is null ? NotFound() : Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameRequestDto dto)
        {
            var created = await _gameService.CreateGame(dto);
            return CreatedAtAction(nameof(GetGameById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGame(Guid id, [FromBody] UpdateGameDto dto)
        {
            var updated = await _gameService.UpdateGame(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var deleted = await _gameService.DeleteGame(id);
            return deleted ? NoContent() : NotFound();
        }

    }
}