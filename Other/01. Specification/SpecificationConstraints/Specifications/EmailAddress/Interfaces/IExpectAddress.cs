using System;


namespace SpecificationConstraints.Specifications.EmailAddress.Interfaces
{
    public interface IExpectAddress
    {
        IBuildingSpecification<Models.EmailAddress> WithAddress(string emailAddress);
    }
}
