using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EnrollmentManagementSys.Models
{
    public class Enrollment
    {
        public Guid EnrollmentID { get; set; }
        public Guid RecordID { get; set; }
        public Guid StudentCourseID { get; set; }
        public Guid YearLevelID { get; set; }
        public Guid SchoolYearID { get; set; }
        public Guid TermID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Guid EnrollmentStatusID { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }

        [ValidateNever]
        public YearLevel YearLevel { get; set; }

        [ValidateNever]
        public SchoolYear SchoolYear { get; set; }
        [ValidateNever]
        public Term Term { get; set; }
        [ValidateNever]
        public EnrollmentStatus EnrollmentStatuses { get; set; }

        [ValidateNever]
        public Student Student { get; set; }
    }
}
