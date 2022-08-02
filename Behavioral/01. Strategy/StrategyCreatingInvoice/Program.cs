using StrategyCreatingInvoice.Strategies.SalesTax;
using StrategyCreatingInvoice.Models;
using StrategyCreatingInvoice.Strategies.Invoice;
using StrategyLib.Models;
using System;


namespace Strategy
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

            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });

            // using concrete strategy via property initialization
            order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
            order.InvoiceStrategy = new FileInvoiceStrategy();

            Console.WriteLine(order.GetTax());
            order.FinalizeOrder();
        }
    }
}
