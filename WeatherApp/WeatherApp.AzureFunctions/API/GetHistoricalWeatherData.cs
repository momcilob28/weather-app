using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using WeatherApp.Application;
using WeatherApp.Application.API;

namespace WeatherApp.AzureFunctions.API;
public class GetHistoricalWeatherData(IMediator _mediator)
{
    [Function("get-historical-weather-data")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, string city, string date)
    {
        try
        {
            ValidateRequest(city, date);

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


    private static void ValidateRequest(string city, string date)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ValidationException("City cannot be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(date))
        {
            throw new ValidationException("Date cannot be null or empty.");
        }

        if (!Regex.IsMatch(date, @"^\d{4}-\d{2}-\d{2}$"))
        {
            throw new ValidationException("Date must be in the format yyyy-MM-dd.");
        }

        if (!DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
        {
            throw new ValidationException("Date is not a valid date.");
        }

        if (parsedDate > DateTime.UtcNow.Date)
        {
            throw new ValidationException("Date cannot be in the future.");
        }
    }
}
