﻿namespace UniiivMWebAsembly.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<CourseProfessor> CourseProfessors { get; set; }
    }
}
