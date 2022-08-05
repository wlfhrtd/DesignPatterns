namespace SpecificationBuilding.Specifications.Machine.Interfaces
{
    public interface IExpectOwner
    {
        IBuildingSpecification<Models.Machine> OwnedBy(IBuildingSpecification<Models.LegalEntity> ownerSpec);
    }
}