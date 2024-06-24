using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class Semester
    {
        [Key]
        public Guid SemesterID { get; set; }
        public string SemesterName { get; set; }

        [ValidateNever]
        public ICollection<OfferedSubject> OfferedSubjects { get; set; }

        [ValidateNever]
        public ICollection<SubjectSchedule> SubjectSchedules { get; set; }
    }
}
