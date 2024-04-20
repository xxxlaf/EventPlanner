using Microsoft.EntityFrameworkCore;
using EventPlanner.Database;
using EventPlanner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace EventPlanner.Controllers;

public static class OrganizerEndpoints
{
    public static void MapOrganizerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Organizer").WithTags(nameof(Organizer));

        group.MapGet("/", async (EventPlannerDbContext db) =>
        {
            return await db.Organizers.ToListAsync();
        })
        .WithName("GetAllOrganizers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Organizer>, NotFound>> (int id, EventPlannerDbContext db) =>
        {
            return await db.Organizers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.OrganizerId == id)
                is Organizer model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetOrganizerById")
        .WithOpenApi();

        group.MapPost("/", async (Organizer @organizer, EventPlannerDbContext db) =>
        {
            db.Organizers.Add(@organizer);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Organizer/{@organizer.OrganizerId}", @organizer);
        })
        .WithName("CreateOrganizer")
        .WithOpenApi();
    }
}
