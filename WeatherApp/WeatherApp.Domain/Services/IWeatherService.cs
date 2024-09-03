using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Services;
public interface IWeatherService
{
    Task<HistoricalWeather> GetHistoricalWeatherData(string city, string date);
    Task<CurrentWeather> GetWeatherData(string city);
}
