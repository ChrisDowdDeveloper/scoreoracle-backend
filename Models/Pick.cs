using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace scoreoracle_backend.Models
{
    [Table("picks")]
    public class Pick : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("group_id")]
        public Guid GroupId { get; set; }

        [Column("game_id")]
        public Guid GameId { get; set; }

        [Column("predicted_winner_id")]
        public Guid PredictedWinnerId { get; set; }

        [Column("is_correct")]
        public bool? IsCorrect { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}