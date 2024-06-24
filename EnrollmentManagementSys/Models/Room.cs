using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagementSys.Models
{
    public class Room
    {
        [Key]
        public Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public string Details { get; set; }

        [ValidateNever]
        public ICollection<SubjectSchedule> SubjectSchedules { get; set; }
    }
}
