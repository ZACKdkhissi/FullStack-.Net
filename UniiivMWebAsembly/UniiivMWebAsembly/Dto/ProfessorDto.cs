namespace UniiivMWebAsembly.Dto
{
    public class ProfessorDto
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
