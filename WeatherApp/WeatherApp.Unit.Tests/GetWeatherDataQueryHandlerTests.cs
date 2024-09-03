using FluentAssertions;
using WeatherApp.Application.API;
using WeatherApp.Domain.Services;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.Unit.Tests;
public class GetWeatherDataQueryHandlerTests
{
    private readonly HttpClient _httpClient;
    private readonly GetWeatherDataQueryHandler _handler;
    private readonly IWeatherService _weatherService;

    public GetWeatherDataQueryHandlerTests()
    {
        Environment.SetEnvironmentVariable("WEATHERSTACK_ACCESS_KEY", "YOUR_API_KEY");

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://api.weatherstack.com/")
        };

        _weatherService = new WeatherService(_httpClient);

        _handler = new GetWeatherDataQueryHandler(_weatherService);
    }

    [Fact]
    public async Task Should_get_weather_data()
    {
        // Arrange

        var request = new GetWeatherDataQueryRequest
        {
            City = "Belgrade"
        };

        // Act

        var response = await _handler.Handle(request, CancellationToken.None);

        // Assert

        response.Should()
            .NotBeNull();
    }
}
