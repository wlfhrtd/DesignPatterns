using PaymentProcessing.Models;
using PaymentProcessing.PaymentProcessors;
using System.Linq;

namespace PaymentProcessing.Handlers.PaymentHandlers
{
    public class CreditCardHandler : PaymentHandler
    {
        public CreditCardPaymentProcessor CreditCardPaymentProcessor { get; } = new();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
            {
                CreditCardPaymentProcessor.Finalize(order);
            }

            base.Handle(order);
        }
    }
}
