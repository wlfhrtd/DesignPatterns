using TemplateMethodRefactored.Base;
using TemplateMethodRefactored.Components;
using TemplateMethodRefactored.Models;

namespace TemplateMethodRefactored
{
    public class PieBakingService : PanFoodServiceBase<Pie>
    {
        public PieBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void PrepareCrust()
        {
            logger.Log("Rolling out crust and pressing into pie pan");
        }

        // could be AddFilling in base class but w/e just 'AddSomething'
        protected override void AddToppings()
        {
            logger.Log("Adding pie filling");
        }

        protected override void Cover()
        {
            logger.Log("Adding lattice top");
        }

        protected override void Bake()
        {
            logger.Log("Baking for 45 minutes");
        }

        protected override void Slice()
        {
            logger.Log("Cutting into 6 slices.");
        }
    }
}
