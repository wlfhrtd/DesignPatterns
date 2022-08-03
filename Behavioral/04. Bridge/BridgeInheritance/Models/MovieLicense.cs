using System;


namespace BridgeInheritance.Models
{
    public abstract class MovieLicense
    {
        // Bridge (aka composition) connecting 2 aspects of app ~ 2 class hierarchies
        private readonly Discount discount;

        public string Movie { get; }

        public DateTime PurchaseDate { get; }


        protected MovieLicense(string movie, DateTime purchaseDate, Discount d)
        {
            Movie = movie;
            PurchaseDate = purchaseDate;
            discount = d;
        }


        public decimal GetPrice()
        {
            int dis = discount.GetDiscount();
            decimal multiplier = 1 - dis / 100m;
            return GetPriceCore() * multiplier;
        }

        protected abstract decimal GetPriceCore();

        public abstract DateTime? GetExpirationDate();
    }
}
