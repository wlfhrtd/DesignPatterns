using SpecificationConstraints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationConstraints.Models
{
    public class Machine : IUser
    {
        public Producer Producer { get; internal set; }
        public string Model { get; internal set; }
        public LegalEntity Owner { get; internal set; }

        public IContactInfo PrimaryContact => Owner.EmailAddress;

        internal Machine()
        { }

        public void SetIdentity(IUserIdentity identity)
        {
        }

        public bool CanAcceptIdentity(IUserIdentity identity)
        {
            return identity is MacAddress;
        }

        public override string ToString() => $"{Producer} {Model} owned by {Owner}";
    }
}
