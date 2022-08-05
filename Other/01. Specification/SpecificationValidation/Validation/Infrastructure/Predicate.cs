using System;


namespace SpecificationValidation.Validation.Infrastructure
{
    internal class Predicate<T> : Specification<T>
    {
        private Func<T, bool> Delegate { get; }


        public Predicate(Func<T, bool> predicate)
        {
            Delegate = predicate;
        }


        public override bool IsSatisfiedBy(T obj)
        {
            return Delegate(obj);
        }
    }
}
