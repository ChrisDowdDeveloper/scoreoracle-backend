using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.League;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Mappers
{
    public class LeagueMapper
    {
        public static LeagueResponseDto MapToDto(League league, Sport sport)
        {
            return new LeagueResponseDto
            {
                Id = league.Id,
                SportId = league.SportId,
                SportName = sport.Name,
                Name = league.Name,
                LogoUrl = league.LogoUrl,
                Abbreviation = league.Abbreviation
            };
        }

        public static League MapToModel(LeagueRequestDto dto)
        {
            return new League
            {
                SportId = dto.SportId,
                Name = dto.Name,
                LogoUrl = dto.LogoUrl,
                Abbreviation = dto.Abbreviation
            };
        }

        public static void MapToUpdatedModel(League league, UpdateLeagueDto dto)
        {
            if(dto.SportId.HasValue)
                league.SportId = dto.SportId.Value;
            
            if(!string.IsNullOrWhiteSpace(dto.Name))
                league.Name = dto.Name;
            
            if(!string.IsNullOrWhiteSpace(dto.LogoUrl))
                league.LogoUrl = dto.LogoUrl;

            if(!string.IsNullOrWhiteSpace(dto.Abbreviation))
                league.Abbreviation = dto.Abbreviation;
        }
    }
}