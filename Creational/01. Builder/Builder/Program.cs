using Builder.Builders.FluentBuilder;
using Builder.Builders.FurnitureInventory;
using Builder.Models;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new FurnitureItem("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new FurnitureItem("Dining Table", 105.0, 35.4, 100.6, 55.5),
            };

            DailyReportBuilder inventoryBuilder = new(items);
            InventoryBuildDirector director = new(inventoryBuilder);

            director.BuildCompleteReport();
            InventoryReport report = inventoryBuilder.GetDailyReport();
            System.Console.WriteLine(report.ToString());

            System.Console.WriteLine("***** EOF *****");
            System.Console.WriteLine();
            System.Console.WriteLine("***** Fluent Builder Usage *****");

            DailyReportFluentBuilder fluentBuilder = new(items);
            // bypassing Director context controls flow/order
            InventoryReport fluentReport = fluentBuilder
                .AddTitle()
                .AddDimensions()
                .AddLogistics(System.DateTime.Now)
                .GetDailyReport(); // Build()
            System.Console.WriteLine(fluentReport.ToString());

            System.Console.WriteLine("***** EOF *****");
            System.Console.WriteLine();
        }
    }
}
