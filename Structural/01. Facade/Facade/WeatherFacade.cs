using Facade.Models;
using Facade.Services;

namespace Facade
{
    public class WeatherFacade : IWeatherFacade
    {
        private readonly ConverterService converterService;
        private readonly GeoLookupService geoLookUpService;
        private readonly WeatherService weatherService;


        public WeatherFacade() :
            this(new ConverterService(), new GeoLookupService(), new WeatherService())
        { }

        public WeatherFacade(ConverterService converter,
                             GeoLookupService geoLookUp,
                             WeatherService weather)
        {
            converterService = converter;
            geoLookUpService = geoLookUp;
            weatherService = weather;
        }


        public WeatherFacadeResult GetTempInCity(string zipCode)
        {
            City city = geoLookUpService.GetCityForZipCode(zipCode);
            State state = geoLookUpService.GetStateForZipCode(zipCode);
            int tempF = weatherService.GetTempFahrenheit(city, state);
            int tempC = converterService.ConvertFahrenheitToCelsius(tempF);

            var result = new WeatherFacadeResult
            {
                City = city,
                State = state,
                Fahrenheit = tempF,
                Celsius = tempC,
            };

            return result;
        }
    }
}
