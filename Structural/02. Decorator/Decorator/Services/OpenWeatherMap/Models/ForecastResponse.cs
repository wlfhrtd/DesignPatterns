using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class ForecastResponse
    {
        public string cod { get; set; }
        public float message { get; set; }

        [JsonProperty("list")]
        public OpenWeatherForecastData[] ForecastPoints { get; set; }

        [JsonProperty("city")]
        public OpenWeatherForecastLocation Location { get; set; }
    }
}
