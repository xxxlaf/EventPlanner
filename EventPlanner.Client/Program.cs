using EventPlanner.Client.Pages;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var uri = new Uri("https://localhost:7276/");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<Home>("Home");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = uri });

await builder.Build().RunAsync();