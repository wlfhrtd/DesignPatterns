using Decorator.Services.WeatherInterface.Models;
using System;

namespace Decorator.Services.WeatherInterface
{
    public class CurrentWeather
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public LocationData Location { get; set; }

        public DateTime ObservationTime { get; set; }

        public DateTime ObservationTimeUtc { get; set; }

        public WeatherData CurrentConditions { get; set; }

        public DateTime FetchTime { get; set; }
    }
}
