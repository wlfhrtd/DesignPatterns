using System;


namespace SpecificationConstraints.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectNumber
    {
        IBuildingSpecification<Models.PhoneNumber> WithNumber(int number);
    }
}
