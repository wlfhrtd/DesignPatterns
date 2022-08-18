namespace Facade.Models
{
    public class City
    {
        public City GetCityForZipCode(string zipCode)
        {
            return new City();
        }

        public string Name => "Redmond";
    }
}
