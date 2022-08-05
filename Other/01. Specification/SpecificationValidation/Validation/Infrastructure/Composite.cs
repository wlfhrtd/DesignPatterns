using System;
using System.Collections.Generic;
using System.Linq;


namespace SpecificationValidation.Validation.Infrastructure
{
    internal class Composite<T> : Specification<T>
    {
        private Func<IEnumerable<bool>, bool> CompositionFunction { get; }

        private IEnumerable<Specification<T>> Subspecifications { get; }


        public Composite(Func<IEnumerable<bool>, bool> compositionFunction, params Specification<T>[] subspecifications)
        {
            CompositionFunction = compositionFunction;
            Subspecifications = subspecifications;
        }


        public override bool IsSatisfiedBy(T obj)
        {
            return CompositionFunction(Subspecifications.Select(s => s.IsSatisfiedBy(obj)));
        }
    }
}
