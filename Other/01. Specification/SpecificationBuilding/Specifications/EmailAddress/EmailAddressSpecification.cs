using SpecificationBuilding.Specifications.EmailAddress.Interfaces;
using System;


namespace SpecificationBuilding.Specifications.EmailAddress
{
    public class EmailAddressSpecification : IExpectAddress, IBuildingSpecification<Models.EmailAddress>
    {
        private string EmailAddress { get; set; }


        private EmailAddressSpecification() { }


        public static IExpectAddress Initialize() => new EmailAddressSpecification();

        public IBuildingSpecification<Models.EmailAddress> WithAddress(string emailAddress)
        {
            return string.IsNullOrEmpty(emailAddress)
                ? throw new ArgumentException(nameof(emailAddress))
                : new EmailAddressSpecification() { EmailAddress = emailAddress };
        }

        public Models.EmailAddress Build() => new Models.EmailAddress() { Address = EmailAddress };
    }
}
