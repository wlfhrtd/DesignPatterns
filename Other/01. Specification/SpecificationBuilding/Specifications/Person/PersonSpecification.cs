using SpecificationBuilding.Interfaces;
using SpecificationBuilding.Specifications.Person.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationBuilding.Specifications.Person
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

        public IExpectAlternateContact WithPrimaryContact(IBuildingSpecification<IContactInfo> primaryContactSpec)
        {
            return primaryContactSpec == null
                ? throw new ArgumentNullException()
                : new PersonSpecification()
                {
                    Name = Name,
                    Surname = Surname,
                    ContactSpecs = new[] { primaryContactSpec },
                    PrimaryContactSpec = primaryContactSpec
                };
        }

        public IExpectAlternateContact WithAlternateContact(IBuildingSpecification<IContactInfo> contactSpec)
        {
            return contactSpec == null
                ? throw new ArgumentNullException()
                : new PersonSpecification()
                {
                    Name = Name,
                    Surname = Surname,
                    ContactSpecs = new List<IBuildingSpecification<IContactInfo>>(ContactSpecs) { contactSpec },
                    PrimaryContactSpec = PrimaryContactSpec
                };
        }

        public IBuildingSpecification<Models.Person> AndNoMoreContacts() => this;

        public Models.Person Build() =>
            new Models.Person()
            {
                Name = Name,
                Surname = Surname,
                PrimaryContact = PrimaryContactSpec.Build(),
                ContactsList = ContactSpecs.Select(spec => spec.Build()).ToList()
            };
    }
}