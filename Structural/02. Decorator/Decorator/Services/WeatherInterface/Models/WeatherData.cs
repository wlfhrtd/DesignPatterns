namespace Decorator.Services.WeatherInterface.Models
{
    public class WeatherData
    {
        public string Conditions { get; set; }

        public string ConditionsDescription { get; set; }

        public double Visibility { get; set; }

        public int CloudCover { get; set; }

        public double Temperature { get; set; }

        public double Pressure { get; set; }

        public double Humidity { get; set; }

        public double WindSpeed { get; set; }

        public CompassDirection WindDirection { get; set; }

        public double WindDirectionDegrees { get; set; }

        public double RainfallOneHour { get; set; }
    }
}
