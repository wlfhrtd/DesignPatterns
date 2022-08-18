using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastLocation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public OpenWeatherForecastCoordinates Coordinates { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("timezone")]
        public int TimezoneOffset { get; set; }
    }
}
