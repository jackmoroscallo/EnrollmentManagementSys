using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace EnrollmentManagementSys.Models
{
    public class Instructor
    {
        [Key]
        public Guid InstructorID { get; set; }

        public Guid StudentCourseID { get; set; }
        public string InstructorName { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }

        [ValidateNever]
        public ICollection<SubjectSchedule> SubjectSchedules { get; set; }

        [ValidateNever]
        [NotMapped]
        public string InstructorInfo
        {
            get
            {
                return $"{InstructorName}";
            }
        }
    }
}
