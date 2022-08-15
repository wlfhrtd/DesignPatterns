using TemplateMethod.Components;
using TemplateMethod.Models;

namespace TemplateMethod
{
    public class PizzaBakingService
    {
        public LoggerAdapter logger;


        public PizzaBakingService(LoggerAdapter logger)
        {
            this.logger = logger;
        }


        public Pizza PreparePizza()
        {
            Pizza pizza = new();

            PrepareCrust();

            AddToppings();

            Bake();

            Slice();

            return pizza;
        }

        protected void PrepareCrust()
        {
            logger.Log("Rolling out crust and hand tossing the dough");
        }

        protected void AddToppings()
        {
            logger.Log("Adding pizza toppings");
        }

        protected void Bake()
        {
            logger.Log("Baking for 15 minutes");
        }

        protected void Slice()
        {
            logger.Log("Cutting into 8 slices.");
        }
    }
}
