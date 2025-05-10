using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Leaderboard
{
    public class LeaderboardEntryDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public int CorrectPicks { get; set; }
        public int TotalPicks { get; set; }
    }
}