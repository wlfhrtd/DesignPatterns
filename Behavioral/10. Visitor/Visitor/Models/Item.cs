using System;

namespace Visitor.Models
{
    public class Item
    {
        public int Id;

        public decimal Price;


        public Item(int id, decimal price)
        {
            Id = id;
            Price = price;
        }


        public decimal GetDiscount(decimal percentage)
            => Math.Round(Price * percentage, 2);
    }
}
