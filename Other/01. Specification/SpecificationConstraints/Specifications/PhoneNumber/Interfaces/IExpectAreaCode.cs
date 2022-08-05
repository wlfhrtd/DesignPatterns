using System;


namespace SpecificationConstraints.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectAreaCode
    {
        IExpectNumber WithAreaCode(int areaCode);
    }
}
