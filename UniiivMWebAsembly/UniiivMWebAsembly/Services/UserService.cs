using System.Net.Http.Json;
using UniiivMWebAsembly.Entities;

namespace UniiivMWebAsembly.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("https://localhost:7059/User");
        }
    }
}
