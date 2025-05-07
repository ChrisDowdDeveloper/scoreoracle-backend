using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.GroupMember;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Mappers
{
    public class GroupMemberMapper
    {
        public static GroupMemberResponseDto MapToDto(GroupMember member, User user, Group group)
        {
            return new GroupMemberResponseDto
            {
                Id = member.Id,
                UserId = member.UserId,
                Username = user.Username,
                Role = member.Role,
                GroupId = member.GroupId,
                GroupName = group.Name
            };
        }

        public static GroupMember MapToModel(GroupMemberRequestDto dto)
        {
            return new GroupMember
            {
                UserId = dto.UserId,
                Role = dto.Role.ToUpper(),
                GroupId = dto.GroupId
            };
        }

        public static void MapToUpdatedModel(GroupMember member, UpdateGroupMemberDto dto)
        {
            if(member.Role != dto.Role)
                member.Role = dto.Role;
        }
    }
}