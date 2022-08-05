using SpecificationConstraints.Interfaces;
using SpecificationConstraints.Models;
using SpecificationConstraints.Specifications;
using SpecificationConstraints.Specifications.ContactInfo;
using SpecificationConstraints.Specifications.Person.Interfaces;
using SpecificationConstraints.Specifications.User;
using System;


namespace SpecificationConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            #region PROBLEM
            // email address is not unique across specifications
            IUser user =
                UserSpecification
                .ForPerson()
                .WithName("Max")
                .WithSurname("Planck")
                .WithPrimaryContact(
                    ContactSpecification.ForEmailAddress("example@mail.com"))
                .WithAlternateContact(
                    ContactSpecification.ForEmailAddress("example@mail.com"))
                .AndNoMoreContacts()
                .Build();

            Console.WriteLine(user);
            #endregion

            #region EXPLANATION
            // new Specification implementation requires invariance in IBuildingSpecification
            // to introduce covariance back there are several ways:
            // - implicit conversion operator overload
            // - explicit conversion operator overload
            // - class method .As%ANOTHER_CLASSNAME%() e.g. .AsCat() .AsDog() etc
            // - wrapper class shown below

            //class Cat { }

            //class Dog { }

            //class WrappedDog : Cat
            //{
            //    public WrappedDog(Dog dog) { }
            //}

            // Cat cat = new WrappedDog(new Dog());
            #endregion

            IExpectAlternateContact spec =
                UserSpecification
                .ForPerson()
                .WithName("Max")
                .WithSurname("Planck")
                .WithPrimaryContact(
                    ContactSpecification.ForEmailAddress("example@mail.com"));

            IBuildingSpecification<EmailAddress> contact =
                ContactSpecification.ForEmailAddress("example2@mail.com");

            // actually test for equality provided by Specification classes is already too much
            // they already have 2 responsibilities - validation and creation
            // better do validation of input before passing it into Specifications
            // so here for example client/context could just validate raw input for emails
            // before calling for specifications
            if (!spec.CanAdd(contact))
            {
                Console.WriteLine("Unable to add contact.");
                return;
            }

            spec = spec.WithAlternateContact(contact);
            IUser u = spec.AndNoMoreContacts().Build();

            Console.WriteLine(u);
        }
    }
}
