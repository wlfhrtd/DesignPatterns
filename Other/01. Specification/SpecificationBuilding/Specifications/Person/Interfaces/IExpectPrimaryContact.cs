using SpecificationBuilding.Interfaces;

namespace SpecificationBuilding.Specifications.Person.Interfaces
{
    public interface IExpectPrimaryContact
    {
        IExpectAlternateContact WithPrimaryContact(IBuildingSpecification<IContactInfo> primaryContactSpec);
    }
}