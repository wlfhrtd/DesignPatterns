using StrategyArraySort.Models;
using StrategyLib.Models;
using System;
using System.Linq;
using System.Collections.Generic;


namespace StrategyArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new[] {
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "USA"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "USA"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Singapore"
                    }
                }
            };

            Print(orders);

            Console.WriteLine();
            Console.WriteLine("Sorting..");
            Console.WriteLine();
            // IComparer implementation
            Array.Sort(orders, new OrderOriginComparer());
            Print(orders);

            // easier with LINQ but it is not about Strategy pattern
            var sorted = from o in orders
                         orderby o.ShippingDetails.OriginCountry
                         select o;
            // alternative
            // var sorted = orders.Select(order => order).OrderBy(o => o.ShippingDetails.OriginCountry);
            Console.WriteLine();
            Console.WriteLine("Sorted with LINQ:");
            Console.WriteLine();
            Print(sorted);
        }

        static void Print(IEnumerable<Order> orders)
        {
            foreach (var order in orders) Console.WriteLine(order.ShippingDetails.OriginCountry);
        }
    }

    public class OrderAmountComparer : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            decimal xTotal = x.TotalPrice;
            decimal yTotal = y.TotalPrice;

            if (xTotal == yTotal) return 0;

            if (xTotal > yTotal) return 1;

            return -1;
        }
    }
    public class OrderOriginComparer : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            string xDest = x.ShippingDetails.OriginCountry.ToLowerInvariant();
            string yDest = y.ShippingDetails.OriginCountry.ToLowerInvariant();

            if (xDest == yDest) return 0;

            if (xDest[0] > yDest[0]) return 1;

            return -1;
        }
    }
}
