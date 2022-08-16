using Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder.Builders.FluentBuilder
{
    // Builder (Fluent Builder) implementation excluding Director
    public class DailyReportFluentBuilder : IFluentInventoryBuilder
    {
        private InventoryReport report;

        private IEnumerable<FurnitureItem> items;


        public DailyReportFluentBuilder(IEnumerable<FurnitureItem> itemsList)
        {
            Reset();
            items = itemsList;
        }


        public void Reset() => report = new();

        public IFluentInventoryBuilder AddDimensions()
        {
            report.DimensionsSection = string.Join(Environment.NewLine, items.Select(li =>
            $"Product: {li.Name}\nPrice: {li.Price}\n" +
            $"Height: {li.Height} x Width: {li.Width}\tWeight: {li.Weight}\n"));

            return this;
        }

        public IFluentInventoryBuilder AddLogistics(DateTime dateTime)
        {
            report.LogisticsSection = $"Report date: {dateTime}";

            return this;
        }

        public IFluentInventoryBuilder AddTitle()
        {
            report.TitleSection = "***** Daily Furniture Inventory Report *****\n";

            return this;
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finished = report;
            Reset();

            return finished;
        }
    }
}
