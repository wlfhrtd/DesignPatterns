using System;


namespace SpecificationBuilding.Specifications.EmailAddress.Interfaces
{
    public interface IExpectAddress
    {
        IBuildingSpecification<Models.EmailAddress> WithAddress(string emailAddress);
    }
}
