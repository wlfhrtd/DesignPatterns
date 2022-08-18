using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastData
    {
        [JsonProperty("dt")]
        public int Date { get; set; }

        [JsonProperty("main")]
        public OpenWeatherForecastWeatherData WeatherData { get; set; }

        [JsonProperty("weather")]
        public OpenWeatherForecastConditions[] Conditions { get; set; }

        [JsonProperty("clouds")]
        public OpenWeatherForecastClouds Clouds { get; set; }

        [JsonProperty("wind")]
        public OpenWeatherForecastWind Wind { get; set; }
        public string dt_txt { get; set; }

        [JsonProperty("rain")]
        public OpenWeatherForecastRain Rain { get; set; }

        [JsonProperty("snow")]
        public OpenWeatherForecastSnow Snow { get; set; }
    }
}
