using Newtonsoft.Json;

namespace WeatherApp.Infrastructure.Dtos;
public sealed record WeatherDataDto
{
    public CurrentWeatherDto? Current { get; set; }
}

public sealed record CurrentWeatherDto
{
    [JsonProperty("observation_time")]
    public string? ObservationTime { get; set; }

    [JsonProperty("temperature")]
    public int Temperature { get; set; }

    [JsonProperty("weather_code")]
    public int WeatherCode { get; set; }

    [JsonProperty("weather_icons")]
    public string[]? WeatherIcons { get; set; }

    [JsonProperty("weather_descriptions")]
    public string[]? WeatherDescriptions { get; set; }

    [JsonProperty("wind_speed")]
    public int WindSpeed { get; set; }

    [JsonProperty("wind_degree")]
    public int WindDegree { get; set; }

    [JsonProperty("wind_dir")]
    public string? WindDirection { get; set; }

    [JsonProperty("pressure")]
    public int Pressure { get; set; }

    [JsonProperty("precip")]
    public int Precipitation { get; set; }

    [JsonProperty("humidity")]
    public int Humidity { get; set; }

    [JsonProperty("cloudcover")]
    public int Cloudcover { get; set; }

    [JsonProperty("feelslike")]
    public int Feelslike { get; set; }

    [JsonProperty("uv_index")]
    public int UVIndex { get; set; }

    [JsonProperty("visibility")]
    public int Visibility { get; set; }
}
