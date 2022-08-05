using System;


namespace SpecificationBuilding.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectCountryCode
    {
        IExpectAreaCode WithCountryCode(int countryCode);
    }
}
