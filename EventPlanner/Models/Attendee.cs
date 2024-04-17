using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Models
{
    [Table("Attendees")]
    public class Attendee
    {
        public int AttendeeId { get; set; }
        [Required]
        public int EventId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual Event? Event { get; set; }
    }
}
