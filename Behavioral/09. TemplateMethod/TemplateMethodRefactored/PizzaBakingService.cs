using TemplateMethodRefactored.Base;
using TemplateMethodRefactored.Components;
using TemplateMethodRefactored.Models;

namespace TemplateMethodRefactored
{
    public class PizzaBakingService : PanFoodServiceBase<Pizza>
    {
        public PizzaBakingService(LoggerAdapter logger) : base(logger)
        {
        }


        protected override void PrepareCrust()
        {
            logger.Log("Rolling out and hand tossing the dough");
            item.CrustType = "Thin";
        }

        protected override void AddToppings()
        {
            logger.Log("Adding pizza toppings");
            item.Toppings.Add("Pepperoni");
            item.Toppings.Add("Sausage");
        }

        protected override void Bake()
        {
            logger.Log("Baking for 15 minutes");
            item.WasBaked = true;
        }

        protected override void Slice()
        {
            logger.Log("Cutting into 8 slices.");
            item.NumSlices = 8;
        }
    }
}
