namespace PaymentProcessingImproved.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public PaymentProvider PaymentProvider { get; set; }
    }

    public enum PaymentProvider
    {
        Paypal,
        CreditCard,
        Invoice
    }
}
