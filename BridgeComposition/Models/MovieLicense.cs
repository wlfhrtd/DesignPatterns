using System;


namespace BridgeComposition.Models
{
    public class MovieLicense
    {
        // Bridge (aka composition) connecting 2 aspects of app ~ 2 class hierarchies
        // OR 1 class hierarchy + set of enums in BridgeComposition case
        private readonly Discount discount;
        // classic "composition over inheritance" thing btw
        private readonly LicenceType licenceType;

        private readonly SpecialOffer specialOffer;

        public string Movie { get; }

        public DateTime PurchaseDate { get; }


        public MovieLicense(string movie, DateTime purchaseDate, Discount d, LicenceType l, SpecialOffer s = SpecialOffer.None)
        {
            Movie = movie;
            PurchaseDate = purchaseDate;
            discount = d;
            licenceType = l;
            specialOffer = s;
        }


        public decimal GetPrice()
        {
            int dis = GetDiscount();
            decimal multiplier = 1 - dis / 100m;
            return GetBasePrice() * multiplier;
        }

        public DateTime? GetExpirationDate()
        {
            DateTime? expiration = GetBaseExpirationDate();
            TimeSpan extension = GetSpecialOfferExtension();

            return expiration?.Add(extension);
        }

        private int GetDiscount()
        {
            return discount switch
            {
                Discount.None => 0,
                Discount.Military => 10,
                Discount.Senior => 20,
                _ => throw new ArgumentOutOfRangeException(nameof(discount)),
            };
        }

        private decimal GetBasePrice()
        {
            return licenceType switch
            {
                LicenceType.TwoDays => 5m,
                LicenceType.LifeLong => 10m,
                _ => throw new ArgumentOutOfRangeException(nameof(licenceType)),
            };
        }

        private DateTime? GetBaseExpirationDate()
        {
            return licenceType switch
            {
                LicenceType.TwoDays => PurchaseDate.AddDays(2),
                LicenceType.LifeLong => null,
                _ => throw new ArgumentOutOfRangeException(nameof(licenceType)),
            };
        }

        private TimeSpan GetSpecialOfferExtension()
        {
            return specialOffer switch
            {
                SpecialOffer.None => TimeSpan.Zero,
                SpecialOffer.TwoDaysExtension => TimeSpan.FromDays(2),
                _ => throw new ArgumentOutOfRangeException(nameof(specialOffer)),
            };
        }
    }
}
