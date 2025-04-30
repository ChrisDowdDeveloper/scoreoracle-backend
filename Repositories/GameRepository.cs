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
            return await _client.From<Game>().Where(g => g.Id == id).Single();
        }

        public async Task<Team?> GetTeamById(Guid id)
        {
            return await _client.From<Team>().Where(t => t.Id == id).Single();
        }

        public async Task<Sport?> GetSportById(Guid id)
        {
            return await _client.From<Sport>().Where(s => s.Id == id).Single();;
        }

        public async Task<League?> GetLeagueById(Guid id)
        {
            return await _client.From<League>().Where(l => l.Id == id).Single();
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
