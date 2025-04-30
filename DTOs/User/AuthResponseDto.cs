using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.User
{
    public class AuthResponseDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string? ProfilePicture { get; set; }
        public string? FavoriteSport { get; set; }
        public string? FavoriteTeam { get; set; }
        public string AccessToken { get; set; }

    }
}