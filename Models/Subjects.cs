namespace BlazorApp3.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MajorId { get; set; }
        public Majors Major { get; set; }
        public string Code { get; set; }
    }
}
