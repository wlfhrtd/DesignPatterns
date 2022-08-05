using SpecificationBuilding.Interfaces;

namespace SpecificationBuilding.Models
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