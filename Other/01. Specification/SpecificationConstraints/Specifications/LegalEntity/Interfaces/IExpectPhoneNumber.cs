using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationConstraints.Specifications.LegalEntity.Interfaces
{
    public interface IExpectPhoneNumber
    {
        IExpectOtherContact WithPhoneNumber(IBuildingSpecification<Models.PhoneNumber> phoneSpec);
    }
}
