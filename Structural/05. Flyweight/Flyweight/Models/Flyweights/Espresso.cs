using Flyweight.Interfaces;
using System;
using System.Collections.Generic;

namespace Flyweight.Models.Flyweights
{
    public class Espresso : IDrinkFlyweight
    {
        private string name;

        private IEnumerable<string> ingredients;

        public Espresso()
        {
            name = "Espresso";
            ingredients = new List<string>()
            {
                "Coffee Beans",
                "Hot Water",
            };
        }


        public string Name => name;

        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {name} with {string.Join(", ", ingredients)} coming up!");
        }
    }
}
