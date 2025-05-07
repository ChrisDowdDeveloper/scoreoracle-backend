using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Pick
{
    public class PickResponseDto
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public Guid GroupId { get; set; }
        public string GroupName { get; set; }

        public Guid GameId { get; set; }

        public Guid AwayTeamId { get; set; }
        public string AwayTeamCity { get; set; }
        public string AwayTeamName { get; set; }

        public Guid HomeTeamId { get; set; }
        public string HomeTeamCity { get; set; }
        public string HomeTeamName { get; set; }

        public Guid PredictedWinnerId { get; set; }
        public string PredictedTeamCity { get; set; }
        public string PredictedWinnerTeamName { get; set; }

        public DateTime GameDate { get; set; }
        public bool? IsCorrect { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}