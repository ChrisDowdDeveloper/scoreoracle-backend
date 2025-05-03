using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;

namespace scoreoracle_backend.Repositories
{
    public class TeamRepository : ITeamRepository
    {

        private readonly Client _client;
        public TeamRepository(Client client)
        {
            _client = client;
        }
        public async Task<Team> CreateTeam(Team team)
        {
            var response = await _client.From<Team>().Insert(team);
            return response.Models.First();
        }

        public async Task<Team> DeleteTeam(Team team)
        {
            var response = await _client.From<Team>().Delete(team);
            return response.Models.First();
        }

        public async Task<List<Team>> GetAllTeams()
        {
            var result = await _client.From<Team>().Get();
            return result.Models;
        }

        public async Task<List<Team>> GetTeamsByCityName(string cityName)
        {
            var result = await _client.From<Team>().Where(t => t.CityName == cityName).Get();
            return result.Models;
        }

        public async Task<Team?> GetTeamById(Guid id)
        {
            var result = await _client
                .From<Team>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();

            return result.Models.FirstOrDefault();
        }

        public async Task<List<Team>> GetTeamByName(string name)
        {
            var result = await _client.From<Team>().Where(t => t.Name == name).Get();
            return result.Models;
        }

        public async Task<List<Team>> GetTeamsByLeagueId(Guid leagueId)
        {
            var result = await _client.From<Team>().Where(t => t.LeagueId == leagueId).Get();
            return result.Models;
        }

        public async Task<List<Team>> GetTeamsBySportId(Guid sportId)
        {
            var result = await _client.From<Team>().Where(t => t.SportId == sportId).Get();
            return result.Models;
        }

        public async Task<Team> UpdateTeam(Team team)
        {
            var result = await _client.From<Team>().Update(team);
            return result.Models.First();
        }

    }
}