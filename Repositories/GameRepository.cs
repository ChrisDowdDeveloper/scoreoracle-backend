using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;
using Supabase.Postgrest;
using Supabase.Postgrest.Interfaces;
using static Supabase.Postgrest.Constants;

namespace scoreoracle_backend.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly Supabase.Client _client;

        public GameRepository(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<Game> CreateGame(Game game)
        {
            var response = await _client.From<Game>().Insert(game);
            return response.Models.First();
        }

        public async Task<Game> DeleteGame(Game game)
        {
            var response = await _client.From<Game>().Delete(game);
            return response.Models.First();
        }

        public async Task<List<Game>> GetAllGames()
        {
            var result = await _client.From<Game>().Get();
            return result.Models;
        }

        public async Task<List<Game>> GetAllGamesByLeagueId(Guid leagueId)
        {
            var result = await _client.From<Game>().Where(g => g.LeagueId == leagueId).Get();
            return result.Models;
        }

        public async Task<List<Game>> GetAllGamesPlayedOnDate(DateOnly date)
        {
            var start = date.ToDateTime(TimeOnly.MinValue);
            var end = date.AddDays(1).ToDateTime(TimeOnly.MinValue);

            var result = await _client
                .From<Game>()
                .Filter("game_date", Operator.GreaterThanOrEqual, start.ToString("o"))
                .Filter("game_date", Operator.LessThan, end.ToString("o"))
                .Get();

            return result.Models;
        }

        public async Task<List<Game>> GetAllGamesBySportId(Guid sportId)
        {
            var result = await _client.From<Game>().Filter("sport_id", Operator.Equals, sportId.ToString()).Get();
            return result.Models;
        }

        public async Task<List<Game>> GetAllGamesByTeamId(Guid teamId)
        {
            var homeResponse = await _client
                .From<Game>()
                .Filter("home_team_id", Operator.Equals, teamId.ToString())
                .Get();

            var awayResponse = await _client
                .From<Game>()
                .Filter("away_team_id", Operator.Equals, teamId.ToString())
                .Get();

            return homeResponse.Models
                .Concat(awayResponse.Models)
                .ToList();
        }
        public async Task<List<Game>> GetCompletedGames()
        {
            var result = await _client.From<Game>().Where(g => g.IsCompleted == true).Get();
            return result.Models;
        }

        public async Task<Game?> GetGameById(Guid id)
        {
            var result = await _client.From<Game>().Filter("id", Operator.Equals, id.ToString()).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<List<Game>> GetGames(int pageNumber, int pageSize)
        {
            int from = (pageNumber - 1) * pageSize;
            int to = from + pageSize - 1;

            var result = await _client
                .From<Game>()
                .Range(from, to)
                .Order(x => x.GameDate, Ordering.Descending)
                .Get();

            return result.Models;
        }

        public async Task<List<Game>> GetGamesByAwayTeam(Guid awayTeamId)
        {
            var result = await _client.From<Game>().Filter("away_team_id", Operator.Equals, awayTeamId.ToString()).Get();
            return result.Models;
        }

        public async Task<List<Game>> GetGamesByDateRange(DateOnly startDate, DateOnly endDate)
        {
            var start = startDate.ToDateTime(TimeOnly.MinValue);
            var end = endDate.AddDays(1).ToDateTime(TimeOnly.MinValue);

            var result = await _client
                .From<Game>()
                .Filter("game_date", Operator.GreaterThanOrEqual, start.ToString("o"))
                .Filter("game_date", Operator.LessThan, end.ToString("o"))
                .Get();

            return result.Models;
        }

        public async Task<List<Game>> GetGamesByHomeTeam(Guid homeTeamId)
        {
            var result = await _client.From<Game>().Filter("home_team_id", Operator.Equals, homeTeamId.ToString()).Get();
            return result.Models;
        }

        public async Task<List<Game>> GetGamesByTeamIdAndDate(Guid teamId, DateOnly date)
        {
            var start = date.ToDateTime(TimeOnly.MinValue);
            var end = date.AddDays(1).ToDateTime(TimeOnly.MinValue);

            var filters = new List<IPostgrestQueryFilter>
            {
                new QueryFilter("home_team_id", Operator.Equals, teamId.ToString()),
                new QueryFilter("away_team_id", Operator.Equals, teamId.ToString())
            };

            var result = await _client
                .From<Game>()
                .Or(filters)
                .Filter("game_date", Operator.GreaterThanOrEqual, start.ToString("o"))
                .Filter("game_date", Operator.LessThan, end.ToString("o"))
                .Get();

            return result.Models;
        }

        public async Task<List<Game>> GetUpcomingGames()
        {
            var currentDateTime = DateTime.UtcNow;
            var result = await _client.From<Game>().Where(g => g.GameDate > currentDateTime).Get();
            return result.Models;
        }

        public async Task<Game> UpdateGame(Game game)
        {
            var result = await _client.From<Game>().Update(game);
            return result.Models.First();
        }

        public async Task<List<Game>> GetAllGamesByLeagueIdAndDate(Guid leagueId, DateOnly date)
        {
            var start = date.ToDateTime(TimeOnly.MinValue);
            var end = date.AddDays(1).ToDateTime(TimeOnly.MinValue);

            var result = await _client
                .From<Game>()
                .Filter("league_id", Operator.Equals, leagueId.ToString())
                .Filter("game_date", Operator.GreaterThanOrEqual, start.ToString("o"))
                .Filter("game_date", Operator.LessThan, end.ToString("o"))
                .Get();

            return result.Models;
        }
    }
}
