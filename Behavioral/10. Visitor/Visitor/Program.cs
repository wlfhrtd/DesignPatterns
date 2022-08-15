using System.Collections.Generic;
using Visitor.Models;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVisitableElement> items = new()
            {
                new Book(12345, 11.99m),
                new Book(78910, 22.79m),
                new Vinyl(11198, 17.99m),
                new Book(63254, 9.79m)
            };

            DiscountVisitor discountVisitor = new();
            foreach (var item in items)
            {
                item.Accept(discountVisitor);
            }
            discountVisitor.Print();

            SalesVisitor salesVisitor = new();
            foreach (var item in items)
            {
                item.Accept(salesVisitor);
            }
            salesVisitor.Print();
            System.Console.WriteLine();

            System.Console.WriteLine("***** USING OBJECT STRUCTURE *****");
            ObjectStructure cart = new(items);
            DiscountVisitor dv = new();
            SalesVisitor sv = new();

            cart.ApplyVisitor(dv);
            cart.ApplyVisitor(sv);

            dv.Reset();
            cart.RemoveItem(items[2]);
            cart.ApplyVisitor(dv);
        }
    }
}
