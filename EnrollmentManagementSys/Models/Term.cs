using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class Term
    {
        [Key]
        public Guid TermID { get; set; }
        public string TermName { get; set; }

        [ValidateNever]
        public ICollection<Fee> Fees { get; set; }

        [ValidateNever]
        public ICollection<StudentPayment> StudentPayments { get; set; }

        [ValidateNever]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
