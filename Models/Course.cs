namespace SchoolManagementSystemv2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; // New property
        public int Credits { get; set; } // New property
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = default!;
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; } = default!;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
