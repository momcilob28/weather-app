using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherApp.Domain.Services;
using WeatherApp.Infrastructure.Services;


public class Program
{
    public static async Task Main(string[] args)
    {
        var weatherstackUrl = Environment.GetEnvironmentVariable("WEATHERSTACK_URL")!;
        var host = new HostBuilder()
            .ConfigureFunctionsWebApplication()
            .ConfigureServices(services =>
            {
                services.AddApplicationInsightsTelemetryWorkerService();
                services.ConfigureFunctionsApplicationInsights();

                services.AddMediatR(config => config.RegisterServicesFromAssembly(WeatherApp.Application.Reference.Assembly));

                services.AddScoped<IWeatherService, WeatherService>();

                services.AddHttpClient<IWeatherService, WeatherService>(client =>
                {
                    client.BaseAddress = new Uri(weatherstackUrl);
                });
            })
            .Build();

        await host.RunAsync();
    }
}
