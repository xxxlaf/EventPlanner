using EventPlanner.Client.Pages;
using Microsoft.FluentUI.AspNetCore.Components;
using EventPlanner.Components;
using EventPlanner.Database;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Models;
using EventPlanner.Entities;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddDbContext<EventPlannerDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("sqlite");
    options.UseSqlite();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

# region API Mapping
app.MapGet("/api/events", async (EventPlannerDbContext eventPlannerDbContext) =>
{
    var events = await eventPlannerDbContext.Events.ToListAsync();
    List<EventViewModel> eventViewModels = new();

    foreach(var objEvent in events)
    {
        eventViewModels.Add(new EventViewModel
        {
            EventId = objEvent.EventId,
            EventName = objEvent.EventName,
            EventDescription = objEvent.EventDescription,
            Location = objEvent.Location,
            StartDate = objEvent.StartDate,
            EndDate = objEvent.EndDate
        });
    }

    return Results.Ok(eventViewModels);
});

app.MapGet("/api/events/{id}", async (EventPlannerDbContext eventPlannerDbContext, int id) =>
{
    // Had to rename to "objEvent" from "event", because "event" is a reserved word in C#.
    var objEvent = await eventPlannerDbContext.Events.FindAsync(id);
    if (objEvent == null)
    {
        return Results.NotFound();
    }

    EventViewModel eventViewModel = new()
    {
        EventId = objEvent.EventId,
        EventName = objEvent.EventName,
        EventDescription = objEvent.EventDescription,
        Location = objEvent.Location,
        StartDate = objEvent.StartDate,
        EndDate = objEvent.EndDate
    };

    return Results.Ok(eventViewModel);
});

app.MapPost("/api/events", async (EventPlannerDbContext eventPlannerDbContext, EventViewModel eventViewModel) =>
{
    Event objEvent = new()
    {
        EventId = eventViewModel.EventId,
        EventName = eventViewModel.EventName,
        EventDescription = eventViewModel.EventDescription,
        Location = eventViewModel.Location,
        StartDate = eventViewModel.StartDate,
        EndDate = eventViewModel.EndDate
    };

    await eventPlannerDbContext.Events.AddAsync(objEvent);
    await eventPlannerDbContext.SaveChangesAsync();
    return Results.Created($"/api/events/{objEvent.EventId}", objEvent);
});

app.MapPut("/api/events/{id}", async (EventPlannerDbContext eventPlannerDbContext, int id, EventViewModel eventViewModel) =>
{
    var objEvent = await eventPlannerDbContext.Events.FindAsync(id);
    if (objEvent == null)
    {
        return Results.NotFound();
    }

    objEvent.EventId = eventViewModel.EventId;
    objEvent.EventName = eventViewModel.EventName;
    objEvent.EventDescription = eventViewModel.EventDescription;
    objEvent.Location = eventViewModel.Location;
    objEvent.StartDate = eventViewModel.StartDate;
    objEvent.EndDate = eventViewModel.EndDate;

    await eventPlannerDbContext.SaveChangesAsync();
    return Results.Ok(objEvent);
});

app.MapDelete("/api/events/{id}", async (EventPlannerDbContext eventPlannerDbContext, int id) =>
{
    var objEvent = await eventPlannerDbContext.Events.FindAsync(id);
    if (objEvent == null)
    {
        return Results.NotFound();
    }

    eventPlannerDbContext.Events.Remove(objEvent);
    await eventPlannerDbContext.SaveChangesAsync();
    return Results.Ok();
});
#endregion

app.Run();
