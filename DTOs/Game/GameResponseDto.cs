using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Game
{
    public class GameResponseDto
    {
        public Guid Id { get; set; }

        public Guid SportId { get; set; }
        public string SportName { get; set; }
        
        public Guid LeagueId { get; set; }
        public string LeagueName { get; set; }

        public Guid HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLogoUrl { get; set; }

        public Guid AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamLogoUrl { get; set; }

        public DateTime GameDate { get; set; }
        public bool IsCompleted { get; set; }

        public Guid? WinnerTeamId { get; set; }
        public string? WinnerTeamName { get; set; }
        public string? WinnerTeamLogoUrl { get; set; }

        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
    }

}