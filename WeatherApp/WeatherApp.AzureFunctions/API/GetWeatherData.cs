using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeatherApp.Application;

namespace WeatherApp.AzureFunctions.API;
public class GetWeatherData(IMediator _mediator, ILogger<GetWeatherData> _logger)
{

    [Function("get-weather-data")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous,
        "get", Route = "weather")]  HttpRequest req, string city)
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
            _logger.LogError(ex, ex.Message);

            return new BadRequestObjectResult(ex.Message);
        }
    }
}