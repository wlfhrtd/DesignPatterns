using StrategyShipping.Models;
using StrategyShipping.Strategies.Invoice;
using System;
using System.IO;


namespace StrategyShipping.Strategies.Invoice
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (StreamWriter stream = new($"invoice_{Guid.NewGuid()}.txt"))
            {
                stream.Write(GenerateTextInvoice(order));
                stream.Flush();
            }
        }
    }
}
