using Microsoft.AspNetCore.Mvc;
using EventPlanner.Database;
using EventPlanner.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly EventPlannerDbContext _dbContext;

    public EventsController(EventPlannerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // DELETE: api/events/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)

    {
        var @event = await _dbContext.Events.FindAsync(id);
        if (@event == null)
        {
            return NotFound();
        }

        _dbContext.Events.Remove(@event);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
