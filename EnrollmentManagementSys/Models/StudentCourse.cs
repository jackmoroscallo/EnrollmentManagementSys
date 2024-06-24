using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class StudentCourse
    {
        [Key]
        public Guid StudentCourseID {  get; set; }
        public string CourseName { get; set; }

        [ValidateNever]

        public ICollection<Student> Students { get; set; }

        [ValidateNever]
        public ICollection<Course> Courses { get; set; }

        [ValidateNever]
        public ICollection<Section> Sections { get; set; }

        [ValidateNever]
        public ICollection<Fee> Fees { get; set; }

        [ValidateNever]
        public ICollection<OfferedSubject> OfferedSubjects { get; set; }
        [ValidateNever]
        public ICollection<SubjectSchedule> SubjectSchedules { get; set; }
        [ValidateNever]
        public ICollection<Instructor> Instructors { get; set; }
        [ValidateNever]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
