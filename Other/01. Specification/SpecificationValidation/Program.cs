using SpecificationValidation.Interfaces;
using SpecificationValidation.Models;
using SpecificationValidation.Validation;
using System;
using System.Linq;


namespace SpecificationValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new()
            {
                Name = "Max",
                Surname = "Planck",
            };

            Console.WriteLine("SHOW IN UI:");
            #region UGLY
            // ugly Specification
            // DoSomethingWith(person, new Property<Person, string>(p => p.Name, new NotNull<string>()));
            // better but still
            //DoSomethingWith(
            //    person,
            //    new Composite<Person>(results => results.All(res => res == true),
            //    Spec<Person>.NotNull(p => p.Name),
            //    Spec<Person>.NotNull(p => p.Surname)));
            #endregion
            // Specification as Expression Tree with wrappers
            DoSomethingWith(
                person,
                Spec<Person>.NotNull(p => p.Name)
                .And(Spec<Person>.NotNull(p => p.Surname))
                .And(Spec<Person>.NotNull(p => p.Contacts))
                .And(
                    Spec<Person>.Null(p => p.PrimaryContact)
                    .Or(Spec<Person>.IsTrue(p => p.Contacts.Contains(p.PrimaryContact)))));

            Console.WriteLine("SAVE TO DB:");
            DoSomethingWith(
                person,
                Spec<Person>.NonEmptyString(p => p.Name)
                .And(Spec<Person>.NonEmptyString(p => p.Surname))
                .And(Spec<Person>.NotNull(p => p.Contacts))
                .And(Spec<Person>.IsTrue(p => p.Contacts.Contains(p.PrimaryContact))));

            #region WITHOUT SPECIFICATION
            //Console.WriteLine("SHOW IN UI:");
            //DoSomethingWith(person, p =>
            //p.Name != null
            //&& p.Surname != null
            //&& p.Contacts != null
            //&& (p.PrimaryContact == null || p.Contacts.Contains(p.PrimaryContact)));

            //Console.WriteLine("SAVE TO DB:");
            //DoSomethingWith(person, p =>
            //!string.IsNullOrEmpty(p.Name)
            //&& !string.IsNullOrEmpty(p.Surname)
            //&& p.Contacts != null
            //&& p.PrimaryContact != null
            //&& p.Contacts.Contains(p.PrimaryContact));
            #endregion
        }

        // using Specification
        private static void DoSomethingWith(Person person, Specification<Person> validator)
        {
            if (!validator.IsSatisfiedBy(person))
            {
                Console.WriteLine("Not applicable..");
                return;
            }

            Console.WriteLine($"   Name: {person.Name}");
            Console.WriteLine($"Surname: {person.Surname}");
            Console.WriteLine("Contacts:");
            foreach (IContactInfo contact in person.Contacts)
            {
                Console.WriteLine($"  {(contact == person.PrimaryContact ? "*" : " ")}{contact}");
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();
        }

        #region WITHOUT SPECIFICATION
        //private static void DoSomethingWith(Person person, Func<Person, bool> predicate)
        //{
        //    if (!predicate(person))
        //    {
        //        Console.WriteLine("Not applicable..");
        //        return;
        //    }

        //    Console.WriteLine($"   Name: {person.Name}");
        //    Console.WriteLine($"Surname: {person.Surname}");
        //    Console.WriteLine("Contacts:");
        //    foreach (IContactInfo contact in person.Contacts)
        //    {
        //        Console.WriteLine($"  {(contact == person.PrimaryContact ? "*" : " ")}{contact}");
        //    }
        //    Console.WriteLine(new string('-', 20));
        //    Console.WriteLine();
        //}
        #endregion
    }
}
