using System;


namespace SpecificationBuilding.Specifications
{
    public interface IBuildingSpecification<out T>
    {
        T Build();
    }
}
