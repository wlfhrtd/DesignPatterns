using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastWind
    {
        [JsonProperty("speed")]
        public float WindSpeed { get; set; }

        [JsonProperty("deg")]
        public int WindDirectionDegrees { get; set; }
    }
}
