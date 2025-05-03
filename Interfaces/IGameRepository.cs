using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllGames();
        Task<List<Game>> GetAllGamesByTeamId(Guid teamId);
        Task<List<Game>> GetAllGamesBySportId(Guid sportId);
        Task<List<Game>> GetAllGamesByLeagueId(Guid leagueId);
        Task<List<Game>> GetAllGamesByLeagueIdAndDate(Guid leagueId, DateOnly date);
        Task<List<Game>> GetGamesByDateRange(DateOnly startDate, DateOnly endDate);
        Task<List<Game>> GetGamesByTeamIdAndDate(Guid teamId, DateOnly date);
        Task<List<Game>> GetGamesByHomeTeam(Guid homeTeamId);
        Task<List<Game>> GetGamesByAwayTeam(Guid awayTeamId);
        Task<List<Game>> GetUpcomingGames();
        Task<List<Game>> GetCompletedGames();
        Task<List<Game>> GetGames(int pageNumber, int pageSize);
        Task<Game?> GetGameById(Guid id);
        Task<Game> CreateGame(Game game);
        Task<Game> UpdateGame(Game game);
        Task<Game> DeleteGame(Game game);
    }
}