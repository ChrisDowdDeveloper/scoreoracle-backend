using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.GroupMember;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;
using scoreoracle_backend.Models;
using scoreoracle_backend.Repositories;

namespace scoreoracle_backend.Services
{
    public class GroupMemberService
    {

        private readonly IGroupMemberRepository _repo;
        private readonly IUserRepository _userRepo;
        private readonly IGroupRepository _groupRepo;

        public GroupMemberService(IGroupMemberRepository repo, IUserRepository userRepo, IGroupRepository groupRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
            _groupRepo = groupRepo;
        }

        public async Task<GroupMemberResponseDto> AddMember(GroupMemberRequestDto dto)
        {
            var member = GroupMemberMapper.MapToModel(dto);
            var createdMember = await _repo.AddMember(member);

            var user = await _userRepo.GetUserById(dto.UserId);
            var group = await _groupRepo.GetGroupById(dto.GroupId);

            return GroupMemberMapper.MapToDto(createdMember, user!, group!);
        }

        public async Task<GroupMemberResponseDto?> GetGroupMemberById(Guid id)
        {
            var member = await _repo.GetGroupMemberById(id);
            if(member == null) return null;

            var user = await _userRepo.GetUserById(member.UserId);
            var group = await _groupRepo.GetGroupById(member.GroupId);

            return GroupMemberMapper.MapToDto(member, user!, group!);
        }

        public async Task<GroupMemberResponseDto?> GetGroupMember(Guid userId, Guid groupId)
        {
            var member = await _repo.GetGroupMember(userId, groupId);
            if(member == null) return null;

            var user = await _userRepo.GetUserById(member.UserId);
            var group = await _groupRepo.GetGroupById(member.GroupId);

            return GroupMemberMapper.MapToDto(member, user!, group!);
        }

        public async Task<List<GroupMemberResponseDto>> GetMembersByGroupId(Guid groupId)
        {
            var members = await _repo.GetMembersByGroupId(groupId);
            var results = new List<GroupMemberResponseDto>();

            foreach(var member in members)
            {
                var user = await _userRepo.GetUserById(member.UserId);
                var group = await _groupRepo.GetGroupById(member.GroupId);

                results.Add(GroupMemberMapper.MapToDto(member, user!, group!));
            }

            return results;
        }

        public async Task<List<GroupMemberResponseDto>> GetAdminsByGroupId(Guid groupId)
        {
            var members = await _repo.GetAdminsByGroupId(groupId);
            var results = new List<GroupMemberResponseDto>();

            foreach(var member in members)
            {
                var user = await _userRepo.GetUserById(member.UserId);
                var group = await _groupRepo.GetGroupById(member.GroupId);

                results.Add(GroupMemberMapper.MapToDto(member, user!, group!));
            }

            return results;
        }

        public async Task<GroupMemberResponseDto?> UpdateGroupMember(Guid id, UpdateGroupMemberDto dto)
        {
            var member = await _repo.GetGroupMemberById(id);
            if(member == null) return null;

            GroupMemberMapper.MapToUpdatedModel(member, dto);

            var updated = await _repo.UpdateGroupMember(member);

            var user = await _userRepo.GetUserById(member.UserId);
            var group = await _groupRepo.GetGroupById(member.GroupId);

            return GroupMemberMapper.MapToDto(updated, user!, group!);
        }

        public async Task<bool> RemoveMember(Guid id)
        {
            var member = await _repo.GetGroupMemberById(id);
            if(member == null) return false;

            await _repo.RemoveMember(member);
            return true;
        }

        public async Task<bool> RemoveMemberByUserAndGroup(Guid userId, Guid groupId)
        {
            return await _repo.RemoveMemberByUserAndGroup(userId, groupId);
        }

        public async Task<bool> IsUserInGroup(Guid userId, Guid groupId)
        {
            return await _repo.IsUserInGroup(userId, groupId);
        }

        public async Task<bool> IsUserGroupAdmin(Guid userId, Guid groupId)
        {
            return await _repo.IsUserGroupAdmin(userId, groupId);
        }

    }
}