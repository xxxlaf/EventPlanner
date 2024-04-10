using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EventPlanner.Entities
{
    [Table("Events")]
    public class Event
    {
        public int EventId { get; set; }
        [MaxLength(50)]
        public string? EventName { get; set; }
        [MaxLength(200)]
        public string? EventDescription { get; set; }
        [MaxLength(100)]
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
