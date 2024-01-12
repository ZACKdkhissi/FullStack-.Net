namespace UniiivMWebAsembly.Dto
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
