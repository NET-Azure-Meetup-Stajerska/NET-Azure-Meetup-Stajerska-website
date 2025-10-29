using MeetupWebsite.Services;
using MeetupWebsite.Sessionize;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MeetupWebsite;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // Load configuration from wwwroot/appsettings.json
        var http = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped<SessionizeClient>();
        builder.Services.AddScoped<EventsRepository>();

        await builder.Build().RunAsync();
    }
}
