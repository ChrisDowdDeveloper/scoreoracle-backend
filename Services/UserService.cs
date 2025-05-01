using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.User;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;

namespace scoreoracle_backend.Services
{
    public class UserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<AuthResponseDto?> GetUserById(Guid id)
        {
            var user = await _repo.GetUserById(id);
            return user is null ? null : AuthMapper.MapToDto(user);
        }

        public async Task<AuthResponseDto?> GetUserByUsername(string username)
        {
            var user = await _repo.GetUserByUsername(username);
            return user is null ? null : AuthMapper.MapToDto(user);
        }

        public async Task<AuthResponseDto?> GetUserByEmail(string email)
        {
            var user = await _repo.GetUserByEmail(email);
            return user is null ? null : AuthMapper.MapToDto(user);
        }

        public async Task<AuthResponseDto?> UpdateUser(Guid id, UpdateAuthDto dto)
        {
            var user = await _repo.GetUserById(id);
            if(user == null) return null;

            AuthMapper.MapToUpdatedModel(user, dto);
            user.UpdatedAt = DateTime.UtcNow;
            
            var updated = await _repo.UpdateUser(user);
            return AuthMapper.MapToDto(updated);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _repo.GetUserById(id);
            if(user == null) return false;

            await _repo.DeleteUser(user);
            return true;
        }
    }
}