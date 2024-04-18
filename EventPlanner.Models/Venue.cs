using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Models
{
    [Table("Venues")]
    public class Venue
    {
        public int VenueId { get; set; }
        public string? VenueName { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public int RentalCost { get; set; }
    }
}
