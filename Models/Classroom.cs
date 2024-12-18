namespace SchoolManagementSystemv2.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }



}
