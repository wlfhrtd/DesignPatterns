using TemplateMethodRefactored.Components;
using TemplateMethodRefactored.Models;

namespace TemplateMethodRefactored
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerAdapter logger = new();

            PieBakingService pieBakingService = new(logger);
            Pie pie = pieBakingService.Prepare();
            System.Console.WriteLine(logger.Dump());

            System.Console.WriteLine("***** EOL *****");
            logger.Clear();

            PizzaBakingService pizzaBakingService = new(logger);
            Pizza pizza = pizzaBakingService.Prepare();
            System.Console.WriteLine(logger.Dump());

            System.Console.WriteLine("***** EOL *****");
            logger.Clear();

            ColdVeggiePizzaBakingService coldVeggiePizzaBakingService = new(logger);
            ColdVeggiePizza coldVeggiePizza = coldVeggiePizzaBakingService.Prepare();
            System.Console.WriteLine(logger.Dump());
        }
    }
}
