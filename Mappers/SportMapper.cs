using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.Sport;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Mappers
{
    public class SportMapper
    {
        public static SportResponseDto MapToDto(Sport sport)
        {
            return new SportResponseDto
            {
                Id = sport.Id,
                Name = sport.Name,
                LogoUrl = sport.LogoUrl
            };
        }

        public static Sport MapToModel(SportRequestDto dto)
        {
            return new Sport
            {
                Name = dto.Name,
                LogoUrl = dto.LogoUrl
            };
        }

        public static void MapToUpdatedModel(Sport sport, UpdateSportDto dto)
        {
            if(!string.IsNullOrWhiteSpace(dto.Name))
                sport.Name = dto.Name;
            
            if(!string.IsNullOrWhiteSpace(dto.LogoUrl))
                sport.LogoUrl = dto.LogoUrl;
        }
    }
}