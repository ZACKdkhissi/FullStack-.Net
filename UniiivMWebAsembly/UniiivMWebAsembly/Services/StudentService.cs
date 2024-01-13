using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using UniiivMWebAsembly.Entities;
using UniiivMWebAsembly.Dto;

namespace UniiivMWebAsembly.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public StudentService(HttpClient httpClient, TokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Student>>("https://localhost:7059/api/Student");
        }

        public async Task<HttpResponseMessage> AddStudentAsync(Student student)
        {
            return await _httpClient.PostAsJsonAsync("https://localhost:7059/api/Student", student);
        }

        public async Task<HttpResponseMessage> DeleteStudentAsync(int studentId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7059/api/Student/{studentId}");

            return response;
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7059/api/Student/{studentId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Student>();
            }
            else
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> UpdateStudentAsync(Student student)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7059/api/Student/{student.ID}", student);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new Exception("La mise à jour de l'étudiant a échoué.");
            }
        }

        public async Task<bool> AddCourseToStudentAsync(int studentId, int courseId)
        {
            // Créer un objet d'association StudentCourse
            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            // Convertir l'objet en JSON
            var studentCourseJson = JsonSerializer.Serialize(studentCourse);

            // Créer le contenu de la requête
            var content = new StringContent(studentCourseJson, Encoding.UTF8, "application/json");

            // Envoyer la requête POST à l'API
            var response = await _httpClient.PostAsync($"https://localhost:7059/api/Student/{studentId}/addcourse/{courseId}", content);

            // Vérifier si la requête a réussi
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<List<StudentDto>> GetStudentsWithCoursesAsync()
        {
            // Utilisez l'URL de votre API backend pour récupérer les données
            var studentsWithCourses = await _httpClient.GetFromJsonAsync<List<StudentDto>>("https://localhost:7059/api/Student/withcourses");
            return studentsWithCourses;
        }



    }
}
