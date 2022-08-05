using SpecificationConstraints.Specifications.EmailAddress;
using SpecificationConstraints.Specifications.PhoneNumber;
using SpecificationConstraints.Specifications.PhoneNumber.Interfaces;
using System;


namespace SpecificationConstraints.Specifications.ContactInfo
{
    public static class ContactSpecification
    {
        public static IBuildingSpecification<Models.EmailAddress> ForEmailAddress(string emailAddress) =>
            EmailAddressSpecification.Initialize().WithAddress(emailAddress);

        public static IExpectCountryCode ForPhoneNumber() =>
            PhoneNumberSpecification.Initialize();
    }
}
