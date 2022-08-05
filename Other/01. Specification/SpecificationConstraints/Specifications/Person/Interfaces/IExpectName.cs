using System;


namespace SpecificationConstraints.Specifications.Person.Interfaces
{
    public interface IExpectName
    {
        IExpectSurname WithName(string name);
    }
}
