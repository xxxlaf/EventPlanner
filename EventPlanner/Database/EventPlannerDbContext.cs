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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Event)
                .WithMany()
                .HasForeignKey(a => a.EventId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany()
                .HasForeignKey(e => e.VenueId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany()
                .HasForeignKey(e => e.OrganizerId);

            //modelBuilder.Entity<Event>()
            //    .Property(e => e.EventDate)
            //    .HasColumnType("datetime2");

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Event)
                .WithMany()
                .HasForeignKey(t => t.EventId);

            //modelBuilder.Entity<TaskItem>()
            //    .Property(t => t.Deadline)
            //    .HasColumnType("datetime2");


        }
    }
}
