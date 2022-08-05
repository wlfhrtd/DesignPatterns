using SpecificationBuilding.Interfaces;
using SpecificationBuilding.Specifications.ContactInfo;
using SpecificationBuilding.Specifications.LegalEntity;
using SpecificationBuilding.Specifications.Producer;
using SpecificationBuilding.Specifications.User;
using System;


namespace SpecificationBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example
            // Specification allows to build complex objects with complex logic
            // complex objects may consist of other complex objects with their own complexity and specifications
            // instead of calling those other complex objects Specification provides specification objects
            // that is difference from Builder pattern btw
            //IUser user =
            //    UserSpecification
            //    .ForPerson()
            //    .WithName("Max")
            //    .WithSurname("Planck")
            //    .WithPrimaryContact(
            //        ContactSpecification
            //        .ForEmailAddress("example@mail.com"))
            //    .WithAlternateContact(
            //        ContactSpecification
            //        .ForPhoneNumber()
            //        .WithCountryCode(1)
            //        .WithAreaCode(23)
            //        .WithNumber(456789))
            //    .AndNoMoreContacts()
            //    .Build();
            #endregion

            // specifications may come from different sources e.g. web, db, files;
            // one of solutions to store partial objects is particular table for building specifications btw
            // this table most likely will look the same as table with "finalized" or "future" objects
            // but just will have all column fields nullable
            IUser user =
                UserSpecification
                    .ForMachine()
                    .ProducedBy(
                        ProducerSpecification
                            .WithName("Producer_company"))
                    .WithModel("SOME_MODEL")
                    .OwnedBy(
                        LegalEntitySpecification
                            .Initialize()
                            .WithCompanyName("Owner_company")
                            .WithEmailAddress(
                                ContactSpecification.ForEmailAddress("first@email"))
                            .WithPhoneNumber(
                                ContactSpecification
                                    .ForPhoneNumber()
                                    .WithCountryCode(1)
                                    .WithAreaCode(23)
                                    .WithNumber(456))
                            .WithOtherContact(
                                ContactSpecification.ForEmailAddress("second@email"))
                            .AndNoMoreContacts())
                    .Build();

            Console.WriteLine(user);
        }
    }
}
