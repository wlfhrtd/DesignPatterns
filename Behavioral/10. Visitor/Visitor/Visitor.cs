using Visitor.Models;

namespace Visitor
{
    public interface IVisitor
    {
        void VisitBook(Book book);

        void VisitVinyl(Vinyl vinyl);

        void Print();
    }

    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        private decimal savings = 0.0m;

        public void Reset()
        {
            savings = 0.0m;
        }

        public void Print()
        {
            System.Console.WriteLine($"Saved: ${savings}");
            System.Console.WriteLine("***** EOF *****");
        }

        public void VisitBook(Book book)
        {
            decimal discount = 0.0m;

            if (book.Price < 20.00m)
            {
                discount = book.GetDiscount(0.10m);
                System.Console.WriteLine(
                    $"Discount: Book {book.Id} is now ${book.Price - discount}");
            }
            else
            {
                System.Console.WriteLine($"Fullprice: Book {book.Id}");
            }

            savings += discount;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            decimal discount = vinyl.GetDiscount(0.15m);
            System.Console.WriteLine(
                $"Sale: Vinyl {vinyl.Id} is now ${vinyl.Price - discount}");

            savings += discount;
        }
    }

    public class SalesVisitor : IVisitor
    {
        private int BookCount = 0;

        private int VinylCount = 0;

        public void Reset()
        {
            BookCount = 0;
            VinylCount = 0;
        }

        public void Print()
        {
            System.Console.WriteLine($"Sold: Books {BookCount}\tVinyl {VinylCount}");
            System.Console.WriteLine($"Total units sold: {BookCount + VinylCount}");
            System.Console.WriteLine("***** EOF *****");
        }

        public void VisitBook(Book book)
        {
            BookCount++;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            VinylCount++;
        }
    }

    public class Visitor
    {
    }
}
