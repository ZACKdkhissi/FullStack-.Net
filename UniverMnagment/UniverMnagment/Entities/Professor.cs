using System.Text.Json.Serialization;

namespace UniverMnagment.Entities
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<CourseProfessor> CourseProfessors { get; set; } = new List<CourseProfessor>();
    }

}
