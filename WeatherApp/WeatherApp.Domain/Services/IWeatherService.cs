namespace WeatherApp.Domain.Services;
public interface IWeatherService
{
    Task<int> GetWeatherData(string city);
}
