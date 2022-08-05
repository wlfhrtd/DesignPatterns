using System;


namespace SpecificationBuilding.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectAreaCode
    {
        IExpectNumber WithAreaCode(int areaCode);
    }
}
