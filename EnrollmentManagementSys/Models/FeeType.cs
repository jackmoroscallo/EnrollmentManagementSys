using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class FeeType
    {
        [Key]
        public Guid FeeTypeID { get; set; }
        public string FeeTypeName { get; set; }

        [ValidateNever]
        public ICollection<Fee> Fees { get; set; }
    }
}
