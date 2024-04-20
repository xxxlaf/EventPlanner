using Microsoft.EntityFrameworkCore;
using EventPlanner.Database;
using EventPlanner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace EventPlanner.Controllers;

public static class EventEndpoints
{
    public static void MapEventEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Event").WithTags(nameof(Event));

        group.MapGet("/", async (EventPlannerDbContext db) =>
        {
            return await db.Events.ToListAsync();
        })
        .WithName("GetAllEvents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Event>, NotFound>> (int eventid, EventPlannerDbContext db) =>
        {
            return await db.Events.AsNoTracking()
                .FirstOrDefaultAsync(model => model.EventId == eventid)
                is Event model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetEventById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok<Event>, NotFound>> (int id, Event @event, EventPlannerDbContext db) =>
        {
            Event existingEvent = await db.Events.FindAsync(id);

            if (existingEvent is null)
            {
                return TypedResults.NotFound();
            }

            existingEvent.EventName = @event.EventName;
            existingEvent.EventDate = @event.EventDate;

            db.SaveChanges();
            return TypedResults.Ok(existingEvent);
        })
        .WithName("UpdateEvent")
        .WithOpenApi();

        group.MapPost("/", async (Event @event, EventPlannerDbContext db) =>
        {
            db.Events.Add(@event);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Event/{@event.EventId}",@event);
        })
        .WithName("CreateEvent")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int eventid, EventPlannerDbContext db) =>
        {
            var affected = await db.Events
                .Where(model => model.EventId == eventid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteEvent")
        .WithOpenApi();
    }
}
