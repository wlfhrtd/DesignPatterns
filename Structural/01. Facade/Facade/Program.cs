using Facade.Models;
using Facade.Services;
using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            const string zipCode = "98074";

            GeoLookupService geoLookupService = new GeoLookupService();
            City city = geoLookupService.GetCityForZipCode(zipCode);
            State state = geoLookupService.GetStateForZipCode(zipCode);

            WeatherService weatherService = new WeatherService();
            int fahrenheit = weatherService.GetTempFahrenheit(city, state);

            ConverterService metricConverter = new ConverterService();
            int celcius = metricConverter.ConvertFahrenheitToCelsius(fahrenheit);

            Console.WriteLine("The current temperature is {0} F / {1} C in {2}, {3}",
                                fahrenheit,
                                celcius,
                                city.Name,
                                state.Name);
            Console.WriteLine("***** EOF *****");

            IWeatherFacade weatherFacade = new WeatherFacade();
            WeatherFacadeResult result = weatherFacade.GetTempInCity(zipCode);
            result.Print();
        }
    }
}
