using System;


namespace SpecificationBuilding.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectNumber
    {
        IBuildingSpecification<Models.PhoneNumber> WithNumber(int number);
    }
}
