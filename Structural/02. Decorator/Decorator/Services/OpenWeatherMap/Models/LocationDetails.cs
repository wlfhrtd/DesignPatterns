using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class LocationDetails
    {
        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }
}
