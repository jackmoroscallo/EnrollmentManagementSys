using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class Gender
    {
        [Key]
        public Guid GenderID { get; set; }
        public string Name { get; set; }
        [ValidateNever]
        ICollection<Student> Students { get; set; }
    }
}
