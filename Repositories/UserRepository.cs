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
                Console.WriteLine($"Supabase HTTP {(int)ex.StatusCode} {ex.StatusCode}");
                Console.WriteLine($"Response body: {ex.Response}");
                throw;
            }
        }

        public async Task<User> DeleteUser(User user)
        {
            var result = await _client.From<User>().Delete(user);
            return result.Models.First();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var result = await _client.From<User>().Filter("email", Supabase.Postgrest.Constants.Operator.Equals, email).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var result = await _client.From<User>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id.ToString())
                .Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var result = await _client.From<User>().Filter("username", Supabase.Postgrest.Constants.Operator.Equals, username).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _client.From<User>().Update(user);
            return result.Models.First();
        }
    }
}