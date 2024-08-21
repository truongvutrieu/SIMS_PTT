using BlazorApp3.Data;

namespace BlazorApp3.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public string? Grade {  get; set; }
        public string? Note{  get; set; }

    }
}
