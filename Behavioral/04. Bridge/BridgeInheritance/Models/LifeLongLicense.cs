using System;


namespace BridgeInheritance.Models
{
    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseDate, Discount d) : base(movie, purchaseDate, d) { }


        public override DateTime? GetExpirationDate()
        {
            return null;
        }

        protected override decimal GetPriceCore()
        {
            return 10m;
        }
    }
}
