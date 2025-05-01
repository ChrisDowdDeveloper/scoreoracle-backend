using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;

namespace scoreoracle_backend.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly Client _client;

        public GameRepository(Client client)
        {
            _client = client;
        }

        public async Task<Game?> GetGameById(Guid id)
        {
            var result = await _client
                .From<Game>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<Team?> GetTeamById(Guid id)
        {
            var result = await _client
                .From<Team>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<Sport?> GetSportById(Guid id)
        {
            var result = await _client
                .From<Sport>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<League?> GetLeagueById(Guid id)
        {
            var result = await _client
                .From<League>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();
            return result.Models.FirstOrDefault();
        }

        public Task<List<Team?>> GetGamesByTeamId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sport?>> GetGamesBySportId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<League?>> GetGamesByLeagueId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
