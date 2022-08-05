using SpecificationBuilding.Interfaces;

namespace SpecificationBuilding.Specifications.Person.Interfaces
{
    public interface IExpectAlternateContact
    {
        IExpectAlternateContact WithAlternateContact(IBuildingSpecification<IContactInfo> contactSpec);

        IBuildingSpecification<Models.Person> AndNoMoreContacts();
    }
}