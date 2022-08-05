using System;


namespace SpecificationConstraints.Specifications.Machine.Interfaces
{
    public interface IExpectProducer
    {
        IExpectModel ProducedBy(IBuildingSpecification<Models.Producer> producerSpec);
    }
}
