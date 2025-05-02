using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.Sport;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;

namespace scoreoracle_backend.Services
{
    public class SportService
    {
        private readonly ISportRepository _repo;
        public SportService(ISportRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SportResponseDto>> GetAllSports()
        {
            var sports = await _repo.GetAllSports();
            var results = new List<SportResponseDto>();

            foreach (var sport in sports)
            {
                results.Add(SportMapper.MapToDto(sport));
            }

            return results;
        }

        public async Task<SportResponseDto?> GetSportById(Guid id)
        {
            var sport = await _repo.GetSportById(id);
            if(sport == null) return null;

            return SportMapper.MapToDto(sport);
        }

        public async Task<SportResponseDto?> GetSportByName(string name)
        {
            var sport = await _repo.GetSportByName(name);
            if(sport == null) return null;

            return SportMapper.MapToDto(sport);
        }

        public async Task<SportResponseDto> CreateSport(SportRequestDto dto)
        {
            var sport = SportMapper.MapToModel(dto);
            var createdSport = await _repo.CreateSport(sport);
            return SportMapper.MapToDto(createdSport);
        }

        public async Task<SportResponseDto?> UpdateSport(Guid id, UpdateSportDto dto)
        {
            var sport = await _repo.GetSportById(id);
            if(sport == null) return null;

            SportMapper.MapToUpdatedModel(sport, dto);

            var updated = await _repo.UpdateSport(sport);
            return SportMapper.MapToDto(updated);
        }

        public async Task<bool> DeleteSport(Guid id)
        {
            var sport = await _repo.GetSportById(id);
            if(sport == null) return false;
            await _repo.DeleteSport(sport);
            return true;
        }

    }
}