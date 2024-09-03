using Newtonsoft.Json;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Services;
using WeatherApp.Infrastructure.Dtos;

namespace WeatherApp.Infrastructure.Services;
public class WeatherService(HttpClient httpClient) : IWeatherService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _accessKey = Environment.GetEnvironmentVariable("WEATHERSTACK_ACCESS_KEY")
            ?? throw new InvalidOperationException("Missing api key");

    public async Task<CurrentWeather> GetWeatherData(string city)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_httpClient.BaseAddress}/current?access_key={_accessKey}&query={city}")
        };

        var response = await _httpClient.SendAsync(request);

        await ValidateResponse(response);

        var responseString = await response.Content.ReadAsStringAsync();

        var weatherData = JsonConvert.DeserializeObject<WeatherDataDto>(responseString)?.Current
            ?? throw new InvalidOperationException($"Weather data could not be found for city: {city}.");

        return MapToCurrentWeather(weatherData);
    }

    public async Task<HistoricalWeather> GetHistoricalWeatherData(string city, string date)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_httpClient.BaseAddress}/historical?access_key={_accessKey}&query={city}&historical_date={date}")
        };

        var response = await _httpClient.SendAsync(request);

        await ValidateResponse(response);

        var responseString = await response.Content.ReadAsStringAsync();

        var weatherData = JsonConvert.DeserializeObject<WeatherDataDto>(responseString)!.Historical
            ?? throw new InvalidOperationException($"Weather data could not be found for city: {city} and date: {date}.");

        var singleDayWeather = weatherData[date];

        return MapToHistoricalWeather(singleDayWeather);
    }


    private static async Task ValidateResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();

            throw new Exception(error);
        }
    }

    private static CurrentWeather MapToCurrentWeather(CurrentWeatherDto weatherData)
    {
        return new CurrentWeather
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

    private static HistoricalWeather MapToHistoricalWeather(HistoricalWeatherDto dateWeather)
    {
        return new HistoricalWeather
        {
            Date = dateWeather.Date,
            MinimumTemperature = dateWeather.MinimumTemperature,
            MaximumTemperature = dateWeather.MaximumTemperature,
            AverageTemperature = dateWeather.AverageTemperature,
            HoursOfSunshine = dateWeather.HoursOfSunshine
        };
    }
}