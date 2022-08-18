using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class ObservationData
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_min")]
        public float MinTemperature { get; set; }

        [JsonProperty("temp_max")]
        public float MaxTemperature { get; set; }
    }
}
