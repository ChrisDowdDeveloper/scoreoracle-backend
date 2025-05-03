using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllTeams();
        Task<Team?> GetTeamById(Guid id);
        Task<List<Team>> GetTeamByName(string name);
        Task<List<Team>> GetTeamsByCityName(string cityName);
        Task<List<Team>> GetTeamsBySportId(Guid sportId);
        Task<List<Team>> GetTeamsByLeagueId(Guid leagueId);
        Task<Team> CreateTeam(Team team);
        Task<Team> UpdateTeam(Team team);
        Task<Team> DeleteTeam(Team team);
    }
}