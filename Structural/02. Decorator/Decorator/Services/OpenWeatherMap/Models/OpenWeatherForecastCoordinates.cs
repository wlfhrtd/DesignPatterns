using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastCoordinates
    {
        [JsonProperty("lat")]
        public float Latitude { get; set; }

        [JsonProperty("lon")]
        public float Longitude { get; set; }
    }
}
