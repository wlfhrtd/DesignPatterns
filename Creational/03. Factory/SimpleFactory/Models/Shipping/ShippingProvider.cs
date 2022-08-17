using SimpleFactory.Models.Commerce;

namespace SimpleFactory.Models.Shipping
{
    public abstract class ShippingProvider
    {
        public ShippingCostCalculator ShippingCostCalculator { get; protected set; }

        public CustomsHandlingOptions CustomsHandlingOptions { get; protected set; }

        public InsuranceOptions InsuranceOptions { get; protected set; }

        public bool RequireSignature { get; set; }

        public abstract string GenerateShippingLabelFor(Order order);
    }

    public enum ShippingType
    {
        Standard,
        Express,
        NextDay,
    }

    public enum ShippingStatus
    {
        WaitingForPayment,
        ReadyForShippment,
        Shipped,
    }
}
