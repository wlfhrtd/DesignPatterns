using ChainValidation.Exceptions;
using ChainValidation.Handlers.UserValidation;
using ChainValidation.Models;

namespace ChainValidation.Business
{
    public class UserProcessor
    {
        // Initial code to refactor with Chain of Responsibility pattern
        //private SocialSecurityNumberValidator socialSecurityNumberValidator
        //    = new SocialSecurityNumberValidator();

        //public bool Register(User user)
        //{
        //    if (!socialSecurityNumberValidator.Validate(user.SocialSecurityNumber, user.CitizenshipRegion))
        //    {
        //        return false;
        //    }
        //    else if (user.Age < 18)
        //    {
        //        return false;
        //    }
        //    else if (user.Name.Length <= 1)
        //    {
        //        return false;
        //    }
        //    else if (user.CitizenshipRegion.TwoLetterISORegionName == "NO")
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        // Chain of Responsibility usage
        public bool Register(User user)
        {
            try
            {
                SocialSecurityNumberValidatorHandler handler = new();
                handler
                    .SetNext(new AgeValidationHandler())
                    .SetNext(new NameValidationHandler())
                    .SetNext(new CitizenshipRegionValidationHandler());

                handler.Handle(user);
            }
            catch (UserValidationException e)
            {
                return false;
            }

            return true;
        }
    }
}
