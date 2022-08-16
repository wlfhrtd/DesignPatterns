using System;

namespace Builder.Builders.FurnitureInventory
{
    public class InventoryBuildDirector
    {
        private IFurnitureInventoryBuilder builder;


        public InventoryBuildDirector(IFurnitureInventoryBuilder concreteBuilder)
        {
            builder = concreteBuilder;
        }


        public void BuildCompleteReport()
        {
            builder.AddTitle();
            builder.AddDimensions();
            builder.AddLogistics(DateTime.Now);
        }
    }
}
