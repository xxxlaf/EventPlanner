using EventPlanner.Client.Pages;
using Microsoft.FluentUI.AspNetCore.Components;
using EventPlanner.Components;
using EventPlanner.Database;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Controllers;

var uri = new Uri("https://localhost:7276/");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddDbContext<EventPlannerDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventPlannerDb"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = uri });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//};

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.MapControllers();

app.MapEventEndpoints();
app.MapAttendeeEndpoints();
app.MapVenueEndpoints();
app.MapOrganizerEndpoints();
app.MapTaskItemEndpoints();

app.Run();
