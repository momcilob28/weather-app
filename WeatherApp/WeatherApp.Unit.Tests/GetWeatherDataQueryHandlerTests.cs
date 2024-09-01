using FluentAssertions;
using WeatherApp.Application;

namespace WeatherApp.Unit.Tests;
public class GetWeatherDataQueryHandlerTests
{
    private readonly GetWeatherDataQueryHandler _handler;

    public GetWeatherDataQueryHandlerTests()
    {
        _handler = new GetWeatherDataQueryHandler();
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
