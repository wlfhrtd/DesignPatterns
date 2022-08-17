using AbstractFactory.Models.Commerce.Invoice;
using AbstractFactory.Models.Commerce.Summary;
using AbstractFactory.Models.Shipping;

namespace AbstractFactory.Models.Commerce.AbstractFactory
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);

        IInvoice CreateInvoice(Order order);

        ISummary CreateSummary(Order order);
    }
}
