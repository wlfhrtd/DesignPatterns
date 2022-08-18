using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastSnow
    {
        [JsonProperty("3h")]
        public float SnowfallThreeHours { get; set; }
    }
}
