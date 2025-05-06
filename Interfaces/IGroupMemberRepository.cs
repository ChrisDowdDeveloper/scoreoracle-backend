using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface IGroupMemberRepository
    {
        Task<GroupMember> AddMember(GroupMember member);
        Task<GroupMember?> GetGroupMemberById(Guid id);
        Task<GroupMember?> GetGroupMember(Guid userId, Guid groupId);
        Task<List<GroupMember>> GetMembersByGroupId(Guid groupId);
        Task<List<GroupMember>> GetAdminsByGroupId(Guid groupId);
        Task<GroupMember> UpdateGroupMember(GroupMember member);
        Task<GroupMember> RemoveMember(GroupMember member);
        Task<bool> RemoveMemberByUserAndGroup(Guid userId, Guid groupId);
        Task<bool> IsUserInGroup(Guid userId, Guid groupId);
        Task<bool> IsUserGroupAdmin(Guid userId, Guid groupId);
    }
}