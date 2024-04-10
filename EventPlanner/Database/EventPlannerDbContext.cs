using Microsoft.EntityFrameworkCore;
using EventPlanner.Entities;

namespace EventPlanner.Database
{
    public class EventPlannerDbContext : DbContext
    {
        public EventPlannerDbContext(DbContextOptions<EventPlannerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event { EventId = 1, EventName = "Danny's Graduation Party", EventDescription = "A lowkey party in the center of the Pacific Ocean.", Location = "Pacific Ocean", StartDate = DateTime.Now.AddDays(30), EndDate = DateTime.Now.AddDays(31) },
                new Event { EventId = 2, EventName = "EDM Concert", EventDescription = "An EDM concert at Bogart's.", Location = "2621 Short Vine St, Cincinnati, OH 45219", StartDate = DateTime.Now.AddDays(35), EndDate = DateTime.Now.AddDays(36) },
                new Event { EventId = 3, EventName = "Retirement Party", EventDescription = "A retirement party for Joe.", Location = "400 Broadway, Cincinnati, OH 45202", StartDate = DateTime.Now.AddDays(37), EndDate = DateTime.Now.AddDays(38) }
            );
        }
    }
}
