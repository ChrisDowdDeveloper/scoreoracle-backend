using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Extensions;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;
using static Supabase.Postgrest.Constants;

namespace scoreoracle_backend.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {

        private readonly Client _client;
        public GroupMemberRepository(Client client)
        {
            _client = client;
        }
        
        public async Task<GroupMember> AddMember(GroupMember member)
        {
            var response = await _client.From<GroupMember>().Insert(member);
            return response.Models.First();
        }

        public async Task<List<GroupMember>> GetAdminsByGroupId(Guid groupId)
        {
            var response = await _client.From<GroupMember>().Where(m => m.Role == GroupRole.Admin).Get();
            return response.Models;
        }

        public async Task<GroupMember?> GetGroupMember(Guid userId, Guid groupId)
        {
            var response = await _client
                .From<GroupMember>()
                .Filter("user_id", Operator.Equals, userId.ToString())
                .Filter("group_id", Operator.Equals, groupId.ToString())
                .Get();

            return response.Models.FirstOrDefault();
        }

        public async Task<GroupMember?> GetGroupMemberById(Guid id)
        {
            var response = await _client.From<GroupMember>().Filter("id", Operator.Equals, id.ToString()).Get();
            return response.Models.FirstOrDefault();
        }

        public async Task<List<GroupMember>> GetMembersByGroupId(Guid groupId)
        {
            var response = await _client.From<GroupMember>().Filter("group_id", Operator.Equals, groupId.ToString()).Get();
            return response.Models;
        }

        public async Task<bool> IsUserGroupAdmin(Guid userId, Guid groupId)
        {
            var response = await _client
                .From<GroupMember>()
                .Filter("user_id", Operator.Equals, userId.ToString())
                .Filter("group_id", Operator.Equals, groupId.ToString())
                .Get();
            
            var member = response.Models.FirstOrDefault();
            return member != null && member.Role == GroupRole.Admin;
        }

        public async Task<bool> IsUserInGroup(Guid userId, Guid groupId)
        {
            var response = await _client
                .From<GroupMember>()
                .Filter("user_id", Operator.Equals, userId.ToString())
                .Filter("group_id", Operator.Equals, groupId.ToString())
                .Get();

            return response.Models.Count != 0;
        }

        public async Task<GroupMember> RemoveMember(GroupMember member)
        {
            var response = await _client.From<GroupMember>().Delete(member);
            return response.Models.First();
        }

        public async Task<bool> RemoveMemberByUserAndGroup(Guid userId, Guid groupId)
        {
            var response = await _client
                .From<GroupMember>()
                .Filter("user_id", Operator.Equals, userId.ToString())
                .Filter("group_id", Operator.Equals, groupId.ToString())
                .Get();

            var member = response.Models.FirstOrDefault();
            if (member is null)
                return false;

            var deleteResponse = await _client.From<GroupMember>().Delete(member);
            return deleteResponse.Models.Count > 0;
        }

        public async Task<GroupMember> UpdateGroupMember(GroupMember member)
        {
            var result = await _client.From<GroupMember>().Update(member);
            return result.Models.First();
        }
    }
}