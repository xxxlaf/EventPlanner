using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public int VenueId { get; set; }

        [Required]
        public int OrganizerId { get; set; }

        [Required(ErrorMessage = "The event name is required.")]
        [StringLength(100, ErrorMessage = "The name is too long.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "The event date is required.")]
        public DateTime EventDate { get; set; }

        // Navigation properties (if you're using Entity Framework)
        public virtual Venue Venue { get; set; }
        public virtual Organizer Organizer { get; set; }
    }
}
