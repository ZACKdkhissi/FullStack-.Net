using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using UniiivMWebAsembly.Entities;
using System.Net.Http;
using System;

namespace UniiivMWebAsembly.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public UserService(HttpClient httpClient, TokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
{
    try
    {
        var apiUrl = $"https://localhost:7059/User/auth?username={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}";

        var response = await _httpClient.PostAsync(apiUrl, null);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            await _tokenService.SaveTokenAsync(token);
            return true;
        }

        return false;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
}



        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("https://localhost:7059/User");
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"https://localhost:7059/User/{id}");
        }

        public async Task<HttpResponseMessage> AddUserAsync(User user)
        {
            return await _httpClient.PostAsJsonAsync("https://localhost:7059/User", user);
        }
      

        public async Task UpdateUserAsync(int id, User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7059/User/{id}", user);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7059/User/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
