using SpecificationValidation.Validation.Infrastructure;
using System.Linq;


namespace SpecificationValidation.Validation
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T obj);

        public Specification<T> And(Specification<T> other) =>
            new Composite<T>(results => results.All(res => res == true), this, other);

        public Specification<T> Or(Specification<T> other) =>
            new Composite<T>(results => results.Any(res => res == true), this, other);

        public Specification<T> Not() => new Transform<T>(res => !res, this);
    }
}
