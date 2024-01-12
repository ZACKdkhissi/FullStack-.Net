using System.Net.Http.Json;
using UniiivMWebAsembly.Dto;
using UniiivMWebAsembly.Entities;

namespace UniiivMWebAsembly.Services
{
    public class CourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>("https://localhost:7059/api/Course");
        }

        public async Task<HttpResponseMessage> AddCourseAsync(Course course)
        {
            return await _httpClient.PostAsJsonAsync("https://localhost:7059/api/Course", course);
        }

        public async Task<HttpResponseMessage> UpdateCourseAsync(Course course)
        {
            return await _httpClient.PutAsJsonAsync($"https://localhost:7059/api/Course/{course.CourseId}", course);
        }

        public async Task<HttpResponseMessage> DeleteCourseAsync(int courseId)
        {
            return await _httpClient.DeleteAsync($"https://localhost:7059/api/Course/{courseId}");
        }

        public async Task<Course> GetCourseAsync(int courseId)
        {
            // Adaptez l'URL à la structure de votre API.
            var response = await _httpClient.GetAsync($"https://localhost:7059/api/Course/{courseId}");

            if (response.IsSuccessStatusCode)
            {
                // Si la réponse est réussie, désérialisez le JSON dans un objet Course.
                return await response.Content.ReadFromJsonAsync<Course>();
            }
            else
            {
                // Gérer les réponses non réussies (par exemple, retourner null ou lever une exception).
                return null;
            }
        }

        // CourseService.cs
        public async Task<HttpResponseMessage> AddProfessorToCourseAsync(int courseId, int professorId)
        {
            var content = new FormUrlEncodedContent(new[]
            {
        new KeyValuePair<string, string>("courseId", courseId.ToString()),
        new KeyValuePair<string, string>("professorId", professorId.ToString())
    });

            return await _httpClient.PostAsync($"https://localhost:7059/api/Course/{courseId}/addprofessor/{professorId}", content);
        }

        


    }
}




