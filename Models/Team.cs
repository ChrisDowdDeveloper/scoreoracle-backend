using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace scoreoracle_backend.Models
{
    [Table("teams")]
    public class Team : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("sport_id")]
        public Guid SportId { get; set; }

        [Column("league_id")]
        public Guid LeagueId { get; set; }

        [Column("logo_url")]
        public string LogoUrl { get; set; }

        [Column("abbreviation")]
        public string Abbreviation { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}