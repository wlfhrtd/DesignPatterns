using System;

namespace AppOriginator.Exceptions
{
    public class InvalidGuessException : Exception
    {
        public InvalidGuessException(string message) : base(message)
        {
        }
    }
}
