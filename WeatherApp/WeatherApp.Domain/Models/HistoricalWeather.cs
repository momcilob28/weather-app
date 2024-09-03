namespace WeatherApp.Domain.Models;
public class HistoricalWeather
{
    public string? Date { get; set; }
    public int MinimumTemperature { get; set; }
    public int MaximumTemperature { get; set; }
    public int AverageTemperature { get; set; }
    public int HoursOfSunshine { get; set; }
}
