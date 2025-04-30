using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Models;
using Supabase;
using Supabase.Postgrest.Exceptions;


namespace scoreoracle_backend.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly Client _client;
        public UserRepository(Client client)
        {
            _client = client;
        }
        public async Task<User> CreateUser(User user)
        {
            try
            {
                var response = await _client.From<User>().Insert(user);
                return response.Models.First();
            }
            catch (PostgrestException ex)
            {
                // print status and full content
                Console.WriteLine($"Supabase HTTP {(int)ex.StatusCode} {ex.StatusCode}");
                Console.WriteLine($"Response body: {ex.Response}");
                throw;
            }
        }

        public Task<User> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}