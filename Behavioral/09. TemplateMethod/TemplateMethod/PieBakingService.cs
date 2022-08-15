using TemplateMethod.Components;
using TemplateMethod.Models;

namespace TemplateMethod
{
    public class PieBakingService
    {
        public LoggerAdapter logger;


        public PieBakingService(LoggerAdapter logger)
        {
            this.logger = logger;
        }


        public Pie PreparePie()
        {
            Pie pie = new();

            PrepareCrust();

            AddFilling();

            Cover();

            Bake();

            Slice();

            return pie;
        }

        protected void PrepareCrust()
        {
            logger.Log("Rolling out crust and pressing into pie pan");
        }

        protected void AddFilling()
        {
            logger.Log("Adding pie filling");
        }

        protected void Cover()
        {
            logger.Log("Adding lattice top");
        }

        protected void Bake()
        {
            logger.Log("Baking for 45 minutes");
        }

        protected void Slice()
        {
            logger.Log("Cutting into 6 slices.");
        }
    }
}
