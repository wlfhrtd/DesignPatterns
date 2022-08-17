using Prototype.Models.Prototypes.Order;
using System;

namespace Prototype.Models
{
    public class Order : OrderPrototype
    {
        public string CustomerName { get; set; }

        public bool IsDelivery { get; set; }

        public string[] OrderContents { get; set; }

        public OrderInfo Info { get; set; }


        public Order() { }

        public Order(string customerName, bool isDelivery, string[] orderContents, OrderInfo info)
        {
            CustomerName = customerName;
            IsDelivery = isDelivery;
            OrderContents = orderContents;
            Info = info;
        }


        public override OrderPrototype ShallowCopy()
        {
            return (OrderPrototype)MemberwiseClone();
        }

        public override OrderPrototype DeepCopy()
        {
            Order cloned = (Order)MemberwiseClone();
            cloned.Info = new OrderInfo(Info.Id);

            return cloned;
        }

        public override void Print()
        {
            Console.WriteLine("------- Prototype Order -------");
            Console.WriteLine("\nName: {0} \nDelivery: {1}", CustomerName, IsDelivery);
            Console.WriteLine("ID: {0}", Info.Id);
            Console.WriteLine("Order Contents: " + string.Join(", ", OrderContents) + "\n");
        }
    }
}
