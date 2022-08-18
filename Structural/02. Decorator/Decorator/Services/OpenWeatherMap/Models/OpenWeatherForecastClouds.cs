using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastClouds
    {
        [JsonProperty("all")]
        public int CloudCover { get; set; }
    }
}
