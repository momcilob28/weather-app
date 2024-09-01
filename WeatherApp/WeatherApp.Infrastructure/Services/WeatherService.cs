using Newtonsoft.Json;
using WeatherApp.Domain.Services;

namespace WeatherApp.Infrastructure.Services;
public class WeatherService : IWeatherService
{
    public async Task<int> GetWeatherData(string city)
    {
        using var httpclient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"http://api.weatherstack.com/current?access_key=???&query={city}")
        };

        var response = await httpclient.SendAsync(request);

        await ValidateResponse(response);

        var responseString = await response.Content.ReadAsStringAsync();

        var weatherData = JsonConvert.DeserializeObject<WeatherDataDto>(responseString)!;  

        return weatherData.Current.Temperature;
    }

    private async Task ValidateResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();

            throw new Exception(error);
        }
    }
}

public class WeatherDataDto
{
    public CurrentWeatherDto Current { get; set; }
}

public class CurrentWeatherDto
{
    public int Temperature { get; set; }
}