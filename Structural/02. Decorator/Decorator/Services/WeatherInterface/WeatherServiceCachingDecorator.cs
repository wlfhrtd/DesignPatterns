using Microsoft.Extensions.Caching.Memory;
using System;

namespace Decorator.Services.WeatherInterface
{
    public class WeatherServiceCachingDecorator : IWeatherService
    {
        private IWeatherService innerWeatherService;
        private IMemoryCache cache;

        public WeatherServiceCachingDecorator(IWeatherService weatherService, IMemoryCache memoryCache)
        {
            innerWeatherService = weatherService;
            cache = memoryCache;
        }


        public CurrentWeather GetCurrentWeather(string location)
        {
            string cacheKey = $"WeatherConditions::{location}";

            if (cache.TryGetValue<CurrentWeather>(cacheKey, out var currentWeather))
            {
                return currentWeather;
            }
            else
            {
                var currentConditions = innerWeatherService.GetCurrentWeather(location);
                cache.Set(cacheKey, currentConditions, TimeSpan.FromMinutes(30));

                return currentConditions;
            }
        }

        public LocationForecast GetForecast(string location)
        {
            string cacheKey = $"WeatherConditions::{location}";

            if (cache.TryGetValue<LocationForecast>(cacheKey, out var forecast))
            {
                return forecast;
            }
            else
            {
                var locationForecast = innerWeatherService.GetForecast(location);
                cache.Set(cacheKey, locationForecast, TimeSpan.FromMinutes(30));

                return locationForecast;
            }
        }
    }
}
