using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.League;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Services
{
    public class LeagueService
    {
        private readonly ILeagueRepository _repo;
        private readonly ISportRepository _sportRepo;
        public LeagueService(ILeagueRepository repo, ISportRepository sportRepo)
        {
            _repo = repo;
            _sportRepo = sportRepo;
        }

        public async Task<LeagueResponseDto?> GetLeagueById(Guid id)
        {
            var league = await _repo.GetLeagueById(id);
            if(league == null) return null;

            return await MapLeagueToResponseDto(league);
        }

        public async Task<LeagueResponseDto?> GetLeagueByName(string name)
        {
            var league = await _repo.GetLeagueByName(name);
            if(league == null) return null;

            return await MapLeagueToResponseDto(league);
        }

        public async Task<List<LeagueResponseDto>> GetAllLeagues()
        {
            var leagues = await _repo.GetAllLeagues();
            return await MapLeagueList(leagues);
        }

        public async Task<List<LeagueResponseDto>> GetLeaguesBySportId(Guid sportId)
        {
            var leagues = await _repo.GetLeaguesBySportId(sportId);
            return await MapLeagueList(leagues);
        }

        public async Task<LeagueResponseDto> CreateLeague(LeagueRequestDto dto)
        {
            var league = LeagueMapper.MapToModel(dto);
            var createdLeague = await _repo.CreateLeague(league);
            return await MapLeagueToResponseDto(createdLeague);
        }

        public async Task<LeagueResponseDto?> UpdateLeague(Guid id, UpdateLeagueDto dto)
        {
            var league = await _repo.GetLeagueById(id);
            if(league == null) return null;

            LeagueMapper.MapToUpdatedModel(league, dto);

            var updated = await _repo.UpdateLeague(league);
            return await MapLeagueToResponseDto(updated);
        }

        public async Task<bool> DeleteLeague(Guid id)
        {
            var league = await _repo.GetLeagueById(id);
            if (league == null) return false;
            await _repo.DeleteLeague(league);
            return true;
        }

        private async Task<LeagueResponseDto> MapLeagueToResponseDto(League league)
        {
            var sport = await _sportRepo.GetSportById(league.SportId);

            return LeagueMapper.MapToDto(league, sport!);
        }

        private async Task<List<LeagueResponseDto>> MapLeagueList(List<League> leagues)
        {
            var list = new List<LeagueResponseDto>();
            foreach(var league in leagues)
            {
                list.Add(await MapLeagueToResponseDto(league));
            }
            return list;
        }
    }
}