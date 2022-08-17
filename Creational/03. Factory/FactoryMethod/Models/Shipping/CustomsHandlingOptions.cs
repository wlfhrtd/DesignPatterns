namespace FactoryMethod.Models.Shipping
{
    public class CustomsHandlingOptions
    {
        public TaxOptions TaxOptions { get; set; }
    }

    public enum TaxOptions
    {
        PrePaid,
        DutyFree,
        PayOnArrival
    }
}
