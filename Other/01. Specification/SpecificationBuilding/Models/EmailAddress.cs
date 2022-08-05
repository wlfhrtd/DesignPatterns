using SpecificationBuilding.Interfaces;
using System.Globalization;

namespace SpecificationBuilding.Models
{
    public class EmailAddress : IContactInfo
    {
        public string Address { get; internal set; }

        internal EmailAddress()
        { }

        public override int GetHashCode() => Address.ToLower().GetHashCode();

        public override bool Equals(object obj)
        {
            EmailAddress email = obj as EmailAddress;

            return email == null
                ? false
                : string.Compare(Address, email.Address, true, CultureInfo.InvariantCulture) == 0;
        }

        public override string ToString() => $"{Address}";
    }
}