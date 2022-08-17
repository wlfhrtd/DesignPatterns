using SimpleFactory.Models.Commerce;
using SimpleFactory.Models.Shipping;
using SimpleFactory.Models.Shipping.Factories;

namespace SimpleFactory
{
    public class Cart
    {
        private readonly Order order;


        public Cart(Order o)
        {
            order = o;
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
                = ShippingProviderFactory.CreateShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
