using System;


namespace Bridge.Models
{
    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseDate) : base(movie, purchaseDate) { }


        public override DateTime? GetExpirationDate()
        {
            return null;
        }

        public override decimal GetPrice()
        {
            return 10m;
        }
    }
}
