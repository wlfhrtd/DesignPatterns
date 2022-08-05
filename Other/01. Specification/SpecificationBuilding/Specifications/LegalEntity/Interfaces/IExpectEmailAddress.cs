namespace SpecificationBuilding.Specifications.LegalEntity.Interfaces
{
    public interface IExpectEmailAddress
    {
        IExpectPhoneNumber WithEmailAddress(IBuildingSpecification<Models.EmailAddress> emailSpec);
    }
}