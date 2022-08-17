using AbstractFactory.Models.Commerce.AbstractFactory;
using AbstractFactory.Models.Commerce.Invoice;
using AbstractFactory.Models.Commerce.Summary;
using AbstractFactory.Models.Shipping;
using AbstractFactory.Models.Shipping.Factories;
using AbstractFactory.Models.Shipping.Factories.Base;

namespace AbstractFactory.Models.Commerce.Factories
{
    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
            {
                return new NoVATInvoice();
            }

            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if (order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new EmailSummary();
        }
    }
}
