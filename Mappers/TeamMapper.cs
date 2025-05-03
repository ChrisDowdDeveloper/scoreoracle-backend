using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.Team;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Mappers
{
    public class TeamMapper
    {
        public static TeamResponseDto MapToDto(Team team, League league, Sport sport)
        {
            return new TeamResponseDto
            {
                Id = team.Id,
                Name = team.Name,
                CityName = team.CityName,
                SportId = team.SportId,
                SportName = sport.Name,
                LeagueId = team.LeagueId,
                LeagueName = league.Name,
                LogoUrl = team.LogoUrl,
                Abbreviation = team.Abbreviation
            };
        }

        public static Team MapToModel(TeamRequestDto dto)
        {
            return new Team
            {
                Name = dto.Name,
                CityName = dto.CityName,
                SportId = dto.SportId,
                LeagueId = dto.LeagueId,
                LogoUrl = dto.LogoUrl,
                Abbreviation = dto.Abbreviation
            };
        }

        public static void MapToUpdatedModel(Team team, UpdateTeamDto dto)
        {
            if(!string.IsNullOrWhiteSpace(dto.Name))
                team.Name = dto.Name;

            if(!string.IsNullOrWhiteSpace(dto.CityName))
                team.CityName = dto.CityName;

            if(dto.SportId.HasValue)
                team.SportId = dto.SportId.Value;
            
            if(dto.LeagueId.HasValue)
                team.LeagueId = dto.LeagueId.Value;
            
            if(!string.IsNullOrWhiteSpace(dto.LogoUrl))
                team.LogoUrl = dto.LogoUrl;
            
            if(!string.IsNullOrWhiteSpace(dto.Abbreviation))
                team.Abbreviation = dto.Abbreviation;
        }
    }
}