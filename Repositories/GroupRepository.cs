using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;
using static Supabase.Postgrest.Constants;

namespace scoreoracle_backend.Repositories
{
    public class GroupRepository : IGroupRepository
    {

        private readonly Client _client;
        public GroupRepository(Client client)
        {
            _client = client;
        }

        public async Task<Group> CreateGroup(Group group)
        {
            var response = await _client.From<Group>().Insert(group);
            return response.Models.First();
        }

        public async Task<Group> DeleteGroup(Group group)
        {
            var response = await _client.From<Group>().Delete(group);
            return response.Models.First();
        }

        public async Task<List<Group>> GetAllGroups(int pageNumber, int pageSize)
        {
            int from = (pageNumber - 1) * pageSize;
            int to = from + pageSize - 1;

            var result = await _client.From<Group>().Range(from, to).Order(x => x.Name, Ordering.Descending).Get();
            return result.Models;
        }

        public async Task<Group?> GetGroupById(Guid id)
        {
            var result = await _client
                .From<Group>()
                .Filter("id", Operator.Equals, id.ToString())
                .Get();
            
            return result.Models.FirstOrDefault();
        }

        public async Task<List<Group>> GetGroupsCreatedByUser(Guid userId)
        {
            var result = await _client.From<Group>().Where(g => g.CreatedByUserId == userId).Get();
            return result.Models;
        }

        public async Task<List<Group>> GetPublicGroups()
        {
            var result = await _client.From<Group>().Where(g => g.IsPublic == true).Get();
            return result.Models;
        }

        public async Task<List<Group>> SearchGroupsByName(string keyword)
        {
            var result = await _client.From<Group>().Filter("name", Supabase.Postgrest.Constants.Operator.Like, $"%{keyword}%").Get();
            return result.Models;
        }

        public async Task<Group> UpdateGroup(Group group)
        {
            var result = await _client.From<Group>().Update(group);
            return result.Models.First();
        }
    }
}