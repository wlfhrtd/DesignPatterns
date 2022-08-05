using SpecificationConstraints.Specifications.Machine;
using SpecificationConstraints.Specifications.Machine.Interfaces;
using SpecificationConstraints.Specifications.Person;
using SpecificationConstraints.Specifications.Person.Interfaces;


namespace SpecificationConstraints.Specifications.User
{
    public static class UserSpecification
    {
        public static IExpectName ForPerson() => PersonSpecification.Initialize();

        public static IExpectProducer ForMachine() => MachineSpecification.Initialize();
    }
}
