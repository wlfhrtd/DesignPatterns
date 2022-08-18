using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class OpenWeatherForecastWeatherData
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }

        [JsonProperty("Pressure")]
        public float pressure { get; set; }
        public float sea_level { get; set; }
        public float grnd_level { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
