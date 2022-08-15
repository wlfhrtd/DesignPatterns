﻿using PaymentProcessingImproved.Handlers;
using PaymentProcessingImproved.Handlers.PaymentHandlers;
using PaymentProcessingImproved.Models;
using System;

namespace PaymentProcessingImproved
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.LineItems.Add(new Item("ATOMOSV", "Atomos Ninja V", 499), 2);
            order.LineItems.Add(new Item("EOSR", "Canon EOS R", 1799), 1);

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Paypal,
                Amount = 1000
            });

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice,
                Amount = 1797
            });

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);

            //var handler = new PaypalHandler();
            //var creditCard = new CreditCardHandler();
            //var invoice = new InvoiceHandler();
            //handler.SetNext(creditCard).SetNext(invoice);

            var handler = new PaymentHandler(
                new PaypalHandler(),
                new InvoiceHandler(),
                new CreditCardHandler());

            handler.Handle(order);

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
        }
    }
}
