using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class StudentStatus
    {
        [Key]
        public Guid StudentStatusID { get; set; }
        public string StatusName { get; set; }
        [ValidateNever]
        ICollection<Student> Students { get; set; }
    }
}
