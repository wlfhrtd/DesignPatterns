using Prototype.Models;
using Prototype.Models.Prototypes.Order;
using System;

namespace Prototype
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Original *****");
            Order order = new("Harrison", true, new string[] { "Pizza", "Coke" }, new OrderInfo(1));
            order.Print();
            Console.WriteLine();

            Console.WriteLine("***** Shallow Copy *****");
            Order shallowCopy = (Order)order.ShallowCopy();
            shallowCopy.Print();
            Console.WriteLine();

            Console.WriteLine("***** Deep Copy *****");
            Order deepCopy = (Order)order.DeepCopy();
            deepCopy.Print();
            Console.WriteLine();

            Console.WriteLine("***** Order Changes *****");
            order.CustomerName = "Jeff";
            order.Info.Id = 2;
            order.Print();
            Console.WriteLine("***** Shallow Copy *****");
            shallowCopy.Print();
            Console.WriteLine("***** Deep Copy *****");
            deepCopy.Print();
            Console.WriteLine();

            Console.WriteLine("***** Work with Prototype Manager *****");
            OrderPrototypeManager manager = new();
            Order order1 = new()
            {
                CustomerName = "Steve",
                IsDelivery = false,
                OrderContents = new string[] { "Chicken", "Beer" },
                Info = new(3),
            };
            order1.Print();

            string exampleKey = DateTime.Today.ToLongDateString();
            manager[exampleKey] = order1;

            Console.WriteLine("***** Manager Deep Clone *****");
            Order managerClone = (Order)manager[exampleKey].DeepCopy();
            managerClone.Print();
        }
    }
}