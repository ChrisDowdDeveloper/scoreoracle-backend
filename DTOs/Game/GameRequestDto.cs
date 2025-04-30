using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Game
{
    public class GameRequestDto
    {
        public Guid SportId { get; set; }
        public Guid LeagueId { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public DateTime GameDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public Guid? WinnerTeamId { get; set; } = null;
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
    }
}