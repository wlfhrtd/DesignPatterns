using AbstractFactory.Models.Commerce.AbstractFactory;
using AbstractFactory.Models.Commerce.Invoice;
using AbstractFactory.Models.Commerce.Summary;
using AbstractFactory.Models.Shipping;
using AbstractFactory.Models.Shipping.Factories;

namespace AbstractFactory.Models.Commerce.Factories
{
    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
}
