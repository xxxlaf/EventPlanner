using EventPlanner.Client.Pages;
using EventPlanner.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var uri = new Uri("https://localhost:7276/");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Home>("Home");

<<<<<<< HEAD

builder.Services.AddTransient<EventService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
=======
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = uri });
>>>>>>> master

await builder.Build().RunAsync();