using SpecificationConstraints.Specifications.EmailAddress.Interfaces;
using System;


namespace SpecificationConstraints.Specifications.EmailAddress
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

        public bool Equals(IBuildingSpecification<Models.EmailAddress> other) =>
            Equals(other as EmailAddressSpecification);

        private bool Equals(EmailAddressSpecification other) =>
            other != null &&
            string.Compare(EmailAddress, other.EmailAddress, StringComparison.OrdinalIgnoreCase) == 0;
    }
}
