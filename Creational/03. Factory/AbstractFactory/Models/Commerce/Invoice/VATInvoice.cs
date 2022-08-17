using System.Text;

namespace AbstractFactory.Models.Commerce.Invoice
{
    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("VAT Invoice");
        }
    }
}
