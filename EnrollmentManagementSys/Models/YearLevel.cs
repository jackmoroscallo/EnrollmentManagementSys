using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EnrollmentManagementSys.Models
{
    public class YearLevel
    {
        public Guid YearLevelID { get; set; }
        public int YearLevelNum { get; set; }
        [ValidateNever]
        public ICollection<Student> Students { get; set; }
        [ValidateNever]
        public ICollection<Fee> Fees { get; set; }
        [ValidateNever]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
