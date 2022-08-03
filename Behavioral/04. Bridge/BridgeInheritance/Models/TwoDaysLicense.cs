using System;


namespace BridgeInheritance.Models
{
    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseDate, Discount d) : base(movie, purchaseDate, d) { }


        public override DateTime? GetExpirationDate()
        {
            return PurchaseDate.AddDays(2);
        }

        protected override decimal GetPriceCore()
        {
            return 5m;
        }
    }
}
