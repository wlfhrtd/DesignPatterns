using System;
using System.Globalization;

namespace ChainValidation.Models
{
    public class User
    {
        public string Name { get; }
        public string SocialSecurityNumber { get; }
        public DateTimeOffset DateOfBirth { get; }
        public RegionInfo CitizenshipRegion { get; }

        public int Age
            => (int)((DateTimeOffset.UtcNow - DateOfBirth.UtcDateTime).TotalDays / 365.2425);


        public User(string name,
            string socialSecurityNumber,
            RegionInfo citizenshipRegion,
            DateTimeOffset dateOfBirth)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
            DateOfBirth = dateOfBirth;
            CitizenshipRegion = citizenshipRegion;
        }
    }
}
