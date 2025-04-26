using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StarWars.Explorer;
using StarWars.Explorer.Infrastructure;
using StarWars.Explorer.Services;
using StarWars.Explorer.Services.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register exception handlers
builder.Services.AddSingleton<IExceptionInterceptor, GlobalExceptionInterceptor>();
builder.Services.AddTransient<GlobalExceptionHandler>();

// Register HttpClient with the exception handler properly configured
builder.Services.AddScoped(sp =>
{
    // Get the exception handler
    var exceptionHandler = sp.GetRequiredService<GlobalExceptionHandler>();

    // Set the inner handler
    exceptionHandler.InnerHandler = new HttpClientHandler();

    // Create HttpClient with the handler
    var httpClient = new HttpClient(exceptionHandler)
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    };

    return httpClient;
});

builder.Services.AddScoped<SwapiTechServiceHelper>();
builder.Services.AddScoped<ISwapiService, SwapiService>();

await builder.Build().RunAsync();