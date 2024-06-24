using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class Course
    {
        [Key]
        public Guid RecordNumberId { get; set; }
        public Guid StudentCourseID { get; set; }
        public string CourseDescription { get; set; }
        public string CourseStatus { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }
    }
}
