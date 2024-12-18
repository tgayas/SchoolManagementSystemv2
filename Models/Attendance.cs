namespace SchoolManagementSystemv2.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
    }

}
