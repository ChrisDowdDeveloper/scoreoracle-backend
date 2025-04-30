using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using scoreoracle_backend.DTOs.User;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Mappers
{
    public static class AuthMapper
    {
        public static AuthResponseDto MapToDto(User user)
        {
            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name,
                Username = user.Username,
                ProfilePicture = user.ProfilePicture,
                FavoriteSport = user.FavoriteSport,
                FavoriteTeam = user.FavoriteTeam
            };
        }

        public static User MapToModel(AuthRequestDto dto, Guid supabaseId)
        {
            return new User
            {
                Id = supabaseId,
                Email = dto.Email,
                Name = dto.Name ?? "",
                Username = dto.Username,
                ProfilePicture = dto.ProfilePicture ?? "",
                FavoriteSport = dto.FavoriteSport ?? "",
                FavoriteTeam = dto.FavoriteTeam ?? "",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void MapToUpdatedModel(User user, UpdateAuthDto dto)
        {
            if(!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;

            if(!string.IsNullOrWhiteSpace(dto.Name))
                user.Name = dto.Name;

            if(!string.IsNullOrWhiteSpace(dto.Username))
                user.Username = dto.Username;

            if(!string.IsNullOrWhiteSpace(dto.ProfilePicture))
                user.ProfilePicture = dto.ProfilePicture;

            if(!string.IsNullOrWhiteSpace(dto.FavoriteSport))
                user.FavoriteSport = dto.FavoriteSport;

            if(!string.IsNullOrWhiteSpace(dto.FavoriteTeam))
                user.FavoriteTeam = dto.FavoriteTeam;
        }
    }
}