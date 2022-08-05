using SpecificationConstraints.Interfaces;
using SpecificationConstraints.Specifications.Person.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationConstraints.Specifications.Person
{
    public class PersonSpecification :
        IExpectName, IExpectSurname,
        IExpectPrimaryContact, IExpectAlternateContact,
        IBuildingSpecification<Models.Person>
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private IEnumerable<IBuildingSpecification<IContactInfo>> ContactSpecs { get; set; }
        private IBuildingSpecification<IContactInfo> PrimaryContactSpec { get; set; }

        private PersonSpecification()
        { }

        public static IExpectName Initialize() => new PersonSpecification();

        public IExpectSurname WithName(string name)
        {
            return string.IsNullOrEmpty(name)
                ? throw new ArgumentException()
                : new PersonSpecification()
                {
                    Name = name
                };
        }

        public IExpectPrimaryContact WithSurname(string surname)
        {
            return string.IsNullOrEmpty(surname)
                ? throw new ArgumentException()
                : new PersonSpecification()
                {
                    Name = Name,
                    Surname = surname
                };
        }

        public IExpectAlternateContact WithPrimaryContact<T>(
            IBuildingSpecification<T> primaryContactSpec) where T : IContactInfo
        {
            ConvertingSpecification<IContactInfo, T> wrappedSpec =
                new ConvertingSpecification<IContactInfo, T>(primaryContactSpec);

            return primaryContactSpec == null
                ? throw new ArgumentNullException()
                : new PersonSpecification()
                {
                    Name = Name,
                    Surname = Surname,
                    ContactSpecs = new[] { wrappedSpec },
                    PrimaryContactSpec = wrappedSpec,
                };
        }

        public IExpectAlternateContact WithAlternateContact<T>(
            IBuildingSpecification<T> contactSpec) where T : IContactInfo
        {
            if (!CanAdd(contactSpec)) throw new ArgumentException(nameof(contactSpec));

            ConvertingSpecification<IContactInfo, T> wrappedSpec =
                new ConvertingSpecification<IContactInfo, T>(contactSpec);

            return new PersonSpecification()
            {
                Name = Name,
                Surname = Surname,
                ContactSpecs = new List<IBuildingSpecification<IContactInfo>>(ContactSpecs) { wrappedSpec },
                PrimaryContactSpec = PrimaryContactSpec
            };
        }

        public bool CanAdd<T>(IBuildingSpecification<T> contactSpec) where T : IContactInfo =>
            contactSpec != null &&
            CanAdd(new ConvertingSpecification<IContactInfo, T>(contactSpec));

        private bool CanAdd(IBuildingSpecification<IContactInfo> contactSpec) =>
            !ContactSpecs.Any(spec => spec.Equals(contactSpec));

        public IBuildingSpecification<Models.Person> AndNoMoreContacts() => this;

        public Models.Person Build() =>
            new Models.Person()
            {
                Name = Name,
                Surname = Surname,
                PrimaryContact = PrimaryContactSpec.Build(),
                ContactsList = ContactSpecs.Select(spec => spec.Build()).ToList()
            };

        public bool Equals(IBuildingSpecification<Models.Person> other) =>
            Equals(other as PersonSpecification);

        private bool Equals(PersonSpecification other) =>
            other != null &&
            Name == other.Name &&
            Surname == other.Surname &&
            PrimaryContactSpec.SafeEquals(other.PrimaryContactSpec) &&
            ContactSpecs.SequenceEqual(other.ContactSpecs);
    }
}
