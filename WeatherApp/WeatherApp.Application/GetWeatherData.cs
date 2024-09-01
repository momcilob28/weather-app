using MediatR;

namespace WeatherApp.Application;
public sealed record GetWeatherDataQueryRequest : IRequest<GetWeatherDataQueryResponse>
{
    public string? City { get; set; }
}

public sealed class GetWeatherDataQueryResponse
{

}

public class GetWeatherDataQueryHandler : IRequestHandler<GetWeatherDataQueryRequest, GetWeatherDataQueryResponse>
{
    public Task<GetWeatherDataQueryResponse> Handle(GetWeatherDataQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}