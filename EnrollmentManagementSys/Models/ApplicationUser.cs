using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255, ErrorMessage = "The FirstName should have a maximum of 255 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The LastName should have a maximum of 255 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
