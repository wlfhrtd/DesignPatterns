using SpecificationBuilding.Specifications.Machine.Interfaces;
using System;

namespace SpecificationBuilding.Specifications.Machine
{
    public class MachineSpecification : IExpectProducer, IExpectModel, IExpectOwner,
                                        IBuildingSpecification<Models.Machine>
    {
        private IBuildingSpecification<Models.Producer> ProducerSpec { get; set; }

        private string Model { get; set; }

        private IBuildingSpecification<Models.LegalEntity> OwnerSpec { get; set; }

        private MachineSpecification()
        { }

        public static IExpectProducer Initialize() => new MachineSpecification();

        public IExpectModel ProducedBy(IBuildingSpecification<Models.Producer> producerSpec)
        {
            return producerSpec == null
                ? throw new ArgumentNullException()
                : new MachineSpecification() { ProducerSpec = producerSpec };
        }

        public IExpectOwner WithModel(string model)
        {
            return string.IsNullOrEmpty(model)
                ? throw new ArgumentException()
                : new MachineSpecification() { ProducerSpec = ProducerSpec, Model = model };
        }

        public IBuildingSpecification<Models.Machine> OwnedBy(IBuildingSpecification<Models.LegalEntity> ownerSpec)
        {
            return ownerSpec == null
                ? throw new ArgumentNullException()
                : new MachineSpecification()
                {
                    ProducerSpec = ProducerSpec,
                    Model = Model,
                    OwnerSpec = ownerSpec
                };
        }

        public Models.Machine Build() =>
            new Models.Machine()
            {
                Producer = ProducerSpec.Build(),
                Model = Model,
                Owner = OwnerSpec.Build()
            };
    }
}