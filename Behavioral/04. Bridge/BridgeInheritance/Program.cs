using BridgeInheritance.Models;
using System;


namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoDaysLicense l1 = new("Brother 2", DateTime.Now, new NoDiscount());
            LifeLongLicense l2 = new("Matrix", DateTime.Now, new NoDiscount());

            PrintDetails(l1);
            PrintDetails(l2);

            TwoDaysLicense l3 = new("Brother 2", DateTime.Now, new SeniorDiscount());
            LifeLongLicense l4 = new("Matrix", DateTime.Now, new MilitaryDiscount());

            PrintDetails(l3);
            PrintDetails(l4);
        }

        private static void PrintDetails(MovieLicense l)
        {
            Console.WriteLine($"Title: {l.Movie}");
            Console.WriteLine($"Price: {GetPrice(l)}");
            Console.WriteLine($"Valid for: {GetValidFor(l)}");
            Console.WriteLine();
        }

        private static string GetValidFor(MovieLicense l)
        {
            DateTime? expirationDate = l.GetExpirationDate();

            if (expirationDate == null) return "Forever.";

            TimeSpan t = expirationDate.Value - DateTime.Now;

            return $"{t.Days}d {t.Hours}h {t.Minutes}m";
        }

        private static string GetPrice(MovieLicense l)
        {
            return $"${l.GetPrice():0.00}";
        }
    }
}
