using System.Data.SqlTypes;

namespace EventPlanner.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string? VenueName { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public int RentalCost { get; set; }
    }
}
