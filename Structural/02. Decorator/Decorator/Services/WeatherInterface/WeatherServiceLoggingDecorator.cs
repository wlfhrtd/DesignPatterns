using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Decorator.Services.WeatherInterface
{
    // 1) should extend/implement same base as decorated class
    // 2) should contain decorated class instance
    // 3) should have at least default method implementations (to extend later)
    public class WeatherServiceLoggingDecorator : IWeatherService
    {
        private IWeatherService innerWeatherService;
        private ILogger<WeatherServiceLoggingDecorator> logger;

        public WeatherServiceLoggingDecorator(IWeatherService weatherService,
                                              ILogger<WeatherServiceLoggingDecorator> log)
        {
            innerWeatherService = weatherService;
            logger = log;
        }


        public CurrentWeather GetCurrentWeather(string location)
        {
            Stopwatch sw = Stopwatch.StartNew();
            CurrentWeather currentWeather = innerWeatherService.GetCurrentWeather(location);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            logger.LogWarning(
                "Retrieved weather data for {0} - Elapsed ms: {1} {2}",
                location, elapsedMillis, currentWeather);

            return currentWeather;
        }

        public LocationForecast GetForecast(string location)
        {
            Stopwatch sw = Stopwatch.StartNew();
            LocationForecast forecast = innerWeatherService.GetForecast(location);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            logger.LogWarning(
                "Retrieved forecast data for {0} - Elapsed ms: {1} {2}",
                location, elapsedMillis, forecast);

            return forecast;
        }
    }
}
