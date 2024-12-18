namespace SchoolManagementSystemv2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<PaymentRecord> PaymentRecords { get; set; } = new List<PaymentRecord>();
        public ICollection<TuitionBilling> TuitionBillings { get; set; } = new List<TuitionBilling>();
    }

}
