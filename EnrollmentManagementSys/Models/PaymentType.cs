using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class PaymentType
    {
        [Key]
        public Guid PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }

        [ValidateNever]
        public ICollection<StudentPayment> StudentPayments { get; set; }
    }
}
