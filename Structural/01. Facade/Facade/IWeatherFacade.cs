using Facade.Models;

namespace Facade
{
    public interface IWeatherFacade
    {
        WeatherFacadeResult GetTempInCity(string zipCode);
    }
}
