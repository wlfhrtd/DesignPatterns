using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class Coordinates
    {
        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("lat")]
        public float Latitude { get; set; }
    }
}
