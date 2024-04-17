using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Models
{
    [Table("Events")]
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        public int VenueId { get; set; }
        [Required]
        public int OrganizerId { get; set; }
        public string? EventName { get; set; }
        public DateOnly EventDate { get; set; }

        public virtual Venue? Venue { get; set; }
        public virtual Organizer? Organizer { get; set; }
    }
}
