using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using static Supabase.Postgrest.Constants;

namespace scoreoracle_backend.Repositories
{
    public class PickRepository : IPickRepository
    {

        private readonly Supabase.Client _client;
        public PickRepository(Supabase.Client client)
        {
            _client = client;
        }
        public async Task<Pick> CreatePick(Pick pick)
        {
            var response = await _client.From<Pick>().Insert(pick);
            return response.Models.First();
        }

        public async Task<Pick> DeletePick(Pick pick)
        {
            var response = await _client.From<Pick>().Delete(pick);
            return response.Models.First();
        }

        public async Task<List<Pick>> GetAllPicks()
        {
            var result = await _client.From<Pick>().Get();
            return result.Models;
        }

        public async Task<Pick?> GetPickById(Guid id)
        {
            var result = await _client.From<Pick>().Filter("id", Operator.Equals, id.ToString()).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<Pick?> GetPickByUserAndGame(Guid userId, Guid gameId)
        {
            var response = await _client.From<Pick>()
                .Filter("user_id", Operator.Equals, userId.ToString())
                .Filter("game_id", Operator.Equals, gameId.ToString())
                .Get();
            return response.Models.FirstOrDefault();
        }

        public async Task<List<Pick>> GetPicksByGroupId(Guid groupId)
        {
            var response = await _client.From<Pick>()
                .Filter("group_id", Operator.Equals, groupId.ToString())
                .Get();
            return response.Models;
        }

        public async Task<List<Pick>> GetPicksByUserAndGroup(Guid userId, Guid groupId)
        {
            var response = await _client.From<Pick>()
                .Filter("user_id", Operator.Equals, userId.ToString())
                .Filter("group_id", Operator.Equals, groupId.ToString())
                .Get();
            return response.Models;
        }

        public async Task<List<Pick>> GetPicksByUserId(Guid userId)
        {
            var response = await _client.From<Pick>()
                .Filter("user_id", Operator.Equals, userId.ToString())
                .Get();
            return response.Models;
        }

        public async Task<Pick> UpdatePick(Pick pick)
        {
            var result = await _client.From<Pick>().Update(pick);
            return result.Models.First();
        }
    }
}