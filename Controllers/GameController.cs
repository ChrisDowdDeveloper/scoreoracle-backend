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

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponseDto>> GetGame(Guid id)
        {
            var result = await _gameService.GetGameResponseDtoById(id);
            if(result == null)
                return NotFound();

            return Ok(result);
        }
    }
}