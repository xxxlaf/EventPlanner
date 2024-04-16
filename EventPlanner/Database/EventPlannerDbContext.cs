using Microsoft.EntityFrameworkCore;
using EventPlanner.Models;

namespace EventPlanner.Database
{
    public class EventPlannerDbContext : DbContext
    {
        public EventPlannerDbContext(DbContextOptions<EventPlannerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Venue> Venues { get; set; }
    }
}
