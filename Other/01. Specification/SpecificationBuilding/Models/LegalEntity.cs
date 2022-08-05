using SpecificationBuilding.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationBuilding.Models
{
    public class LegalEntity
    {
        public string CompanyName { get; internal set; }

        public EmailAddress EmailAddress { get; internal set; }

        public PhoneNumber PhoneNumber { get; internal set; }

        public IEnumerable<IContactInfo> OtherContacts { get; internal set; }

        internal LegalEntity()
        { }

        public override string ToString() =>
            $"{CompanyName} {EmailAddress} {PhoneNumber} [{OtherContactsToString()}]";

        private string OtherContactsToString() =>
            string.Join(", ", OtherContactsToStringArray());

        private string[] OtherContactsToStringArray() =>
            OtherContacts.Select(contact => contact.ToString()).ToArray();
    }
}