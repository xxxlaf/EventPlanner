using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        [MaxLength(200)]
        public string? EventDescription { get; set; }
        [MaxLength(100)]
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
