using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EnrollmentManagementSys.Models
{
    public class EnrollmentStatus
    {
        public Guid EnrollmentStatusID { get; set; }
        public string EnrollmentStatusName { get; set; }

        [ValidateNever]

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
