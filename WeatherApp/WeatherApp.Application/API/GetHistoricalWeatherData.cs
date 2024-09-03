using MediatR;
using WeatherApp.Domain.Services;

namespace WeatherApp.Application.API;
public sealed record GetHistoricalWeatherDataRequest : IRequest<GetHistoricalWeatherDataQueryResponse>
{
    public string? City { get; set; }
    public string? Date { get; set; }
}

public sealed class GetHistoricalWeatherDataQueryResponse
{
    public string? Date { get; set; }
    public int MinimumTemperature { get; set; }
    public int MaximumTemperature { get; set; }
    public int AverageTemperature { get; set; }
    public int HoursOfSunshine { get; set; }
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
            Date = weatherData.Date,
            MinimumTemperature = weatherData.MinimumTemperature,
            MaximumTemperature = weatherData.MaximumTemperature,
            AverageTemperature = weatherData.AverageTemperature,
            HoursOfSunshine = weatherData.HoursOfSunshine
        };
    }
}