using PaymentProcessingImproved.Models;
using PaymentProcessingImproved.PaymentProcessors;
using System.Linq;

namespace PaymentProcessingImproved.Handlers.PaymentHandlers
{
    public class PaypalHandler : IReceiver<Order>
    {
        private PaypalPaymentProcessor PaypalPaymentProcessor { get; } = new();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(p => p.PaymentProvider == PaymentProvider.Paypal))
            {
                PaypalPaymentProcessor.Finalize(order);
            }

            // base.Handle(order);
        }
    }
}
