using StrategyAlternative.Strategies.SalesTax;
using StrategyAlternative.Models;
using StrategyLib.Models;
using System;


namespace StrategyAlternative
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            // using concrete strategy as optional parameter of exposed interface method
            Console.WriteLine(order.GetTax(new SwedenSalesTaxStrategy()));
        }
    }
}
