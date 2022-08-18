using GenericFacade.Services;
using System;

namespace GenericFacade
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceA serviceA = new ServiceA();
            int AResult = serviceA.Method2();

            ServiceB serviceB = new ServiceB();
            string BResult = serviceB.Method2();

            ServiceC serviceC = new ServiceC();
            double CResult = serviceC.Method1();

            Console.WriteLine(AResult + " - " + CResult + " - " + BResult);
            Console.WriteLine("***** EOF *****");

            IServiceFacade facade = new ServiceFacade();

            Tuple<int, double, string> result = facade.CallFacade();

            Console.WriteLine(result.Item1 + " - " + result.Item2 + " - " + result.Item3);
        }
    }
}
