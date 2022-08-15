using PaymentProcessing.Models;
using PaymentProcessing.PaymentProcessors;
using System.Linq;

namespace PaymentProcessing.Handlers.PaymentHandlers
{
    public class PaypalHandler : PaymentHandler
    {
        private PaypalPaymentProcessor PaypalPaymentProcessor { get; } = new();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(p => p.PaymentProvider == PaymentProvider.Paypal))
            {
                PaypalPaymentProcessor.Finalize(order);
            }

            base.Handle(order);
        }
    }
}
