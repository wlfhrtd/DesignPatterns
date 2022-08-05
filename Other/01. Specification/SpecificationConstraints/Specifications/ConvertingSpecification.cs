using System;


namespace SpecificationConstraints.Specifications
{
    public class ConvertingSpecification<TBase, TProduct> :
        IBuildingSpecification<TBase> where TProduct : TBase
    {
        private IBuildingSpecification<TProduct> ContainedSpec { get; }

        public ConvertingSpecification(IBuildingSpecification<TProduct> containedSpec)
        {
            if (containedSpec == null) throw new ArgumentNullException(nameof(containedSpec));
            ContainedSpec = containedSpec;
        }

        public TBase Build() => ContainedSpec.Build();

        public bool Equals(IBuildingSpecification<TBase> other)
        {
            ConvertingSpecification<TBase, TProduct> convertingSpec =
                other as ConvertingSpecification<TBase, TProduct>;

            return convertingSpec != null && ContainedSpec.Equals(convertingSpec.ContainedSpec);
        }

        public override int GetHashCode() => ContainedSpec.GetHashCode();

        public override bool Equals(object obj) =>
            Equals(obj as IBuildingSpecification<TBase>) ||
            ContainedSpec.Equals(obj as IBuildingSpecification<TProduct>);
    }
}
