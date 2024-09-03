using FluentAssertions;
using WeatherApp.Application.API;
using WeatherApp.Domain.Services;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.Unit.Tests;
public class GetHistoricalWeatherDataQueryHandlerTests
{
    private readonly HttpClient _httpClient;
    private readonly GetHistoricalWeatherDataQueryHandler _handler;
    private readonly IWeatherService _weatherService;

    public GetHistoricalWeatherDataQueryHandlerTests()
    {
        Environment.SetEnvironmentVariable("WEATHERSTACK_ACCESS_KEY", "YOUR_API_KEY");

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://api.weatherstack.com/")
        };

        _weatherService = new WeatherService(_httpClient);

        _handler = new GetHistoricalWeatherDataQueryHandler(_weatherService);
    }

    [Fact]
    public async Task Should_get_weather_data()
    {
        // Arrange

        var request = new GetHistoricalWeatherDataRequest
        {
            City = "Belgrade",
            Date = "2022-03-03"
        };

        // Act

        var response = await _handler.Handle(request, CancellationToken.None);

        // Assert

        response.Should()
            .NotBeNull();
    }
}