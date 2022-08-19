using Flyweight.Interfaces;
using System;

namespace Flyweight.Models.Flyweights
{
    // unshared concrete Flyweight
    public class DrinkGiveaway : IDrinkFlyweight
    {
        // All/mixed state
        private IDrinkFlyweight[] eligibleDrinks;

        private IDrinkFlyweight randomDrink;

        private string size;

        public DrinkGiveaway()
        {
            eligibleDrinks = new IDrinkFlyweight[]
            {
                new Espresso(),
                new BananaSmoothie(),
            };
            randomDrink = eligibleDrinks[new Random().Next(0, 2)];
        }

        // intrinsic
        public string Name => randomDrink.Name;
        // Extrinsic state
        public void Serve(string drinkSize)
        {
            size = drinkSize;
            Console.WriteLine($"Free Giveaway!");
            Console.WriteLine($"- {size} {randomDrink.Name} coming up!");
        }
    }
}
