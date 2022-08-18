using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class ObservedConditions
    {
        [JsonProperty("id")]
        public int DescriptionId { get; set; }

        [JsonProperty("main")]
        public string Conditions { get; set; }

        [JsonProperty("description")]
        public string ConditionsDetail { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
