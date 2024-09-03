using MediatR;
using WeatherApp.Domain.Services;

public sealed record GetHistoricalWeatherDataRequest : IRequest<GetHistoricalWeatherDataQueryResponse>
{
    public string? City { get; set; }
    public string? Date { get; set; }
}

public sealed class GetHistoricalWeatherDataQueryResponse
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

public class GetHistoricalWeatherDataQueryHandler(IWeatherService _weatherService) : IRequestHandler<GetHistoricalWeatherDataRequest, GetHistoricalWeatherDataQueryResponse>
{
    public async Task<GetHistoricalWeatherDataQueryResponse> Handle(GetHistoricalWeatherDataRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.City, nameof(request.City));
        ArgumentNullException.ThrowIfNull(request.Date, nameof(request.Date));

        var weatherData = await _weatherService.GetHistoricalWeatherData(city: request.City, date: request.Date);

        return new GetHistoricalWeatherDataQueryResponse
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