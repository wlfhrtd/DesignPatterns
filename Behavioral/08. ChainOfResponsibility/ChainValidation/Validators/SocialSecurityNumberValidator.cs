using ChainValidation.Exceptions;
using System.Globalization;

namespace ChainValidation.Validators
{
    public class SocialSecurityNumberValidator
    {
        public bool Validate(string socialSecurityNumber, RegionInfo region)
        {
            return region.TwoLetterISORegionName switch
            {
                "SE" => ValidateSwedishSocialSecurityNumber(socialSecurityNumber),
                "US" => ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber),
                _ => throw new UnsupportedSocialSecurityNumberException()
            };
        }

        private bool ValidateSwedishSocialSecurityNumber(string socialSecurityNumber)
        {
            return socialSecurityNumber.Length > 1;
        }

        private bool ValidateUnitedStatesSocialSecurityNumber(string socialSecurityNumber)
        {
            return socialSecurityNumber.Length > 2;
        }
    }
}
