using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class StudentPayment
    {
        [Key]

        public Guid PaymentID { get; set; }
        public Guid RecordID { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public Guid PaymentTypeID { get; set; }
        public Guid SchoolYearID { get; set; }
        public Guid TermID { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid ModeOfPaymentID { get; set; }
        public string Details { get; set; }

        [ValidateNever]
        public Student Student { get; set; }

        [ValidateNever]
        public Term Term { get; set; }

        [ValidateNever]
        public PaymentType PaymentType { get; set; }

        [ValidateNever]
        public ModeOfPayment ModeOfPayment { get; set; }

        [ValidateNever]
        public SchoolYear SchoolYear { get; set; }
    }
}
