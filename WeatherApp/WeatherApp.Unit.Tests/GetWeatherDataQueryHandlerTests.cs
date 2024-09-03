using FluentAssertions;
using WeatherApp.Application.API;
using WeatherApp.Domain.Services;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.Unit.Tests;
public class GetWeatherDataQueryHandlerTests
{
    private readonly GetWeatherDataQueryHandler _handler;
    private readonly IWeatherService _weatherService;

    public GetWeatherDataQueryHandlerTests()
    {
        _weatherService = new WeatherService();

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
