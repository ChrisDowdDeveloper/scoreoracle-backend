using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface IGameRepository
    {
        Task<Game?> GetGameById(Guid id);
        Task<Team?> GetTeamById(Guid id);
        Task<Sport?> GetSportById(Guid id);
        Task<League?> GetLeagueById(Guid id);
        Task<List<Team?>> GetGamesByTeamId(Guid id);
        Task<List<Sport?>> GetGamesBySportId(Guid id);
        Task<List<League?>> GetGamesByLeagueId(Guid id);
    }
}