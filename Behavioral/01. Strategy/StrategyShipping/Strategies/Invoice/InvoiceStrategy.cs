using StrategyShipping.Models;
using System;
using System.Text;


namespace StrategyShipping.Strategies.Invoice
{
    public abstract class InvoiceStrategy : IInvoiceStrategy
    {
        public abstract void Generate(Order order);

        public string GenerateTextInvoice(Order order)
        {
            StringBuilder invoice = new(1024);
            invoice.AppendLine($"Invoice Date: {DateTimeOffset.Now}");
            invoice.AppendLine($"Id|Name|Price|Quantity");

            foreach (var item in order.LineItems)
            {
                invoice.AppendLine($"{item.Key.Id}|{item.Key.Name}|{item.Key.Price}|{item.Value}");
            }

            invoice.AppendLine();
            invoice.AppendLine();

            decimal tax = order.GetTax();
            decimal total = order.TotalPrice + tax;

            invoice.AppendLine($"Tax Total: {tax}");
            invoice.AppendLine($"Total: {total}");

            return invoice.ToString();
        }
    }
}
