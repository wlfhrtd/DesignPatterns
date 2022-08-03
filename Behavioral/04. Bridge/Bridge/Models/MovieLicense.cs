using System;


namespace Bridge.Models
{
    public abstract class MovieLicense
    {
        public string Movie { get; }

        public DateTime PurchaseDate { get; }


        protected MovieLicense(string movie, DateTime purchaseDate)
        {
            Movie = movie;
            PurchaseDate = purchaseDate;
        }


        public abstract decimal GetPrice();

        public abstract DateTime? GetExpirationDate();
    }
}
