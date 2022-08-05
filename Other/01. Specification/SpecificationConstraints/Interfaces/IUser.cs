using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationConstraints.Interfaces
{
    public interface IUser
    {
        void SetIdentity(IUserIdentity identity);

        bool CanAcceptIdentity(IUserIdentity identity);

        IContactInfo PrimaryContact { get; }
    }
}
