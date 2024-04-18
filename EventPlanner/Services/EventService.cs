using EventPlanner.Database;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Services
{
    public class EventService
    {
        private readonly EventPlannerDbContext _dbContext;
        public EventService(EventPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            _dbContext.Events.Add(newEvent);
            await _dbContext.SaveChangesAsync();
            return newEvent;
        }

        public async Task<Event> UpdateEventAsync(Event updatedEvent)
        {
            _dbContext.Entry(updatedEvent).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return updatedEvent;
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var eventToDelete = await _dbContext.Events.FindAsync(eventId);
            if (eventToDelete != null)
            {
                _dbContext.Events.Remove(eventToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
