namespace SchoolManagementSystemv2.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation
        public ICollection<Student> Students { get; set; }
    }

}
