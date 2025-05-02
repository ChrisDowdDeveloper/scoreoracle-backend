using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface ISportRepository
    {
        Task<List<Sport>> GetAllSports();
        Task<Sport?> GetSportById(Guid id);
        Task<Sport?> GetSportByName(string name);
        Task<Sport> CreateSport(Sport sport);
        Task<Sport> UpdateSport(Sport sport);
        Task<Sport> DeleteSport(Sport sport);
    }
}