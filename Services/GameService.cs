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
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetAllGamesByTeamId(Guid teamId)
        {
            var games = await _repo.GetAllGamesByTeamId(teamId);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetAllGamesBySportId(Guid sportId)
        {
            var games = await _repo.GetAllGamesBySportId(sportId);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetAllGamesByLeagueId(Guid leagueId)
        {
            var games = await _repo.GetAllGamesByLeagueId(leagueId);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetAllGamesByLeagueIdAndDate(Guid leagueId, DateOnly date)
        {
            var games = await _repo.GetAllGamesByLeagueIdAndDate(leagueId, date);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetGamesByDateRange(DateOnly startDate, DateOnly endDate)
        {
            var games = await _repo.GetGamesByDateRange(startDate, endDate);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetGamesByTeamIdAndDate(Guid teamId, DateOnly date)
        {
            var games = await _repo.GetGamesByTeamIdAndDate(teamId, date);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetGamesByHomeTeam(Guid homeTeamId)
        {
            var games = await _repo.GetGamesByHomeTeam(homeTeamId);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetGamesByAwayTeam(Guid awayTeamId)
        {
            var games = await _repo.GetGamesByAwayTeam(awayTeamId);
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetUpcomingGames()
        {
            var games = await _repo.GetUpcomingGames();
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetCompletedGames()
        {
            var games = await _repo.GetCompletedGames();
            return await MapGameList(games);
        }

        public async Task<List<GameResponseDto>> GetGames(int pageNumber, int pageSize)
        {
            var games = await _repo.GetGames(pageNumber, pageSize);
            return await MapGameList(games);
        }

        public async Task<GameResponseDto?> GetGameById(Guid id)
        {
            var game = await _repo.GetGameById(id);
            if(game == null) return null;

            return await MapGameToResponseDto(game);
        }

        public async Task<GameResponseDto> CreateGame(GameRequestDto dto)
        {
            var homeTeam = await _teamRepo.GetTeamById(dto.HomeTeamId);
            var awayTeam = await _teamRepo.GetTeamById(dto.AwayTeamId);

            if(homeTeam.LeagueId != awayTeam.LeagueId)
                throw new InvalidOperationException("Home and away teams must be in the same league.");
                
            var game = GameMapper.MapToModel(dto);
            var createdGame = await _repo.CreateGame(game);

            return await MapGameToResponseDto(createdGame);

        }

        public async Task<GameResponseDto?> UpdateGame(Guid id, UpdateGameDto dto)
        {
            var game = await _repo.GetGameById(id);
            if (game == null) return null;

            GameMapper.MapToUpdatedModel(game, dto);

            var updated = await _repo.UpdateGame(game);
            
            return await MapGameToResponseDto(updated);
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _repo.GetGameById(id);
            if(game == null) return false;

            await _repo.DeleteGame(game);
            return true;
        }

        private async Task<GameResponseDto> MapGameToResponseDto(Game game)
        {
            var sport = await _sportRepo.GetSportById(game.SportId);
            var league = await _leagueRepo.GetLeagueById(game.LeagueId);
            var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);
            var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);

            Team? winnerTeam = null;
            if (game.WinnerTeamId.HasValue)
            {
                winnerTeam = await _teamRepo.GetTeamById(game.WinnerTeamId.Value);
            }

            return GameMapper.MapToDto(game, homeTeam!, awayTeam!, sport!, league!, winnerTeam);
        }

        private async Task<List<GameResponseDto>> MapGameList(List<Game> games)
        {
            var list = new List<GameResponseDto>();
            foreach (var game in games)
            {
                list.Add(await MapGameToResponseDto(game));
            }
            return list;
        }

    }
}