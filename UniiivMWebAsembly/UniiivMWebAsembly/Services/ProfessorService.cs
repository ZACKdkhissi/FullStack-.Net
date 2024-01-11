using System.Net.Http.Json;
using UniiivMWebAsembly.Entities;

namespace UniiivMWebAsembly.Services
{
    public class ProfessorService
    {
        private readonly HttpClient _httpClient;
        public ProfessorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Professor>> GetProfessorsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Professor>>("https://localhost:7059/api/Professor");
        }

        public async Task<HttpResponseMessage> DeleteProfessorAsync(int professorId)
        {
            return await _httpClient.DeleteAsync($"https://localhost:7059/api/Professor/{professorId}");
        }

        public async Task<HttpResponseMessage> AddProfessorAsync(Professor newProfessor)
        {
            // Assurez-vous que CourseProfessors n'est pas null pour éviter BadRequest
            if (newProfessor.CourseProfessors == null)
            {
                newProfessor.CourseProfessors = new List<CourseProfessor>();
            }

            return await _httpClient.PostAsJsonAsync("https://localhost:7059/api/Professor", newProfessor);
        }

        

        public async Task<Professor> GetProfessorAsync(int professorId)
        {
            return await _httpClient.GetFromJsonAsync<Professor>($"https://localhost:7059/api/Professor/{professorId}");
        }
        public async Task<HttpResponseMessage> UpdateProfessorAsync(Professor professor)
        {
            // L'URL doit correspondre à l'endpoint de votre API pour la mise à jour d'un professeur
            return await _httpClient.PutAsJsonAsync($"https://localhost:7059/api/Professor/{professor.ProfessorId}", professor);
        }
    }
}
