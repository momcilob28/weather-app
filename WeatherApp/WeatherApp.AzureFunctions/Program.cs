using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using WeatherApp.Domain.Services;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.AzureFunctions;
public class Program
{
    public static async Task Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWebApplication()
            .ConfigureServices(services =>
            {
                //services.AddMediatR(config => config.RegisterServicesFromAssemblies(WeatherApp.Ass));

                services.AddScoped<IWeatherService, WeatherService>();
            })
            .Build();

        await host.RunAsync();
    }
}
