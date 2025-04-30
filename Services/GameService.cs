using scoreoracle_backend.DTOs.Game;
using scoreoracle_backend.Models;
using scoreoracle_backend.Repositories;
using scoreoracle_backend.Mappers;
using scoreoracle_backend.Interfaces;

namespace scoreoracle_backend.Services
{
    public class GameService
    {
        private readonly IGameRepository _repo;

        public GameService(IGameRepository repo)
        {
            _repo = repo;
        }

        public async Task<GameResponseDto?> GetGameResponseDtoById(Guid id)
        {
            var game = await _repo.GetGameById(id);
            if (game == null) return null;

            var home = await _repo.GetTeamById(game.HomeTeamId);
            var away = await _repo.GetTeamById(game.AwayTeamId);
            var sport = await _repo.GetSportById(game.SportId);
            var league = await _repo.GetLeagueById(game.LeagueId);

            Team? winner = null;
            if (game.IsCompleted && game.WinnerTeamId != Guid.Empty)
                winner = await _repo.GetTeamById(game.WinnerTeamId);

            return GameMapper.MapToDto(game, home!, away!, sport!, league!, winner);
        }
    }
}