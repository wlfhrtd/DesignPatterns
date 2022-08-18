using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class RainData
    {
        [JsonProperty("1h")]
        public double RainfallOneHour { get; set; }
    }
}
