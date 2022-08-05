using System;


namespace SpecificationValidation.Validation.Infrastructure
{
    internal class NonEmptyString : Specification<string>
    {
        public override bool IsSatisfiedBy(string obj)
        {
            return !string.IsNullOrEmpty(obj);
        }
    }
}
