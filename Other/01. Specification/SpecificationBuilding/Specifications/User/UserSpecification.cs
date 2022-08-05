using SpecificationBuilding.Specifications.Machine;
using SpecificationBuilding.Specifications.Machine.Interfaces;
using SpecificationBuilding.Specifications.Person;
using SpecificationBuilding.Specifications.Person.Interfaces;

namespace SpecificationBuilding.Specifications.User
{
    public static class UserSpecification
    {
        public static IExpectName ForPerson() => PersonSpecification.Initialize();

        public static IExpectProducer ForMachine() => MachineSpecification.Initialize();
    }
}