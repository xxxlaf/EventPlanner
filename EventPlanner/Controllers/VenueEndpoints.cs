using Microsoft.EntityFrameworkCore;
using EventPlanner.Database;
using EventPlanner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace EventPlanner.Controllers;

public static class VenueEndpoints
{
    public static void MapVenueEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Venue").WithTags(nameof(Venue));

        group.MapGet("/", async (EventPlannerDbContext db) =>
        {
            return await db.Venues.ToListAsync();
        })
        .WithName("GetAllVenues")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Venue>, NotFound>> (int id, EventPlannerDbContext db) =>
        {
            return await db.Venues.AsNoTracking()
                .FirstOrDefaultAsync(model => model.VenueId == id)
                is Venue model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetVenueById")
        .WithOpenApi();

        group.MapPost("/", async (Venue @venue, EventPlannerDbContext db) =>
        {
            db.Venues.Add(@venue);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Venue/{@venue.VenueId}", @venue);
        })
        .WithName("CreateVenue")
        .WithOpenApi();
    }
}
