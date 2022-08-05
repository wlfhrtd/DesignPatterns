using System;


namespace SpecificationValidation.Validation.Infrastructure
{
    internal class Property<TType, TProperty> : Specification<TType>
    {
        private Func<TType, TProperty> PropertyGetter { get; }

        private Specification<TProperty> Subspecification { get; }


        public Property(Func<TType, TProperty> propertyGetter, Specification<TProperty> subspecification)
        {
            PropertyGetter = propertyGetter;
            Subspecification = subspecification;
        }


        public override bool IsSatisfiedBy(TType obj)
        {
            return Subspecification.IsSatisfiedBy(PropertyGetter(obj));
        }
    }
}
