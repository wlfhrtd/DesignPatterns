using StrategyCreatingInvoice.Models;
using System;
using System.IO;


namespace StrategyCreatingInvoice.Strategies.Invoice
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
