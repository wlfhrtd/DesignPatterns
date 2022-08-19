using Flyweight.Interfaces;
using System;
using System.Collections.Generic;

namespace Flyweight.Models.Flyweights
{
    public class BananaSmoothie : IDrinkFlyweight
    {
        private string name;

        private IEnumerable<string> ingredients;

        public BananaSmoothie()
        {
            name = "Banana Smoothie";
            ingredients = new List<string>()
            {
                "Banana",
                "Whole Milk",
                "Vanilla Extract",
            };
        }


        public string Name => name;

        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {name} with {string.Join(", ", ingredients)} coming up!");
        }
    }
}
