using System;


namespace Bridge.Models
{
    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseDate) : base(movie, purchaseDate) { }


        public override DateTime? GetExpirationDate()
        {
            return PurchaseDate.AddDays(3);
        }

        public override decimal GetPrice()
        {
            return 5m;
        }
    }
}
