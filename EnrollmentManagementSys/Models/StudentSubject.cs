using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagementSys.Models
{
    public class StudentSubject
    {
        [Key]
        public Guid SubjectId { get; set; }
        public Guid StudentCourseID { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectDescription { get; set; }
        public int Units { get; set; }
        public Guid TypeID { get; set; }
        public float SubjectHours { get; set; }

        [ValidateNever]

        public StudentSubjectType StudentSubjectType { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }

        [ValidateNever]
        public ICollection<OfferedSubject> OfferedSubjects { get; set; }

        [ValidateNever]
        public ICollection<SubjectSchedule> SubjectSchedules { get; set; }

        [ValidateNever]
        [NotMapped]
        public string SubjectInfo
        {
            get
            {
                return $"{SubjectCode} - {SubjectDescription}";
            }
        }
    }
}
