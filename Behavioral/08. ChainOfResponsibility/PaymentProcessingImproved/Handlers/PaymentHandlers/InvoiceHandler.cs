using PaymentProcessingImproved.Models;
using PaymentProcessingImproved.PaymentProcessors;
using System.Linq;

namespace PaymentProcessingImproved.Handlers.PaymentHandlers
{
    public class InvoiceHandler : IReceiver<Order>
    {
        public InvoicePaymentProcessor InvoicePaymentProcessor { get; } = new();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
            {
                InvoicePaymentProcessor.Finalize(order);
            }

            // base.Handle(order);
        }
    }
}
