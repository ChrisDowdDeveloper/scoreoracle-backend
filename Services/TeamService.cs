using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using scoreoracle_backend.DTOs.Team;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Services
{
    public class TeamService
    {
        private readonly ITeamRepository _repo;
        private readonly ILeagueRepository _leagueRepo;
        private readonly ISportRepository _sportRepo;
        public TeamService(ITeamRepository repo, ILeagueRepository leagueRepo, ISportRepository sportRepo)
        {
            _repo = repo;
            _leagueRepo = leagueRepo;
            _sportRepo = sportRepo;
        }

        public async Task<List<TeamResponseDto>> GetAllTeams()
        {
            var teams = await _repo.GetAllTeams();
            return await MapTeamList(teams);
        }

        public async Task<TeamResponseDto?> GetTeamById(Guid id)
        {
            var team = await _repo.GetTeamById(id);
            if(team == null) return null;

            return await MapTeamToResponseDto(team);
        }

        public async Task<List<TeamResponseDto>> GetTeamByName(string name)
        {
            var teams = await _repo.GetTeamByName(name);
            return await MapTeamList(teams);
        }

        public async Task<List<TeamResponseDto>> GetTeamsByCityName(string cityName)
        {
            var teams = await _repo.GetTeamsByCityName(cityName);
            return await MapTeamList(teams);
        }

        public async Task<List<TeamResponseDto>> GetTeamsBySportId(Guid sportId)
        {
            var teams = await _repo.GetTeamsBySportId(sportId);
            return await MapTeamList(teams);
        }

        public async Task<List<TeamResponseDto>> GetTeamsByLeagueId(Guid leagueId)
        {
            var teams = await _repo.GetTeamsByLeagueId(leagueId);
            return await MapTeamList(teams);
        }

        public async Task<TeamResponseDto> CreateTeam(TeamRequestDto dto)
        {
            var team = TeamMapper.MapToModel(dto);
            var createdTeam = await _repo.CreateTeam(team);
            return await MapTeamToResponseDto(createdTeam);
        }

        public async Task<TeamResponseDto?> UpdateTeam(Guid id, UpdateTeamDto dto)
        {
            var team = await _repo.GetTeamById(id);
            if(team == null) return null;

            TeamMapper.MapToUpdatedModel(team, dto);
            
            var updated = await _repo.UpdateTeam(team);

            return await MapTeamToResponseDto(updated);
        }

        public async Task<bool> DeleteTeam(Guid id)
        {
            var team = await _repo.GetTeamById(id);
            if(team == null) return false;

            await _repo.DeleteTeam(team);
            return true;
        }

        private async Task<TeamResponseDto> MapTeamToResponseDto(Team team)
        {
            var sport = await _sportRepo.GetSportById(team.SportId);
            var league = await _leagueRepo.GetLeagueById(team.LeagueId);

            return TeamMapper.MapToDto(team, league!, sport!);
        }

        private async Task<List<TeamResponseDto>> MapTeamList(List<Team> teams)
        {
            var list = new List<TeamResponseDto>();
            foreach(var team in teams)
            {
                list.Add(await MapTeamToResponseDto(team));
            }
            return list;
        }

    }
}