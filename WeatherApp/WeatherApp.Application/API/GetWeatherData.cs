using MediatR;
using WeatherApp.Domain.Services;

namespace WeatherApp.Application.API;
public sealed record GetWeatherDataQueryRequest : IRequest<GetWeatherDataQueryResponse>
{
    public string? City { get; set; }
}

public sealed class GetWeatherDataQueryResponse
{
    public string? ObservationTime { get; set; }
    public int Temperature { get; set; }
    public int WeatherCode { get; set; }
    public string[]? WeatherIcons { get; set; }
    public string[]? WeatherDescriptions { get; set; }
    public int WindSpeed { get; set; }
    public int WindDegree { get; set; }
    public string? WindDirection { get; set; }
    public int Pressure { get; set; }
    public int Precipitation { get; set; }
    public int Humidity { get; set; }
    public int Cloudcover { get; set; }
    public int Feelslike { get; set; }
    public int UVIndex { get; set; }
    public int Visibility { get; set; }
}

public class GetWeatherDataQueryHandler(IWeatherService _weatherService) : IRequestHandler<GetWeatherDataQueryRequest, GetWeatherDataQueryResponse>
{
    public async Task<GetWeatherDataQueryResponse> Handle(GetWeatherDataQueryRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.City, nameof(request.City));

        var weatherData = await _weatherService.GetWeatherData(city: request.City);

        return new GetWeatherDataQueryResponse
        {
            ObservationTime = weatherData.ObservationTime,
            Temperature = weatherData.Temperature,
            WeatherCode = weatherData.WeatherCode,
            WeatherIcons = weatherData.WeatherIcons,
            WeatherDescriptions = weatherData.WeatherDescriptions,
            WindSpeed = weatherData.WindSpeed,
            WindDegree = weatherData.WindDegree,
            WindDirection = weatherData.WindDirection,
            Pressure = weatherData.Pressure,
            Precipitation = weatherData.Precipitation,
            Humidity = weatherData.Humidity,
            Cloudcover = weatherData.Cloudcover,
            Feelslike = weatherData.Feelslike,
            UVIndex = weatherData.UVIndex,
            Visibility = weatherData.Visibility
        };
    }
}