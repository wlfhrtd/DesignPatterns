using SpecificationBuilding.Specifications.EmailAddress;
using SpecificationBuilding.Specifications.PhoneNumber;
using SpecificationBuilding.Specifications.PhoneNumber.Interfaces;


namespace SpecificationBuilding.Specifications.ContactInfo
{
    public static class ContactSpecification
    {
        public static IBuildingSpecification<Models.EmailAddress> ForEmailAddress(string emailAddress) =>
            EmailAddressSpecification.Initialize().WithAddress(emailAddress);

        public static IExpectCountryCode ForPhoneNumber() =>
            PhoneNumberSpecification.Initialize();
    }
}
