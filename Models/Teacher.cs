namespace SchoolManagementSystemv2.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SubjectSpecialization { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }

}
