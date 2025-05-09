using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.Group;
using scoreoracle_backend.Models;
using Group = scoreoracle_backend.Models.Group;

namespace scoreoracle_backend.Mappers
{
    public class GroupMapper
    {
        public static GroupResponseDto MapToDto(Group group, User user, League league)
        {
            return new GroupResponseDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                IsPublic = group.IsPublic,
                CreatedByUserId = group.CreatedByUserId,
                CreatedByUserName = user.Username,
                LeagueId = group.LeagueId,
                LeagueName = league.Name,
                CreatedAt = group.CreatedAt
            };
        }

        public static Group MapToModel(GroupRequestDto dto)
        {
            return new Group
            {
                Name = dto.Name,
                Description = dto.Description ?? "",
                IsPublic = dto.IsPublic,
                CreatedByUserId = dto.CreatedByUserId,
                LeagueId = dto.LeagueId,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static void MapToUpdatedModel(Group group, UpdateGroupDto dto)
        {
            if(!string.IsNullOrEmpty(dto.Name))
                group.Name = dto.Name;

            if(!string.IsNullOrWhiteSpace(dto.Description))
                group.Description = dto.Description;
            
            if(dto.IsPublic.HasValue)
                group.IsPublic = dto.IsPublic.Value;
        }
    }
}