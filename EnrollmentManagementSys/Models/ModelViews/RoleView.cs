using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models.ModelViews
{
    public class RoleView
    {
        [Required]
        public string RoleName { get; set; }
    }
}
