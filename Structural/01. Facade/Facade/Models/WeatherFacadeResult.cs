using System;

namespace Facade.Models
{
    public class WeatherFacadeResult
    {
        public int Fahrenheit { get; set; }

        public int Celsius { get; set; }

        public City City { get; set; }

        public State State { get; set; }

        public void Print()
        {
            Console.WriteLine("The current temperature is {0}F/{1}C in {2}, {3}",
                    Fahrenheit,
                    Celsius,
                    City.Name,
                    State.Name);
        }
    }
}
