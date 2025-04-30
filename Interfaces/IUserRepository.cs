using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(Guid id);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByUsername(string username);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
    }
}