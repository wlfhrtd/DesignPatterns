using PaymentProcessingImproved.Models;
using PaymentProcessingImproved.PaymentProcessors;
using System.Linq;

namespace PaymentProcessingImproved.Handlers.PaymentHandlers
{
    public class CreditCardHandler : IReceiver<Order>
    {
        public CreditCardPaymentProcessor CreditCardPaymentProcessor { get; } = new();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
            {
                CreditCardPaymentProcessor.Finalize(order);
            }

            // base.Handle(order);
        }
    }
}
