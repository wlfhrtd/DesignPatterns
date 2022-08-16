using System;

namespace Builder.Builders.FurnitureInventory
{
    public interface IFurnitureInventoryBuilder
    {
        void AddTitle();

        void AddDimensions();

        void AddLogistics(DateTime dateTime);
        // move concrete methods (like this one) to concrete Builder implementations
        InventoryReport GetDailyReport();
    }
}
