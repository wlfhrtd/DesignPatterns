using SpecificationBuilding.Interfaces;
using SpecificationBuilding.Specifications.LegalEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SpecificationBuilding.Specifications.LegalEntity
{
    public class LegalEntitySpecification : IExpectCompanyName, IExpectEmailAddress,
                                            IExpectPhoneNumber, IExpectOtherContact,
                                            IBuildingSpecification<Models.LegalEntity>
    {
        private string CompanyName { get; set; }

        private IBuildingSpecification<Models.EmailAddress> EmailAddressSpec { get; set; }

        private IBuildingSpecification<Models.PhoneNumber> PhoneNumberSpec { get; set; }

        private IList<IBuildingSpecification<IContactInfo>> OtherContactSpecs { get; set; }
            = new List<IBuildingSpecification<IContactInfo>>();


        private LegalEntitySpecification() { }


        public static IExpectCompanyName Initialize() => new LegalEntitySpecification();

        public IExpectEmailAddress WithCompanyName(string companyName)
        {
            return string.IsNullOrEmpty(companyName)
                ? throw new ArgumentException(nameof(companyName))
                : new LegalEntitySpecification() { CompanyName = companyName };
        }

        public IExpectPhoneNumber WithEmailAddress(IBuildingSpecification<Models.EmailAddress> emailSpec)
        {
            return emailSpec == null
                ? throw new ArgumentNullException()
                : new LegalEntitySpecification() { CompanyName = CompanyName, EmailAddressSpec = emailSpec };
        }

        public IExpectOtherContact WithPhoneNumber(IBuildingSpecification<Models.PhoneNumber> phoneSpec)
        {
            return phoneSpec == null
                ? throw new ArgumentNullException()
                : new LegalEntitySpecification()
                {
                    CompanyName = CompanyName,
                    EmailAddressSpec = EmailAddressSpec,
                    PhoneNumberSpec = phoneSpec
                };
        }

        public IExpectOtherContact WithOtherContact(IBuildingSpecification<IContactInfo> contactSpec)
        {
            return contactSpec == null
                ? throw new ArgumentNullException()
                : new LegalEntitySpecification()
                {
                    CompanyName = CompanyName,
                    EmailAddressSpec = EmailAddressSpec,
                    PhoneNumberSpec = PhoneNumberSpec,
                    OtherContactSpecs = new List<IBuildingSpecification<IContactInfo>>(OtherContactSpecs) { contactSpec }
                };
        }

        public IBuildingSpecification<Models.LegalEntity> AndNoMoreContacts() => this;

        public Models.LegalEntity Build() =>
            new Models.LegalEntity()
            {
                CompanyName = CompanyName,
                EmailAddress = EmailAddressSpec.Build(),
                PhoneNumber = PhoneNumberSpec.Build(),
                OtherContacts = OtherContactSpecs.Select(spec => spec.Build()).ToList()
            };
    }
}
