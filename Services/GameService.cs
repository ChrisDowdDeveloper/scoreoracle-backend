using scoreoracle_backend.DTOs.Game;
using scoreoracle_backend.Models;
using scoreoracle_backend.Repositories;
using scoreoracle_backend.Mappers;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.DTOs.Team;

namespace scoreoracle_backend.Services
{
    public class GameService
    {
        private readonly IGameRepository _repo;
        private readonly ITeamRepository _teamRepo;
        private readonly ISportRepository _sportRepo;
        private readonly ILeagueRepository _leagueRepo;

        public GameService(IGameRepository repo, ITeamRepository teamRepo, ISportRepository sportRepo, ILeagueRepository leagueRepo)
        {
            _repo = repo;
            _teamRepo = teamRepo;
            _sportRepo = sportRepo;
            _leagueRepo = leagueRepo;
        }

        public async Task<List<GameResponseDto>> GetAllGames()
        {
            var games = await _repo.GetAllGames();
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetAllGamesByTeamId(Guid teamId)
        {
            var games = await _repo.GetAllGamesByTeamId(teamId);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetAllGamesBySportId(Guid sportId)
        {
            var games = await _repo.GetAllGamesBySportId(sportId);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetAllGamesByLeagueId(Guid leagueId)
        {
            var games = await _repo.GetAllGamesByLeagueId(leagueId);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetAllGamesByLeagueIdAndDate(Guid leagueId, DateOnly date)
        {
            var games = await _repo.GetAllGamesByLeagueIdAndDate(leagueId, date);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetGamesByDateRange(DateOnly startDate, DateOnly endDate)
        {
            var games = await _repo.GetGamesByDateRange(startDate, endDate);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetGamesByTeamIdAndDate(Guid teamId, DateOnly date)
        {
            var games = await _repo.GetGamesByTeamIdAndDate(teamId, date);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetGamesByHomeTeam(Guid homeTeamId)
        {
            var games = await _repo.GetGamesByHomeTeam(homeTeamId);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetGamesByAwayTeam(Guid awayTeamId)
        {
            var games = await _repo.GetGamesByAwayTeam(awayTeamId);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetUpcomingGames()
        {
            var games = await _repo.GetUpcomingGames();
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetCompletedGames()
        {
            var games = await _repo.GetCompletedGames();
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<List<GameResponseDto>> GetGames(int pageNumber, int pageSize)
        {
            var games = await _repo.GetGames(pageNumber, pageSize);
            var results = new List<GameResponseDto>();

            foreach(var game in games)
            {
                var sport = await _sportRepo.GetSportById(game.SportId);
                var league = await _leagueRepo.GetLeagueById(game.LeagueId);
                var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
                var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

                Team? winnerTeam = null;
                if (game.WinnerTeamId.HasValue)
                {
                    winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
                }

                results.Add(GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam!));
            }

            return results;
        }

        public async Task<GameResponseDto?> GetGameById(Guid id)
        {
            var game = await _repo.GetGameById(id);
            if(game == null) return null;

            var sport = await _sportRepo.GetSportById(game.SportId);
            var league = await _leagueRepo.GetLeagueById(game.LeagueId);
            var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
            var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

            Team? winnerTeam = null;
            if (game.WinnerTeamId.HasValue)
            {
                winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
            }

            return GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam);
        }

        public async Task<GameResponseDto> CreateGame(GameRequestDto dto)
        {
            var game = GameMapper.MapToModel(dto);
            var createdGame = await _repo.CreateGame(game);

            var sport = await _sportRepo.GetSportById(game.SportId);
            var league = await _leagueRepo.GetLeagueById(game.LeagueId);
            var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
            var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);

            Team? winnerTeam = null;
            if (game.WinnerTeamId.HasValue)
            {
                winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
            }

            return GameMapper.MapToDto(createdGame, homeTeam!, awayTeam!, sport!, league!, winnerTeam);

        }

        public async Task<GameResponseDto?> UpdateGame(Guid id, UpdateGameDto dto)
        {
            var game = await _repo.GetGameById(id);
            if (game == null) return null;

            GameMapper.MapToUpdatedModel(game, dto);

            var updated = await _repo.UpdateGame(game);
            
            var sport = await _sportRepo.GetSportById(updated.SportId);
            var league = await _leagueRepo.GetLeagueById(updated.LeagueId);
            var awayTeam = await _teamRepo.GetTeamById(updated.AwayTeamId);
            var homeTeam = await _teamRepo.GetTeamById(updated.HomeTeamId);

            Team? winnerTeam = null;
            if (game.WinnerTeamId.HasValue)
            {
                winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
            }

            return GameMapper.MapToDto(updated, homeTeam!, awayTeam!, sport!, league!, winnerTeam);
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _repo.GetGameById(id);
            if(game == null) return false;

            await _repo.DeleteGame(game);
            return true;
        }

    }
}