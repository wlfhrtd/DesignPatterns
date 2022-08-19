using Flyweight.Interfaces;
using Flyweight.Models.Flyweights;
using System;
using System.Collections.Generic;

namespace Flyweight.Models.Factories
{
    public class DrinkFactory
    {
        private Dictionary<string, IDrinkFlyweight> drinkCache;

        private int objectsCreated;

        public DrinkFactory()
        {
            drinkCache = new();
            objectsCreated = 0;
        }


        public IDrinkFlyweight GetDrink(string drinkKey)
        {
            if (drinkCache.ContainsKey(drinkKey))
            {
                Console.WriteLine("\nReusing existing flyweight object.");
                return drinkCache[drinkKey];
            }

            Console.WriteLine("\nCreating new flyweight object.");

            IDrinkFlyweight drink = drinkKey switch
            {
                "Espresso" => new Espresso(),
                "BananaSmoothie" => new BananaSmoothie(),
                _ => throw new ArgumentException("This is not a flyweight drink object.", nameof(drinkKey)),
            };

            drinkCache.Add(drinkKey, drink);
            objectsCreated++;

            return drink;
        }

        public IDrinkFlyweight CreateGiveaway()
        {
            return new DrinkGiveaway();
        }

        public void PrintDrinks()
        {
            Console.WriteLine($"\nFactory has {drinkCache.Count} drink objects ready to use.");
            Console.WriteLine($"Number of objects created: {objectsCreated}");

            foreach (var drink in drinkCache) Console.WriteLine($"\t{drink.Value.Name}");

            Console.WriteLine();
        }
    }
}
