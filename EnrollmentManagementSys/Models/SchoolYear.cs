using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class SchoolYear
    {
        [Key]

        public Guid SchoolYearID { get; set; }
        public string SchoolYearName { get; set; }

        [ValidateNever]

        public ICollection<Fee> Fees { get; set; }

        [ValidateNever]

        public ICollection<StudentPayment> StudentPayments { get; set; }

        [ValidateNever]
        public ICollection<OfferedSubject> OfferedSubjects { get; set; }
        [ValidateNever]
        public ICollection<SubjectSchedule> SubjectSchedules { get; set; }
        [ValidateNever]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
