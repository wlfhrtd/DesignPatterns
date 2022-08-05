using System;


namespace SpecificationConstraints.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectCountryCode
    {
        IExpectAreaCode WithCountryCode(int countryCode);
    }
}
