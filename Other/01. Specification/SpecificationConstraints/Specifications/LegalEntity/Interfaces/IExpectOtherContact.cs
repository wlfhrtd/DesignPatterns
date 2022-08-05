using SpecificationConstraints.Interfaces;


namespace SpecificationConstraints.Specifications.LegalEntity.Interfaces
{
    public interface IExpectOtherContact
    {
        IExpectOtherContact WithOtherContact(IBuildingSpecification<IContactInfo> contactSpec);

        IBuildingSpecification<Models.LegalEntity> AndNoMoreContacts();
    }
}
