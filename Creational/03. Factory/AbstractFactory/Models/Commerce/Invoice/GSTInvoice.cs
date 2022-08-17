using System.Text;

namespace AbstractFactory.Models.Commerce.Invoice
{
    public class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("GST Invoice");
        }
    }
}
