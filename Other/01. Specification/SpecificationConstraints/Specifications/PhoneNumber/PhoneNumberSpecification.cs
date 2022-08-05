using SpecificationConstraints.Specifications.PhoneNumber.Interfaces;
using System;


namespace SpecificationConstraints.Specifications.PhoneNumber
{
    public class PhoneNumberSpecification : IExpectCountryCode, IExpectAreaCode,
                                            IExpectNumber, IBuildingSpecification<Models.PhoneNumber>
    {
        private int CountryCode { get; set; }

        private int AreaCode { get; set; }

        private int Number { get; set; }


        private PhoneNumberSpecification() { }


        public static IExpectCountryCode Initialize() => new PhoneNumberSpecification();

        public IExpectAreaCode WithCountryCode(int countryCode)
        {
            return countryCode <= 0
                ? throw new ArgumentException(nameof(countryCode))
                : new PhoneNumberSpecification() { CountryCode = countryCode };
        }

        public IExpectNumber WithAreaCode(int areaCode)
        {
            return areaCode <= 0
                ? throw new ArgumentException(nameof(areaCode))
                : new PhoneNumberSpecification() { CountryCode = CountryCode, AreaCode = areaCode };
        }

        public IBuildingSpecification<Models.PhoneNumber> WithNumber(int number)
        {
            return number <= 0
                ? throw new ArgumentException(nameof(number))
                : new PhoneNumberSpecification()
                {
                    CountryCode = CountryCode,
                    AreaCode = AreaCode,
                    Number = number,
                };
        }

        public Models.PhoneNumber Build() =>
            new Models.PhoneNumber()
            {
                CountryCode = CountryCode,
                AreaCode = AreaCode,
                Number = Number,
            };

        public bool Equals(IBuildingSpecification<Models.PhoneNumber> other) =>
            Equals(other as PhoneNumberSpecification);

        private bool Equals(PhoneNumberSpecification other) =>
            other != null &&
            CountryCode == other.CountryCode &&
            AreaCode == other.AreaCode &&
            Number == other.Number;
    }
}
