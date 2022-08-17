using FactoryMethod.Models.Commerce;
using FactoryMethod.Models.Shipping;
using FactoryMethod.Models.Shipping.Factories.Base;

namespace FactoryMethod
{
    public class Cart
    {
        private readonly Order order;
        private readonly ShippingProviderFactory shippingProviderFactory;

        public Cart(Order o, ShippingProviderFactory providerFactory)
        {
            order = o;
            shippingProviderFactory = providerFactory;
        }

        // initial Finalize() contains a lot of object creation and logic
        // that should be extracted
        public string Finalize()
        {
            #region Factory pattern refactoring
            //#region Create Shipping Provider (refactor this moving to ShippingProviderFactory)
            //ShippingProvider shippingProvider;

            //if (order.Sender.Country == "Australia")
            //{
            //    #region Australia Post Shipping Provider
            //    var shippingCostCalculator = new ShippingCostCalculator(
            //        internationalShippingFee: 250,
            //        extraWeightFee: 500
            //    )
            //    {
            //        ShippingType = ShippingType.Standard
            //    };

            //    var customsHandlingOptions = new CustomsHandlingOptions
            //    {
            //        TaxOptions = TaxOptions.PrePaid
            //    };

            //    var insuranceOptions = new InsuranceOptions
            //    {
            //        ProviderHasInsurance = false,
            //        ProviderHasExtendedInsurance = false,
            //        ProviderRequiresReturnOnDamange = false
            //    };

            //    shippingProvider = new AustraliaPostShippingProvider("CLIENT_ID",
            //        "SECRET",
            //        shippingCostCalculator,
            //        customsHandlingOptions,
            //        insuranceOptions);
            //    #endregion
            //}
            //else if (order.Sender.Country == "Sweden")
            //{
            //    #region Swedish Postal Service Shipping Provider
            //    var shippingCostCalculator = new ShippingCostCalculator(
            //        internationalShippingFee: 50,
            //        extraWeightFee: 100
            //    )
            //    {
            //        ShippingType = ShippingType.Express
            //    };

            //    var customsHandlingOptions = new CustomsHandlingOptions
            //    {
            //        TaxOptions = TaxOptions.PayOnArrival
            //    };

            //    var insuranceOptions = new InsuranceOptions
            //    {
            //        ProviderHasInsurance = true,
            //        ProviderHasExtendedInsurance = false,
            //        ProviderRequiresReturnOnDamange = false
            //    };

            //    shippingProvider = new SwedishPostalServiceShippingProvider("API_KEY",
            //        shippingCostCalculator,
            //        customsHandlingOptions,
            //        insuranceOptions);
            //    #endregion
            //}
            //else
            //{
            //    throw new NotSupportedException("No shipping provider found for origin country");
            //}
            //#endregion
            #endregion

            var shippingProvider
                = shippingProviderFactory.GetShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
