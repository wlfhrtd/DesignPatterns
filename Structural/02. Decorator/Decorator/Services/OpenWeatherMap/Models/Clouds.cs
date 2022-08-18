using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int CloudCover { get; set; }
    }
}
