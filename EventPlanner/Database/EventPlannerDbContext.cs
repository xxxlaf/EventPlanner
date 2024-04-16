using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Database
{
    public class EventPlannerDbContext : DbContext
    {
        public EventPlannerDbContext(DbContextOptions<EventPlannerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
    }
}
