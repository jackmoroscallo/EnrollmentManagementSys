using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class Section
    {
        [Key]
        public Guid SectionID { get; set; }
        public string SectionName { get; set; }
        public Guid StudentCourseID { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }

        [ValidateNever]
        public ICollection<SubjectSchedule> SubjectSchedules { get; set; }
    }
}
