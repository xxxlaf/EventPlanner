using Microsoft.EntityFrameworkCore;
using EventPlanner.Database;
using EventPlanner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EventPlanner.Controllers;

public static class AttendeeEndpoints
{
    public static void MapAttendeeEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Attendee").WithTags(nameof(Attendee));

        group.MapGet("/", async (EventPlannerDbContext db) =>
        {
            return await db.Attendees.ToListAsync();
        })
        .WithName("GetAllAttendees")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Attendee>, NotFound>> (int attendeeid, EventPlannerDbContext db) =>
        {
            return await db.Attendees.AsNoTracking()
                .FirstOrDefaultAsync(model => model.AttendeeId == attendeeid)
                is Attendee model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAttendeeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int attendeeid, Attendee @attendee, EventPlannerDbContext db) =>
        {
            var affected = await db.Attendees
                .Where(model => model.AttendeeId == attendeeid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.AttendeeId, @attendee.AttendeeId)
                    .SetProperty(m => m.EventId, @attendee.EventId)
                    .SetProperty(m => m.Name, @attendee.Name)
                    .SetProperty(m => m.Email, @attendee.Email)
                    .SetProperty(m => m.Phone, @attendee.Phone)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAttendee")
        .WithOpenApi();

        group.MapPost("/", async (Attendee @attendee, EventPlannerDbContext db) =>
        {
            db.Attendees.Add(@attendee);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Event/{@attendee.EventId}", @attendee);
        })
        .WithName("CreateAttendee")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int attendeeid, EventPlannerDbContext db) =>
        {
            var affected = await db.Attendees
                .Where(model => model.AttendeeId == attendeeid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAttendee")
        .WithOpenApi();
    }
}
