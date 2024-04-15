using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int VenueId { get; set; }
        public int OrganizerId { get; set; }
        public string? EventName { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
