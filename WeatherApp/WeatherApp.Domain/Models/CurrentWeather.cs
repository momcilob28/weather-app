namespace WeatherApp.Domain.Models;
public class CurrentWeather
{
    public string? ObservationTime { get; set; }
    public int Temperature { get; set; }
    public int WeatherCode { get; set; }
    public string[]? WeatherIcons { get; set; }
    public string[]? WeatherDescriptions { get; set; }
    public int WindSpeed { get; set; }
    public int WindDegree { get; set; }
    public string? WindDirection { get; set; }
    public int Pressure { get; set; }
    public int Precipitation { get; set; }
    public int Humidity { get; set; }
    public int Cloudcover { get; set; }
    public int Feelslike { get; set; }
    public int UVIndex { get; set; }
    public int Visibility { get; set; }
}
