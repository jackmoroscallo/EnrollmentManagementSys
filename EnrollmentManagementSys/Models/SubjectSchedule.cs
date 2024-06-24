using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class SubjectSchedule
    {
        [Key]
        public Guid SubjectScheduleID { get; set; }
        public Guid SubjectId { get; set; }
        public DateTime SubjectTimeStart { get; set; }
        public DateTime SubjectTimeEnd { get; set; }
        public string SubjectDay { get; set; }
        public bool Mon {  get; set; }
        public bool Tue {  get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri {  get; set; }
        public bool Sat { get; set; }
        public bool Sun { get; set; }
        public Guid RoomID { get; set; }
        public Guid InstructorID { get; set; }
        public Guid StudentCourseID { get; set; }
        public int SubjectLevel { get; set; }
        public Guid SectionID { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid SchoolYearID { get; set; }
        public Guid SemesterID { get; set; }

        [ValidateNever]
        public StudentSubject StudentSubject { get; set; }

        [ValidateNever]
        public Room Room { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }

        [ValidateNever]
        public Section Section { get; set; }

        [ValidateNever]
        public Semester Semester { get; set; }
        [ValidateNever]
        public SchoolYear SchoolYear { get; set; }
        [ValidateNever]
        public Instructor Instructor { get; set; }
    }
}
