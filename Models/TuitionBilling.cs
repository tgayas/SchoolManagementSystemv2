using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystemv2.Models
{
    public class TuitionBilling
    {
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }

        public DateTime BillingDate { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!; // Initialized as non-null
    }


}
