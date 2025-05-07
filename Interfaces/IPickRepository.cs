using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface IPickRepository
    {
        Task<Pick> CreatePick(Pick pick);
        Task<Pick?> GetPickById(Guid id);
        Task<List<Pick>> GetPicksByUserId(Guid userId);
        Task<List<Pick>> GetPicksByGroupId(Guid groupId);
        Task<List<Pick>> GetPicksByUserAndGroup(Guid userId, Guid groupId);
        Task<Pick?> GetPickByUserAndGame(Guid userId, Guid gameId);
        Task<Pick> UpdatePick(Pick pick);
        Task<Pick> DeletePick(Pick pick);
        Task<List<Pick>> GetAllPicks();
    }
}