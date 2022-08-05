using SpecificationConstraints.Interfaces;


namespace SpecificationConstraints.Specifications.Person.Interfaces
{
    public interface IExpectPrimaryContact
    {

        // IExpectAlternateContact WithPrimaryContact(IBuildingSpecification<IContactInfo> primaryContactSpec);

        // bring covariance with derivation
        IExpectAlternateContact WithPrimaryContact<T>(
            IBuildingSpecification<T> primaryContactSpec) where T : IContactInfo;
    }
}
