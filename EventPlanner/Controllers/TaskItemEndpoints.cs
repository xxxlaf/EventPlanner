using Microsoft.EntityFrameworkCore;
using EventPlanner.Database;
using EventPlanner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
namespace EventPlanner.Controllers;

public static class TaskItemEndpoints
{
    public static void MapTaskItemEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/TaskItem").WithTags(nameof(TaskItem));

        group.MapGet("/", async (EventPlannerDbContext db) =>
        {
            return await db.TaskItems.ToListAsync();
        })
        .WithName("GetAllTaskItems")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<TaskItem>, NotFound>> (int id, EventPlannerDbContext db) =>
        {
            return await db.TaskItems.AsNoTracking()
                .FirstOrDefaultAsync(model => model.TaskItemId == id)
                is TaskItem model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTaskItemById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok<TaskItem>, NotFound>> (int id, TaskItem @taskitem, EventPlannerDbContext db) =>
        {
            TaskItem existingTaskItem = await db.TaskItems.FindAsync(id);

            if (existingTaskItem is null)
            {
                return TypedResults.NotFound();
            }

            existingTaskItem.Description = @taskitem.Description;
            existingTaskItem.Deadline = @taskitem.Deadline;
            existingTaskItem.Status = @taskitem.Status;

            db.SaveChanges();
            return TypedResults.Ok(existingTaskItem);
        })
        .WithName("UpdateTaskItem")
        .WithOpenApi();

        group.MapPost("/", async (TaskItem @TaskItem, EventPlannerDbContext db) =>
        {
            db.TaskItems.Add(@TaskItem);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/TaskItem/{@TaskItem.TaskItemId}", @TaskItem);
        })
        .WithName("CreateTaskItem")
        .WithOpenApi();
    }
}
