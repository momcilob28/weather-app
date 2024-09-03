using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using WeatherApp.Application;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp.AzureFunctions.API;
public class GetWeatherData(IMediator _mediator)
{
    [Function("get-weather-data")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, string city)
    {
        try
        {
            ValidateRequest(city);

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


    private static void ValidateRequest(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ValidationException("City cannot be null or empty.");
        }
    }
}
