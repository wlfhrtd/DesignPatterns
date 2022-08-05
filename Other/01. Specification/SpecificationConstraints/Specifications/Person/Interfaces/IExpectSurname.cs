using System;


namespace SpecificationConstraints.Specifications.Person.Interfaces
{
    public interface IExpectSurname
    {
        IExpectPrimaryContact WithSurname(string surname);
    }
}
