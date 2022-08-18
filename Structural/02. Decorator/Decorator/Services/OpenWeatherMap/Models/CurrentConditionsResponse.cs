using Newtonsoft.Json;

namespace Decorator.Services.OpenWeatherMap.Models
{
    public class CurrentConditionsResponse
    {
        /// <summary>
        /// A description of any error that occured
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("id")]
        public int CityId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coordinates Coordintates { get; set; }

        [JsonProperty("dt")]
        public int ObservationTime { get; set; }

        [JsonProperty("weather")]
        public ObservedConditions[] ObservedConditions { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("rain")]
        public RainData Rain { get; set; }

        [JsonProperty("main")]
        public ObservationData ObservationData { get; set; }

        [JsonProperty("wind")]
        public WindData WindData { get; set; }

        [JsonProperty("sys")]
        public LocationDetails LocationDetails { get; set; }

        [JsonProperty("timezone")]
        public int TimezoneOffset { get; set; }
    }
}
