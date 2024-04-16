using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Models
{
    [Table("Organizers")]
    public class Organizer
    {
        public int OrganizerId { get; set; }
        public string? OrganizerName { get; set; }
        public string? ContactInfo { get; set; }
        public string? CompanyName { get; set; }
    }
}
