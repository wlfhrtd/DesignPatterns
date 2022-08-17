using AbstractFactory.Models.Shipping.Factories.Base;

namespace AbstractFactory.Models.Shipping.Factories
{
    public class GlobalExpressShippingProviderFactory : ShippingProviderFactory
    {
        protected override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalExpressShippingProvider();
        }
    }
}
