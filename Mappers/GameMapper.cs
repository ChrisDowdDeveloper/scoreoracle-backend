using scoreoracle_backend.DTOs.Game;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Mappers
{
    public static class GameMapper
    {
        public static GameResponseDto MapToDto(
            Game game,
            Team home,
            Team away,
            Sport sport,
            League league,
            Team? winner = null)
        {
            return new GameResponseDto
            {
                Id = game.Id,
                SportId = game.SportId,
                SportName = sport.Name,
                LeagueId = game.Id,
                LeagueName = league.Name,
                HomeTeamId = home.Id,
                HomeTeamName = home.Name,
                HomeTeamLogoUrl = home.LogoUrl,
                AwayTeamId = away.Id,
                AwayTeamName = away.Name,
                AwayTeamLogoUrl = away.LogoUrl,
                WinnerTeamId = winner?.Id,
                WinnerTeamName = winner?.Name,
                WinnerTeamLogoUrl = winner?.LogoUrl,
                GameDate = game.GameDate,
                IsCompleted = game.IsCompleted,
                ScoreHome = game.ScoreHome,
                ScoreAway = game.ScoreAway
            };
        }

        public static Game MapToModel(GameRequestDto dto)
        {
            return new Game
            {
                SportId = dto.SportId,
                LeagueId = dto.LeagueId,
                HomeTeamId = dto.HomeTeamId,
                AwayTeamId = dto.AwayTeamId,
                GameDate = dto.GameDate,
                IsCompleted = dto.IsCompleted,
                WinnerTeamId = dto.WinnerTeamId,
                ScoreHome = dto.ScoreHome ?? 0,
                ScoreAway = dto.ScoreAway ?? 0
            };
        }

        public static void MapToUpdatedModel(Game game, UpdateGameDto dto)
        {
            if(dto.GameDate.HasValue)
                game.GameDate = dto.GameDate.Value;

            if(dto.IsCompleted.HasValue)
                game.IsCompleted = dto.IsCompleted.Value;

            if (dto.WinnerTeamId.HasValue)
                game.WinnerTeamId = dto.WinnerTeamId.Value;

            if (dto.ScoreHome.HasValue)
                game.ScoreHome = dto.ScoreHome.Value;

            if (dto.ScoreAway.HasValue)
                game.ScoreAway = dto.ScoreAway.Value;

        }
    }
}
