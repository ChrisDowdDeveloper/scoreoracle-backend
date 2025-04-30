using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace scoreoracle_backend.Models
{
    [Table("users")]
    public class User : BaseModel
    {
        [PrimaryKey("id", false)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("profile_picture")]
        public string? ProfilePicture { get; set; }

        [Column("favorite_sport")]
        public string? FavoriteSport { get; set; }

        [Column("favorite_team")]
        public string? FavoriteTeam { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}