using System;


namespace SpecificationBuilding.Specifications.Producer
{
    public class ProducerSpecification : IBuildingSpecification<Models.Producer>
    {
        private string Name { get; set; }

        private ProducerSpecification() { }

        public static IBuildingSpecification<Models.Producer> WithName(string name)
        {
            return string.IsNullOrEmpty(name)
                ? throw new ArgumentException(nameof(name))
                : new ProducerSpecification() { Name = name };
        }

        public Models.Producer Build() =>
            new Models.Producer() { Name = Name };
    }
}
