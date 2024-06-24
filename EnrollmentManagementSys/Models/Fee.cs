using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class Fee
    {
        [Key]

        public Guid FeeID { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public Guid FeeTypeID { get; set; }
        public Guid StudentCourseID { get; set; }
        public Guid YearLevelID { get; set; }
        public Guid SchoolYearID { get; set; }
        public Guid TermID { get; set; }

        [ValidateNever]

        public FeeType FeeType { get; set; }
        [ValidateNever]
        public YearLevel YearLevel { get; set; }
        [ValidateNever]
        public Term Term { get; set; }

        [ValidateNever]
        public StudentCourse StudentCourse { get; set; }

        [ValidateNever]
        public SchoolYear SchoolYear { get; set; }
    }
}
