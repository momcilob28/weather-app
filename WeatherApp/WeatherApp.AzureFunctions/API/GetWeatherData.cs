using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using System;
using System.Threading.Tasks;
using WeatherApp.Application;

namespace WeatherApp.AzureFunctions.API;
public class GetWeatherData(/*ILogger<GetWeatherData> _logger*/)
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

            //var response = await _mediator.Send(request);

            return new OkObjectResult(/*response*/"asd");
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, ex.Message);

            return new BadRequestObjectResult(ex.Message);
        }
    }
}