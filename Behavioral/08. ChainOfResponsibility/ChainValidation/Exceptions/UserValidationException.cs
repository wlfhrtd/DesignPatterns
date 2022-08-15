﻿using System;

namespace ChainValidation.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message) : base(message)
        {
        }
    }
}
