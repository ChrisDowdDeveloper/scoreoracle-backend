using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace scoreoracle_backend.Models
{
    [Table("games")]
    public class Game : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("sport_id")]
        public Guid SportId { get; set; }

        [Column("league_id")]
        public Guid LeagueId { get; set; }

        [Column("home_team_id")]
        public Guid HomeTeamId { get; set; }

        [Column("away_team_id")]
        public Guid AwayTeamId { get; set; }

        [Column("game_date")]
        public DateTime GameDate { get; set; }

        [Column("is_completed")]
        public bool IsCompleted { get; set; }

        [Column("winner_team_id")]
        public Guid WinnerTeamId { get; set; }

        [Column("score_home")]
        public int ScoreHome { get; set; }

        [Column("score_away")]
        public int ScoreAway { get; set; }
    }
}