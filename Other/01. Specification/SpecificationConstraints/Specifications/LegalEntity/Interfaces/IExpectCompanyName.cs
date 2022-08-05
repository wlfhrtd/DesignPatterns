using System;


namespace SpecificationConstraints.Specifications.LegalEntity.Interfaces
{
    public interface IExpectCompanyName
    {
        IExpectEmailAddress WithCompanyName(string companyName);
    }
}
