using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class ModeOfPayment
    {
        [Key]
        public Guid ModeOfPaymentID { get; set; }
        public string ModeOfPaymentName { get; set; }

        [ValidateNever]

        public ICollection<StudentPayment> StudentPayments { get; set; }
    }
}
