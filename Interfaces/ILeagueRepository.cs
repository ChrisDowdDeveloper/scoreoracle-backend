using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface ILeagueRepository
    {
        Task<League?> GetLeagueById(Guid id);
        Task<League?> GetLeagueByName(string name);
        Task<List<League>> GetAllLeagues();
        Task<List<League>> GetLeaguesBySportId(Guid sportId);
        Task<Sport?> GetSportById(Guid id);
        Task<League> CreateLeague(League league);
        Task<League> UpdateLeague(League league);
        Task<League> DeleteLeague(League league);
    }
}