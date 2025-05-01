using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.User;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;

namespace scoreoracle_backend.Services
{
    public class AuthService
    {
        private readonly IUserRepository _repo;

        public AuthService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<AuthResponseDto> CreateUser(AuthRequestDto dto, Guid supabaseId, string token)
        {
            var user = AuthMapper.MapToModel(dto, supabaseId);
            var result = await _repo.CreateUser(user);
            var response = AuthMapper.MapToDto(result);
            response.AccessToken = token;
            return response;
        }

        public async Task<AuthResponseDto?> GetUserById(Guid id)
        {
            var user = await _repo.GetUserById(id);
            return user is null ? null : AuthMapper.MapToDto(user);
        }

    }
}