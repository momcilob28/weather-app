using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using WeatherApp.Application;

namespace WeatherApp.AzureFunctions.API;
public class GetHistoricalWeatherData(IMediator _mediator)
{
    [Function("get-historical-weather-data")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, string city, string date)
    {
        try
        {
            var request = new GetHistoricalWeatherDataRequest
            {
                City = city,
                Date = date
            };

            var response = await _mediator.Send(request);

            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
