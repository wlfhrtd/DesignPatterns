using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class WindData
    {
        [JsonProperty("speed")]
        public float Speed { get; set; }

        [JsonProperty("deg")]
        public int Degrees { get; set; }
    }
}
