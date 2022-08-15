using PaymentProcessingImproved.Models;

namespace PaymentProcessingImproved.PaymentProcessors
{
    public interface IPaymentProcessor
    {
        void Finalize(Order order);
    }
}
