using System;


namespace SpecificationConstraints.Specifications.LegalEntity.Interfaces
{
    public interface IExpectEmailAddress
    {
        IExpectPhoneNumber WithEmailAddress(IBuildingSpecification<Models.EmailAddress> emailSpec);
    }
}
