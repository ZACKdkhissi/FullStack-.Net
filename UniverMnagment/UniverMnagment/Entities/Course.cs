using System.Text.Json.Serialization;

namespace UniverMnagment.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        [JsonIgnore]
        public ICollection<CourseProfessor> CourseProfessors { get; set; } = new List<CourseProfessor>();

        [JsonIgnore]
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }

}