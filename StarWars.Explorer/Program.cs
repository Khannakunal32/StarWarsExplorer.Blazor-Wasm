using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using StarWars.Explorer;
using StarWars.Explorer.Infrastructure;
using StarWars.Explorer.Models.Configuration;
using StarWars.Explorer.Services;
using StarWars.Explorer.Services.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IExceptionInterceptor, GlobalExceptionInterceptor>();
builder.Services.AddTransient<GlobalExceptionHandler>();

builder.Services.AddScoped(sp =>
{
    var exceptionHandler = sp.GetRequiredService<GlobalExceptionHandler>();

    exceptionHandler.InnerHandler = new HttpClientHandler();

    var httpClient = new HttpClient(exceptionHandler)
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    };

    return httpClient;
});

var swapiConfigs = new SwapiConfig();
builder.Configuration.GetSection("SwapiConfig").Bind(swapiConfigs);

builder.Services.AddSingleton(swapiConfigs);

builder.Services.AddScoped<SwapiTechServiceHelper>();
builder.Services.AddScoped<ISwapiService, SwapiService>();

await builder.Build().RunAsync();