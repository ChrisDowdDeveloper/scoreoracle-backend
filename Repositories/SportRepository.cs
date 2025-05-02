using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;

namespace scoreoracle_backend.Repositories
{
    public class SportRepository : ISportRepository
    {

        private readonly Client _client;
        public SportRepository(Client client)
        {
            _client = client;
        }
        public async Task<Sport> CreateSport(Sport sport)
        {
            var response = await _client.From<Sport>().Insert(sport);
            return response.Models.First();
        }

        public async Task<Sport> DeleteSport(Sport sport)
        {
            var response = await _client.From<Sport>().Delete(sport);
            return response.Models.First();
        }

        public async Task<List<Sport>> GetAllSports()
        {
            var result = await _client.From<Sport>().Get();
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

        public async Task<Sport?> GetSportByName(string name)
        {
            var result = await _client.From<Sport>().Where(s => s.Name == name).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<Sport> UpdateSport(Sport sport)
        {
            var result = await _client.From<Sport>().Update(sport);
            return result.Models.First();
        }
    }
}