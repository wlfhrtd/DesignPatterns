using SpecificationBuilding.Interfaces;

namespace SpecificationBuilding.Specifications.LegalEntity.Interfaces
{
    public interface IExpectOtherContact
    {
        IExpectOtherContact WithOtherContact(IBuildingSpecification<IContactInfo> contactSpec);

        IBuildingSpecification<Models.LegalEntity> AndNoMoreContacts();
    }
}