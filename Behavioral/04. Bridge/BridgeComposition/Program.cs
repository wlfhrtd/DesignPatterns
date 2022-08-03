using BridgeComposition.Models;
using System;


namespace BridgeComposition
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieLicense l1 = new("Brother 2", DateTime.Now, Discount.None, LicenceType.TwoDays);
            MovieLicense l2 = new("Matrix", DateTime.Now, Discount.None, LicenceType.LifeLong);

            PrintDetails(l1);
            PrintDetails(l2);

            MovieLicense l3 = new("Brother 2", DateTime.Now, Discount.Senior, LicenceType.TwoDays);
            MovieLicense l4 = new("Matrix", DateTime.Now, Discount.Military, LicenceType.LifeLong);

            PrintDetails(l3);
            PrintDetails(l4);

            MovieLicense l5 =new(
                "Blade Runner", DateTime.Now, Discount.Senior, LicenceType.TwoDays, SpecialOffer.TwoDaysExtension);

            PrintDetails(l5);
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
