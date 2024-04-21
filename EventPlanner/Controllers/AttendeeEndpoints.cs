using Microsoft.EntityFrameworkCore;
using EventPlanner.Database;
using EventPlanner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
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

        group.MapGet("/{id}", async Task<Results<Ok<Attendee>, NotFound>> (int id, EventPlannerDbContext db) =>
        {
            return await db.Attendees.AsNoTracking()
                .FirstOrDefaultAsync(model => model.AttendeeId == id)
                is Attendee model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAttendeeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok<Attendee>, NotFound>> (int id, Attendee @attendee, EventPlannerDbContext db) =>
        {
            Attendee existingAttendee = await db.Attendees.FindAsync(id);

            if (existingAttendee is null)
            {
                return TypedResults.NotFound();
            }

            existingAttendee.Name = @attendee.Name;
            existingAttendee.Email = @attendee.Email;
            existingAttendee.Phone = @attendee.Phone;

            db.SaveChanges();
            return TypedResults.Ok(existingAttendee);
        })
        .WithName("UpdateAttendee")
        .WithOpenApi();

        group.MapPost("/", async (Attendee @attendee, EventPlannerDbContext db) =>
        {
            db.Attendees.Add(@attendee);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Attendee/{@attendee.AttendeeId}", @attendee);
        })
        .WithName("CreateAttendee")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EventPlannerDbContext db) =>
        {
            var affected = await db.Attendees
                .Where(model => model.AttendeeId == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAttendee")
        .WithOpenApi();
    }
}