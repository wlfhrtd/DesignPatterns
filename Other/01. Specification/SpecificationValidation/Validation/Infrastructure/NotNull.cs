using System;


namespace SpecificationValidation.Validation.Infrastructure
{
    internal class NotNull<T> : Specification<T>
    {
        public override bool IsSatisfiedBy(T obj)
        {
            return !ReferenceEquals(obj, null);
        }
    }
}
