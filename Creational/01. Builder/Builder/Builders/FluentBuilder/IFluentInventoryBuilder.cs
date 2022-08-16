using System;

namespace Builder.Builders.FluentBuilder
{
    // like .NET StringBuilder
    public interface IFluentInventoryBuilder
    {
        IFluentInventoryBuilder AddTitle();

        IFluentInventoryBuilder AddDimensions();

        IFluentInventoryBuilder AddLogistics(DateTime dateTime);
        // move concrete methods (like this one) to concrete Builder implementations
        InventoryReport GetDailyReport();
    }
}
