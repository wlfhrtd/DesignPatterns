using TemplateMethod.Components;
using TemplateMethod.Models;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerAdapter logger = new();

            PieBakingService pieBakingService = new(logger);
            Pie pie = pieBakingService.PreparePie();
            System.Console.WriteLine(logger.Dump());

            System.Console.WriteLine("***** EOL *****");
            logger.Clear();

            PizzaBakingService pizzaBakingService = new(logger);
            Pizza pizza = pizzaBakingService.PreparePizza();
            System.Console.WriteLine(logger.Dump());
        }
    }
}
