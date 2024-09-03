using FluentAssertions;
using WeatherApp.Application;
using WeatherApp.Domain.Services;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.Unit.Tests;
public class GetHistoricalWeatherDataQueryHandlerTests
{
    private readonly GetHistoricalWeatherDataQueryHandler _handler;
    private readonly IWeatherService _weatherService;

    public GetHistoricalWeatherDataQueryHandlerTests()
    {
        _weatherService = new WeatherService();

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