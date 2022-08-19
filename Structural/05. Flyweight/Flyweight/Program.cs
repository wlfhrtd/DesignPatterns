using Flyweight.Models.Factories;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            var drinkFactory = new DrinkFactory();
            drinkFactory.PrintDrinks();
            // name is intrinsic and it is 'shared state', size is extrinsic and passed as method arg
            var largeEspresso = drinkFactory.GetDrink("Espresso");
            largeEspresso.Serve("Large");

            var mediumSmoothie = drinkFactory.GetDrink("BananaSmoothie");
            mediumSmoothie.Serve("Medium");

            var smallEspresso = drinkFactory.GetDrink("Espresso");
            smallEspresso.Serve("Small");

            drinkFactory.PrintDrinks();

            var sizes = new string[] { "Small", "Medium", "Large" };

            foreach (var size in sizes)
            {
                var giveaway = drinkFactory.CreateGiveaway();
                giveaway.Serve(size);
                System.Console.WriteLine();
            }
        }
    }
}
