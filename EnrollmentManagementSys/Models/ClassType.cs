using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class ClassType
    {
        [Key]
        public Guid ClassTypeID { get; set; }
        public string ClassTypeName { get; set; }

        [ValidateNever]
        public ICollection<OfferedSubject> OfferedSubjects { get; set; }

    }
}
