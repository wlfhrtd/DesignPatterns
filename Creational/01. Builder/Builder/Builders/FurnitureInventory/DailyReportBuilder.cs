using Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder.Builders.FurnitureInventory
{
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport report;

        private IEnumerable<FurnitureItem> items;


        public DailyReportBuilder(IEnumerable<FurnitureItem> itemsList)
        {
            Reset();
            items = itemsList;
        }


        public void Reset() => report = new();

        public void AddDimensions()
        {
            report.DimensionsSection = string.Join(Environment.NewLine, items.Select(li =>
            $"Product: {li.Name}\nPrice: {li.Price}\n" +
            $"Height: {li.Height} x Width: {li.Width}\tWeight: {li.Weight}\n"));
        }

        public void AddLogistics(DateTime dateTime)
        {
            report.LogisticsSection = $"Report date: {dateTime}";
        }

        public void AddTitle()
        {
            report.TitleSection = "***** Daily Furniture Inventory Report *****\n";
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finished = report;
            Reset();

            return finished;
        }
    }
}
