using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastRain
    {
        [JsonProperty("3h")]
        public float RainfallThreeHours { get; set; }
    }
}
