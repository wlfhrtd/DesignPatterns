using AbstractFactory.Models.Commerce;
using AbstractFactory.Models.Commerce.AbstractFactory;
using AbstractFactory.Models.Shipping;
using System;

namespace AbstractFactory
{
    public class Cart
    {
        private readonly Order order;
        private readonly IPurchaseProviderFactory purchaseProvider;

        public Cart(Order o, IPurchaseProviderFactory purchaseProviderFactory)
        {
            order = o;
            purchaseProvider = purchaseProviderFactory;
        }

        public string Finalize()
        {
            if (order.ShippingStatus == ShippingStatus.ReadyForShippment)
            {
                throw new InvalidOperationException();
            }

            var shippingProvider = purchaseProvider.CreateShippingProvider(order);

            var invoice = purchaseProvider.CreateInvoice(order);
            invoice.GenerateInvoice();

            var summary = purchaseProvider.CreateSummary(order);
            summary.Send();

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
