using MediatR;
using WeatherApp.Domain.Services;

namespace WeatherApp.Application;
public sealed record GetWeatherDataQueryRequest : IRequest<GetWeatherDataQueryResponse>
{
    public string? City { get; set; }
}

public sealed class GetWeatherDataQueryResponse
{
    public int Temperature { get; set; }
}

public class GetWeatherDataQueryHandler(IWeatherService _weatherService) : IRequestHandler<GetWeatherDataQueryRequest, GetWeatherDataQueryResponse>
{
    public async Task<GetWeatherDataQueryResponse> Handle(GetWeatherDataQueryRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.City, nameof(request.City));

        var temperature = await _weatherService.GetWeatherData(city: request.City);

        return new GetWeatherDataQueryResponse
        {
            Temperature = temperature
        };
    }
}