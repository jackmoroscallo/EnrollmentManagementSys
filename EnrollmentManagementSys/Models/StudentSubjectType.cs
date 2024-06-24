using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class StudentSubjectType
    {
        [Key]
        public Guid TypeID { get; set; }
        public string TypeName { get; set; }

        [ValidateNever]
       public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
