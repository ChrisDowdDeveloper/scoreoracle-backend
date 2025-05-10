using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.Group;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Services
{
    public class GroupService
    {
        private readonly IUserRepository _userRepo;
        private readonly IGroupRepository _repo;
        private readonly ILeagueRepository _leagueRepo;
        public GroupService(IGroupRepository repo, IUserRepository userRepo, ILeagueRepository leagueRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
            _leagueRepo = leagueRepo;
        }

        public async Task<GroupResponseDto?> GetGroupById(Guid id)
        {
            var group = await _repo.GetGroupById(id);
            if(group == null) return null;

            return await MapGroupToResponseDto(group);
        }

        public async Task<List<GroupResponseDto>> GetAllGroups(int pageNumber, int pageSize) 
        {
            var groups = await _repo.GetAllGroups(pageNumber, pageSize);
            return await MapGroupList(groups);
        }

        public async Task<List<GroupResponseDto>> GetPublicGroups()
        {
            var groups = await _repo.GetPublicGroups();
            return await MapGroupList(groups);
        }

        public async Task<List<GroupResponseDto>> GetGroupsCreatedByUser(Guid userId)
        {
            var groups = await _repo.GetGroupsCreatedByUser(userId);
            return await MapGroupList(groups);
        }

        public async Task<List<GroupResponseDto>> SearchGroupsByName(string keyword)
        {
            var groups = await _repo.SearchGroupsByName(keyword);
            return await MapGroupList(groups);
        }

        public async Task<GroupResponseDto> CreateGroup(GroupRequestDto dto)
        {
            var group = GroupMapper.MapToModel(dto);
            var createdGroup = await _repo.CreateGroup(group);

            return await MapGroupToResponseDto(createdGroup);
        }

        public async Task<GroupResponseDto?> UpdateGroup(Guid id, UpdateGroupDto dto, Guid userId)
        {
            var group = await _repo.GetGroupById(id);
            if(group == null) return null;

            if(userId != group.CreatedByUserId)
                throw new UnauthorizedAccessException("Cannot update the group.");

            GroupMapper.MapToUpdatedModel(group, dto);

            var updated = await _repo.UpdateGroup(group);

            return await MapGroupToResponseDto(updated);
        }

        public async Task<bool> DeleteGroup(Guid id, Guid userId)
        {
            var group = await _repo.GetGroupById(id);
            if(group == null) return false;

            if(userId != group.CreatedByUserId)
                throw new UnauthorizedAccessException("Cannot update the group.");

            await _repo.DeleteGroup(group);
            return true;
        }

        private async Task<GroupResponseDto> MapGroupToResponseDto(Group group)
        {
            var user = await _userRepo.GetUserById(group.CreatedByUserId);
            var league = await _leagueRepo.GetLeagueById(group.LeagueId);

            return GroupMapper.MapToDto(group, user!, league!);
        }

        private async Task<List<GroupResponseDto>> MapGroupList(List<Group> groups)
        {
            var list = new List<GroupResponseDto>();
            foreach(var group in groups)
            {
                list.Add(await MapGroupToResponseDto(group));
            }
            return list;
        }
    }
}