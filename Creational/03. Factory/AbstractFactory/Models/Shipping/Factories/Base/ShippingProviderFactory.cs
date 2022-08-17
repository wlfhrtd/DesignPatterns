namespace AbstractFactory.Models.Shipping.Factories.Base
{
    public abstract class ShippingProviderFactory
    {
        protected abstract ShippingProvider CreateShippingProvider(string country);
        // common code for ALL derived factories
        public ShippingProvider GetShippingProvider(string country)
        {
            ShippingProvider provider = CreateShippingProvider(country);

            if (country == "Sweden"
                && provider.InsuranceOptions.ProviderHasInsurance)
            {
                provider.RequireSignature = false;
            }

            return provider;
        }
    }
}
