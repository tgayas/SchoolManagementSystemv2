using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystemv2.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        [Precision(18, 2)]
        public decimal Score { get; set; }


    }

}