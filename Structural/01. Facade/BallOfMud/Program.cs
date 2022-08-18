using System;

namespace BallOfMud
{
    class Program
    {
        static void Main(string[] args)
        {
            BigClass bigClass = new BigClass();

            bigClass.SetValueI(3);

            bigClass.IncrementI();
            bigClass.IncrementI();
            bigClass.IncrementI();

            bigClass.DecrememntI();

            // Console.WriteLine($"Final Number : {bigClass.GetValueB()}");
            Console.WriteLine($"Final Number : {bigClass.GetValueA()}");
            Console.WriteLine("***** EOF *****");

            BigClassFacade facade = new BigClassFacade();

            facade.IncreaseBy(50);
            facade.DecreaseBy(20);

            Console.WriteLine($"Final Number : {facade.GetCurrentValue()}");

        }
    }
}
