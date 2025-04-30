using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Game
{
    public class UpdateGameDto
    {
        public DateTime GameDate { get; set; }
        public bool IsCompleted { get; set; }
        public Guid? WinnerTeamId { get; set; }
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
    }
}