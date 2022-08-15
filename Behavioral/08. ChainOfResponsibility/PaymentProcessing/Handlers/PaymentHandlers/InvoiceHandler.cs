using PaymentProcessing.Models;
using PaymentProcessing.PaymentProcessors;
using System.Linq;

namespace PaymentProcessing.Handlers.PaymentHandlers
{
    public class InvoiceHandler : PaymentHandler
    {
        public InvoicePaymentProcessor InvoicePaymentProcessor { get; } = new();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
            {
                InvoicePaymentProcessor.Finalize(order);
            }

            base.Handle(order);
        }
    }
}
