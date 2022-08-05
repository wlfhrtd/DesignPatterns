using System;


namespace SpecificationConstraints.Specifications
{
    // current implementation doesn't allow to add required constraints
    //public interface IBuildingSpecification<out T>
    //{
    //    T Build();
    //}

    public interface IBuildingSpecification<T> : IEquatable<IBuildingSpecification<T>>
    {
        T Build();
    }
}
