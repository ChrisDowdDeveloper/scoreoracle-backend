using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;

namespace scoreoracle_backend.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {

        private readonly Client _client;
        public LeagueRepository(Client client)
        {
            _client = client;
        }

        public async Task<League> CreateLeague(League league)
        {
            var response = await _client.From<League>().Insert(league);
            return response.Models.First();
        }

        public async Task<League> DeleteLeague(League league)
        {
            var response = await _client
                .From<League>()
                .Delete(league);
            return response.Models.First();
        }

        public async Task<List<League>> GetAllLeagues()
        {
            var result = await _client.From<League>().Get();
            return result.Models;
        }

        public async Task<League?> GetLeagueById(Guid id)
        {
            var result = await _client
                .From<League>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();
                
            return result.Models.FirstOrDefault();
        }

        public async Task<League?> GetLeagueByName(string name)
        {
            var result = await _client.From<League>().Where(l => l.Name == name).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<List<League>> GetLeaguesBySportId(Guid sportId)
        {
            var result = await _client
                .From<League>()
                .Filter("sport_id", Supabase.Postgrest.Constants.Operator.Equals, sportId.ToString())
                .Get();

            return result.Models;
        }

        public async Task<Sport?> GetSportById(Guid id)
        {
            var result = await _client
                .From<Sport>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<League> UpdateLeague(League league)
        {
            var result = await _client.From<League>().Update(league);
            return result.Models.First();
        }
    }
}