using System;


namespace SpecificationConstraints.Specifications
{
    public static class BuildingSpecificationExtensions
    {
        public static bool SafeEquals<T>(this IBuildingSpecification<T> first,
                                         IBuildingSpecification<T> second)
        {
            bool firstNull = ReferenceEquals(first, null);
            bool secondNull = ReferenceEquals(second, null);

            return
                (firstNull && secondNull) ||
                (!firstNull && first.Equals(second));
        }
    }
}
