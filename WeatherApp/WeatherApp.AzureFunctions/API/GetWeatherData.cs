using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using WeatherApp.Application;

namespace WeatherApp.AzureFunctions.API;
public class GetWeatherData(IMediator _mediator)
{
    [Function("get-weather-data")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, string city)
    {
        try
        {
            var request = new GetWeatherDataQueryRequest
            {
                City = city
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
