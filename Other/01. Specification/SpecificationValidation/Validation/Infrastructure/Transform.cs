using System;


namespace SpecificationValidation.Validation.Infrastructure
{
    internal class Transform<T> : Specification<T>
    {
        private Func<bool, bool> Transformation { get; }

        private Specification<T> Subspecification { get; }


        public Transform(Func<bool, bool> transformation, Specification<T> subspecification)
        {
            Transformation = transformation;
            Subspecification = subspecification;
        }


        public override bool IsSatisfiedBy(T obj)
        {
            return Transformation(Subspecification.IsSatisfiedBy(obj));
        }
    }
}
