using PaymentProcessingImproved.Exceptions;
using PaymentProcessingImproved.Models;
using System;
using System.Collections.Generic;

namespace PaymentProcessingImproved.Handlers
{
    public class PaymentHandler
    {
        // private IHandler<Order> Next { get; set; }

        private readonly IList<IReceiver<Order>> receivers;


        public PaymentHandler(params IReceiver<Order>[] rec)
        {
            receivers = rec;
        }


        public void Handle(Order order)
        {
            //Console.WriteLine($"Running: {GetType().Name}");

            //if (Next == null && order.AmountDue > 0)
            //{
            //    throw new InsufficientPaymentException();
            //}

            //if (order.AmountDue > 0)
            //{
            //    Next.Handle(order);
            //}
            //else
            //{
            //    order.ShippingStatus = ShippingStatus.ReadyForShippment;
            //}

            foreach (var receiver in receivers)
            {
                Console.WriteLine($"Running: {receiver.GetType().Name}");

                if (order.AmountDue > 0)
                {
                    receiver.Handle(order);
                }
                else
                {
                    break;
                }
            }

            if (order.AmountDue > 0)
            {
                throw new InsufficientPaymentException();
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public void SetNext(IReceiver<Order> next)
        {
            //Next = next;
            //return Next;

            receivers.Add(next);
        }
    }
}
