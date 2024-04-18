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
            // Adding Relationships
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

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Event)
                .WithMany()
                .HasForeignKey(t => t.EventId);

            // Seeding Data
            modelBuilder.Entity<Organizer>().HasData(
                new Organizer { OrganizerId = 1, OrganizerName = "A Dude's Name", ContactInfo = "dude.name@cincinnatiinsurance.com", CompanyName = "Cincinnati Insurance" },
                new Organizer { OrganizerId = 2, OrganizerName = "Josh Bell", ContactInfo = "josh.bell@bogarts.com", CompanyName = "Bogart's" }
            );

            modelBuilder.Entity<Venue>().HasData(
                new Venue { VenueId = 1, VenueName = "Cincinnati Masonic Center", Location = "317 E 5th St, Cincinnati, OH 45202", Capacity = 500, RentalCost = 250 },
                new Venue { VenueId = 2, VenueName = "Bogart's Music Venue", Location = "2621 Short Vine St, Cincinnati, OH 45219", Capacity = 1500, RentalCost = 1000 }

            );

            modelBuilder.Entity<Event>().HasData(
                new Event { EventId = 1, OrganizerId = 1, VenueId = 1, EventName = "Pizza Party", EventDate = new DateOnly(2024, 4, 22) },
                new Event { EventId = 2, OrganizerId = 2, VenueId = 2, EventName = "John Summit Live", EventDate = new DateOnly(2024, 4, 26) }
            );

            modelBuilder.Entity<Attendee>().HasData(
                new Attendee { AttendeeId = 1, EventId = 1, Name = "Attendee 1", Email = "attendee1@example.com", Phone = "123-456-7890" },
                new Attendee { AttendeeId = 2, EventId = 1, Name = "Attendee 2", Email = "attendee2@example.com", Phone = "123-456-7891" },
                new Attendee { AttendeeId = 3, EventId = 1, Name = "Attendee 3", Email = "attendee3@example.com", Phone = "123-456-7892" },
                new Attendee { AttendeeId = 4, EventId = 1, Name = "Attendee 4", Email = "attendee4@example.com", Phone = "123-456-7893" },
                new Attendee { AttendeeId = 5, EventId = 1, Name = "Attendee 5", Email = "attendee5@example.com", Phone = "123-456-7894" },
                new Attendee { AttendeeId = 6, EventId = 2, Name = "Attendee 6", Email = "attendee6@example.com", Phone = "123-456-7895" },
                new Attendee { AttendeeId = 7, EventId = 2, Name = "Attendee 7", Email = "attendee7@example.com", Phone = "123-456-7896" },
                new Attendee { AttendeeId = 8, EventId = 2, Name = "Attendee 8", Email = "attendee8@example.com", Phone = "123-456-7897" },
                new Attendee { AttendeeId = 9, EventId = 2, Name = "Attendee 9", Email = "attendee9@example.com", Phone = "123-456-7898" },
                new Attendee { AttendeeId = 10, EventId = 2, Name = "Attendee 10", Email = "attendee10@example.com", Phone = "123-456-7899" }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { TaskItemId = 1, EventId = 1, Description = "Book Venue", Deadline = new DateOnly(2024, 4, 21), Status = false },
                new TaskItem { TaskItemId = 2, EventId = 1, Description = "Send Invitations", Deadline = new DateOnly(2024, 4, 21), Status = false },
                new TaskItem { TaskItemId = 3, EventId = 2, Description = "Sound Check w/ John Summit", Deadline = new DateOnly(2024, 4, 26), Status = false },
                new TaskItem { TaskItemId = 4, EventId = 2, Description = "Clean General Floor", Deadline = new DateOnly(2024, 4, 26), Status = false }
            );
        }
    }
}
