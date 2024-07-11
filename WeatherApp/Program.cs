using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WeatherService weatherService = new WeatherService();

            Console.WriteLine("Podaj nazwę miasta:");
            string city = Console.ReadLine();

            if (!string.IsNullOrEmpty(city))
            {
                WeatherData weatherData = await weatherService.GetWeatherAsync(city);
                DisplayWeather(weatherData, city);
            }
            else
            {
                Console.WriteLine("Nazwa miasta nie może być pusta.");
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć");
            Console.ReadKey();
        }

        static void DisplayWeather(WeatherData weatherData, string city)
        {
            if (weatherData != null)
            {
                Console.WriteLine($"Pogoda w {city}:");
                Console.WriteLine($"Temperatura: {weatherData.Main.Temp}°C");
                Console.WriteLine($"Odczuwalna temperatura: {weatherData.Main.FeelsLike}°C");
                Console.WriteLine($"Ciśnienie: {weatherData.Main.Pressure} hPa");
                Console.WriteLine($"Wilgotność: {weatherData.Main.Humidity}%");
                Console.WriteLine($"Opis: {weatherData.Weather[0].Description}");
            }
            else
            {
                Console.WriteLine("Nie udało się pobrać danych");
            }
        }
    }
}
