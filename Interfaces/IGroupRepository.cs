using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group?> GetGroupById(Guid id);
        Task<List<Group>> GetAllGroups(int pageNumber, int pageSize);
        Task<List<Group>> GetPublicGroups();
        Task<List<Group>> GetGroupsCreatedByUser(Guid userId);
        Task<List<Group>> SearchGroupsByName(string keyword);
        Task<Group> CreateGroup(Group group);
        Task<Group> UpdateGroup(Group group);
        Task<Group> DeleteGroup(Group group);
    }
}