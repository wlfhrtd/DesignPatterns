using StrategyShipping.Strategies.SalesTax;
using StrategyShipping.Models;
using StrategyShipping.Strategies.Invoice;
using StrategyLib.Models;
using System;
using StrategyShipping.Strategies.Shipping;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            Console.WriteLine("Select origin country:");
            string origin = Console.ReadLine().Trim();

            Console.WriteLine("Select destination country:");
            string destination = Console.ReadLine().Trim();

            Console.WriteLine("Choose one of the following shipping providers.");
            Console.WriteLine("1. PostNord (Swedish Postal Service)");
            Console.WriteLine("2. DHL");
            Console.WriteLine("3. USPS");
            Console.WriteLine("4. Fedex");
            Console.WriteLine("5. UPS");
            Console.WriteLine("Select shipping provider:");
            int provider = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Choose one of the following invoice delivery options.");
            Console.WriteLine("1. E-mail");
            Console.WriteLine("2. File (download later)");
            Console.WriteLine("3. Mail");
            Console.WriteLine("Select invoice delivery options: ");
            int invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());

            Order order = new()
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                },
                SalesTaxStrategy = GetSalesTaxStrategy(origin),
                InvoiceStrategy = GetInvoiceStrategy(invoiceOption),
                ShippingStrategy = GetShippingStrategy(provider),
            };
            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            Console.WriteLine(order.GetTax());

            order.FinalizeOrder();
        }

        private static IInvoiceStrategy GetInvoiceStrategy(int option)
        {
            return option switch
            {
                1 => new EmailInvoiceStrategy(),
                2 => new FileInvoiceStrategy(),
                3 => new PrintOnDemandInvoiceStrategy(),
                _ => throw new Exception("Unsupported invoice delivery option."),
            };
        }

        private static IShippingStrategy GetShippingStrategy(int provider)
        {
            return provider switch
            {
                1 => new SwedishPostalServiceShippingStrategy(),
                2 => new DhlShippingStrategy(),
                3 => new UnitedStatesPostalServiceShippingStrategy(),
                4 => new FedexShippingStrategy(),
                5 => new UpsShippingStrategy(),
                _ => throw new Exception("Unsupported shipping method."),
            };
        }

        private static ISalesTaxStrategy GetSalesTaxStrategy(string origin)
        {
            return origin.ToLowerInvariant() switch
            {
                "sweden" => new SwedenSalesTaxStrategy(),
                "usa" => new USAStateSalesTaxStrategy(),
                _ => throw new Exception("Unsupported shipping region."),
            };
        }
    }
}
