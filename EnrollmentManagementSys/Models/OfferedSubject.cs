using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class OfferedSubject
    {
        [Key]

        public Guid OfferedSubjectID { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ClassTypeID { get; set; }
        public int Capacity { get; set; }
        public DateTime DateOffered { get; set; }
        public float SubjectRate { get; set; }
        public Guid SchoolYearID { get; set; }
        public Guid SemesterID { get; set; }
        public Guid StudentCourseID { get; set; }
        public int SubjectLevel { get; set; }


        [ValidateNever]
        public StudentSubject StudentSubject { get; set; }

        [ValidateNever]
        public ClassType ClassType { get; set; }

        [ValidateNever]
        public Semester Semester { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }

        [ValidateNever]
        public SchoolYear SchoolYear { get; set; }


    }
}
