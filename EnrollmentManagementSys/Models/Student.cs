using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagementSys.Models
{
    public class Student
    {
        [Key]
        public Guid RecordID { get; set; }
        public string StudentID { get; set; }
        public string LastName { get; set;}
        public string FirstName { get; set;}
        public string MiddleName { get; set;}
        public Guid StudentCourseID {  get; set; }
        public Guid YearLevelID { get; set; }
        public Guid StudentStatusID { get; set; }
        public Guid GenderID { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email {  get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }
        [ValidateNever]
        public YearLevel YearLevel { get; set; }
        [ValidateNever]
        public StudentStatus StudentStatus { get; set; }
        [ValidateNever]
        public Gender Gender { get; set; }

        [ValidateNever]
        public ICollection<StudentPayment> StudentPayments { get; set; }

        [ValidateNever]
        public ICollection<Enrollment> Enrollments { get; set; }

        [ValidateNever]
        [NotMapped]
        public string StudentInfo
        {
            get
            {
                return $"{StudentID} - {LastName}, {FirstName} {MiddleName}";
            }
        }
    }
}
