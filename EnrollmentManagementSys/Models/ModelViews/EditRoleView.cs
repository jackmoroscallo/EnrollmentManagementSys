using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models.ModelViews
{
    public class EditRoleView
    {
        public EditRoleView()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
