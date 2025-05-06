using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.Group;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;

namespace scoreoracle_backend.Services
{
    public class GroupService
    {
        private readonly IUserRepository _userRepo;
        private readonly IGroupRepository _repo;
        public GroupService(IGroupRepository repo, IUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }

        public async Task<GroupResponseDto?> GetGroupById(Guid id)
        {
            var group = await _repo.GetGroupById(id);
            if(group == null) return null;

            var user = await _userRepo.GetUserById(group.CreatedByUserId);

            return GroupMapper.MapToDto(group, user!);
        }

        public async Task<List<GroupResponseDto>> GetAllGroups(int pageNumber, int pageSize) 
        {
            var groups = await _repo.GetAllGroups(pageNumber, pageSize);
            var results = new List<GroupResponseDto>();

            foreach(var group in groups)
            {
                var user = await _userRepo.GetUserById(group.CreatedByUserId);
                results.Add(GroupMapper.MapToDto(group, user!));
            }

            return results;
        }

        public async Task<List<GroupResponseDto>> GetPublicGroups()
        {
            var groups = await _repo.GetPublicGroups();
            var results = new List<GroupResponseDto>();

            foreach(var group in groups)
            {
                var user = await _userRepo.GetUserById(group.CreatedByUserId);
                results.Add(GroupMapper.MapToDto(group, user!));
            }

            return results;
        }

        public async Task<List<GroupResponseDto>> GetGroupsCreatedByUser(Guid userId)
        {
            var groups = await _repo.GetGroupsCreatedByUser(userId);
            var results = new List<GroupResponseDto>();

            foreach(var group in groups)
            {
                var user = await _userRepo.GetUserById(userId);
                results.Add(GroupMapper.MapToDto(group, user!));
            }

            return results;
        }

        public async Task<List<GroupResponseDto>> SearchGroupsByName(string keyword)
        {
            var groups = await _repo.SearchGroupsByName(keyword);
            var results = new List<GroupResponseDto>();

            foreach(var group in groups)
            {
                var user = await _userRepo.GetUserById(group.CreatedByUserId);
                results.Add(GroupMapper.MapToDto(group, user!));
            }

            return results;
        }

        public async Task<GroupResponseDto> CreateGroup(GroupRequestDto dto)
        {
            var group = GroupMapper.MapToModel(dto);
            var createdGroup = await _repo.CreateGroup(group);

            var user = await _userRepo.GetUserById(group.CreatedByUserId);

            return GroupMapper.MapToDto(createdGroup, user!);
        }

        public async Task<GroupResponseDto?> UpdateGroup(Guid id, UpdateGroupDto dto)
        {
            var group = await _repo.GetGroupById(id);
            if(group == null) return null;

            GroupMapper.MapToUpdatedModel(group, dto);

            var updated = await _repo.UpdateGroup(group);
            var user = await _userRepo.GetUserById(group.CreatedByUserId);

            return GroupMapper.MapToDto(updated, user!);
        }

        public async Task<bool> DeleteGroup(Guid id)
        {
            var group = await _repo.GetGroupById(id);
            if(group == null) return false;

            await _repo.DeleteGroup(group);
            return true;
        }
    }
}