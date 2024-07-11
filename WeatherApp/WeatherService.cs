using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "1ad9e8c6ddc6ea1d326a417c42552208";

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric";
            WeatherData weatherData = await _httpClient.GetFromJsonAsync<WeatherData>(apiUrl);
            return weatherData;
        }
    }
}
