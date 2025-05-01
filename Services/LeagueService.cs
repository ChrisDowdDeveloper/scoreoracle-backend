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
        public LeagueService(ILeagueRepository repo)
        {
            _repo = repo;
        }

        public async Task<LeagueResponseDto?> GetLeagueById(Guid id)
        {
            var league = await _repo.GetLeagueById(id);
            if(league == null) return null;

            var sport = await _repo.GetSportById(league.SportId);

            return LeagueMapper.MapToDto(league, sport!);
        }

        public async Task<LeagueResponseDto?> GetLeagueByName(string name)
        {
            var league = await _repo.GetLeagueByName(name);
            if (league is null)
                return null;

            var sport = await _repo.GetSportById(league.SportId);

            return LeagueMapper.MapToDto(league, sport!);
        }

        public async Task<List<LeagueResponseDto>> GetAllLeagues()
        {
            var leagues = await _repo.GetAllLeagues();
            var results = new List<LeagueResponseDto>();

            foreach(var league in leagues)
            {
                var sport = await _repo.GetSportById(league.SportId);
                results.Add(LeagueMapper.MapToDto(league, sport!));
            }

            return results;
        }

        public async Task<List<LeagueResponseDto>> GetLeaguesBySportId(Guid sportId)
        {
            var leagues = await _repo.GetLeaguesBySportId(sportId);
            var sport = await _repo.GetSportById(sportId);
            
            if (sport == null) return new List<LeagueResponseDto>();

            return leagues.Select(league => LeagueMapper.MapToDto(league, sport)).ToList();
        }

        public async Task<LeagueResponseDto> CreateLeague(LeagueRequestDto dto)
        {
            var league = LeagueMapper.MapToModel(dto);
            var createdLeague = await _repo.CreateLeague(league);
            var sport = await _repo.GetSportById(createdLeague.SportId);
            return LeagueMapper.MapToDto(createdLeague, sport!);
        }

        public async Task<LeagueResponseDto?> UpdateLeague(Guid id, UpdateLeagueDto dto)
        {
            var league = await _repo.GetLeagueById(id);
            if(league == null) return null;

            LeagueMapper.MapToUpdatedModel(league, dto);

            var updated = await _repo.UpdateLeague(league);
            var sport = await _repo.GetSportById(updated.SportId);
            return LeagueMapper.MapToDto(updated, sport!);
        }

        public async Task<bool> DeleteLeague(Guid id)
        {
            var league = await _repo.GetLeagueById(id);
            if (league == null) return false;
            await _repo.DeleteLeague(league);
            return true;
        }
    }
}